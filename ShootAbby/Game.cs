using ShootAbby.Model;
using System.Diagnostics;

namespace ShootAbby
{
    public partial class Game : Form
    {
        public static readonly int WIDTH = 1200;
        public static readonly int HEIGHT = 800;

        BufferedGraphicsContext _currentContext;
        BufferedGraphics _game;
        Witch _witch;
        BackGround _backGround;
        private Image _image;
        private Rectangle _rectangle;
        private List<Rock> _rocks = new List<Rock>();
        private List<Spawn> _zones = new List<Spawn>();
        private List<Slime> _slimes = new List<Slime>();

        //visuel du score
        private int _score = 0;
        private Font _drawFont = new Font("Arial", 10);
        private SolidBrush _writingBrush = new SolidBrush(Color.Black);

        public Game()
        {
            /* test du try and catch
            try
            {
                _witch = new Witch(400, 200);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ça va la tête ???");
            }
            */

            InitializeComponent();
            _currentContext = BufferedGraphicsManager.Current;
            _game = _currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            //
            //fluidifie le mouvement 
            //
            ticker.Interval = 10;
            //
            //le joueur
            //
            _witch = new Witch(WIDTH / 2, HEIGHT / 2);
            //
            //
            //
            _backGround = new BackGround(0, 0);
            //
            // Les zones
            //
            Spawn zone1 = new Spawn(WIDTH - 170, HEIGHT - 170);
            _zones.Add(zone1);
            Spawn zone2 = new Spawn(WIDTH - 170, HEIGHT - 630);
            _zones.Add(zone2);
            Spawn zone3 = new Spawn(WIDTH - 1030, HEIGHT - 630);
            _zones.Add(zone3);
            Spawn zone4 = new Spawn(WIDTH - 1030, HEIGHT - 170);
            _zones.Add(zone4);
            ///
            /// Image
            /// 
            _image = Image.FromFile("Image/background.jpg");
            _rectangle = new Rectangle(0, 0, WIDTH, HEIGHT);

            SpawnSlime();

            //
            //Création des crocher
            //
            for (int i = 0; i < 3; i++)
            {
                Rock rocher = new Rock(Helper.Random(0, WIDTH), Helper.Random(0, HEIGHT));
                bool _condition = true;
                while (_condition)
                {
                    _condition = false;

                    foreach (Rock element in _rocks)
                    {
                        if (rocher.IsTouching(element.Rectangle))
                        {
                            _condition = true;
                        }
                    }
                    foreach (Spawn element in _zones)
                    {
                        if (rocher.IsTouching(element.Rectangle))
                        {
                            _condition = true;
                        }
                    }
                    if (rocher.IsTouching(_witch.Rectangle))
                    {
                        _condition = true;
                    }
                    if (_condition)
                    {
                        rocher = new Rock(Helper.Random(0, WIDTH - 50), Helper.Random(0, HEIGHT - 50));
                    }
                }
                _rocks.Add(rocher);
            }
        }
        /// <summary>
        /// Mettre à jour l'affichage tout les 100 ms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewFrame(object sender, EventArgs e)
        {
            if (!_witch.IsDead())
            {
                VerifyCollision();
                UpdatePosition();
                Render();
            }
        }
        /// <summary>
        /// Vérifier les collisisons
        /// </summary>
        private void VerifyCollision()
        {
            List<Projectil> poubelle = new List<Projectil>();
            bool estDansLaPoubelle = false;
            List<Slime> poubelleSlime = new List<Slime>();
            foreach (Projectil projectil in _witch.Projectiles)
            {
                foreach (Slime slime in _slimes)
                {
                    if (!slime.IsDead() && slime.IsTouching(projectil.Rectangle))
                    {
                        poubelle.Add(projectil);
                        estDansLaPoubelle = true;
                        slime.Pv--;
                        if (slime.IsDead())
                        {
                            poubelleSlime.Add(slime);
                            _score += 10;
                        }
                    }
                }

                if (!estDansLaPoubelle)
                {
                    foreach (Rock rock in _rocks)
                    {
                        if (rock.IsTouching(projectil.Rectangle))
                        {
                            poubelle.Add(projectil);
                            estDansLaPoubelle = true;
                        }
                    }
                }
                estDansLaPoubelle = false;
            }
            foreach (Slime slime in poubelleSlime)
            {
                _slimes.Remove(slime);
            }

            foreach (Projectil item in poubelle)
            {
                _witch.Projectiles.Remove(item);
            }

            foreach (Slime slime in _slimes)
            {
                if (slime.IsTouching(_witch.Rectangle))
                {
                    _witch.Pv--;
                }
            }
        }
        /// <summary>
        /// Empecher la sortie de zone
        /// </summary>
        private void UpdatePosition()
        {
            if (_slimes.Count == 0)
            {
                SpawnSlime();
            }
            _witch.PreventOutside();
            List<Projectil> poubelle = new List<Projectil>();
            foreach (Projectil item in _witch.Projectiles)
            {
                item.MoveProjectile();
                if (!item.IsInside())
                {
                    poubelle.Add(item);
                }
            }
            foreach (Projectil item in poubelle)
            {
                _witch.Projectiles.Remove(item);
            }
            foreach (Slime slime in _slimes)
            {
                bool _condition = true;
                foreach (Rock rock in _rocks)
                {
                    if (slime.IsTouching(rock.Rectangle))
                    {
                        _condition = false;

                        slime.MoveBack(rock.Rectangle);
                    }
                }
                if (_condition)
                {
                    slime.Move(_witch.Rectangle);
                }
            }

        }
        private void Render()
        {

            _game.Graphics.Clear(Color.LightGreen);
            // _game.Graphics.DrawImage(_image, _rectangle);
            //_backGround.Render(_game);
            for (int i = 0; i < _rocks.Count; i++)
            {
                _rocks[i].Render(_game);
            }
            for (int i = 0; i < _witch.Projectiles.Count; i++)
            {
                _witch.Projectiles[i].Render(_game);
            }
            foreach (Spawn zone in _zones)
            {
                zone.Render(_game);
            }
            foreach (Slime slime in _slimes)
            {
                slime.Render(_game);
            }

            //afficher le score
            _game.Graphics.DrawString($"Score : {_score}", _drawFont, _writingBrush, 0, 0);

            _witch.Render(_game);
            _game.Render();

        }
        /// <summary>
        /// Détecter les touches pour effectuer les déplacements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PressKey(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);

            switch (e.KeyCode)
            {
                case Keys.A:
                    _witch.Move(-5, 0);
                    UpdateColission(5, 0);
                    break;
                case Keys.W:
                    _witch.Move(0, -5);
                    UpdateColission(0, 5);
                    break;
                case Keys.S:
                    _witch.Move(0, 5);
                    UpdateColission(0, -5);
                    break;
                case Keys.D:
                    _witch.Move(5, 0);
                    UpdateColission(-5, 0);
                    break;
                case Keys.Up:
                    Projectil proUp = new Projectil(_witch.Rectangle.X + 50, _witch.Rectangle.Y, 0, -2);
                    _witch.Projectiles.Add(proUp);
                    break;
                case Keys.Down:
                    Projectil proDown = new Projectil(_witch.Rectangle.X + 50, _witch.Rectangle.Y + 100, 0, 2);
                    _witch.Projectiles.Add(proDown);
                    break;
                case Keys.Right:
                    Projectil proRight = new Projectil(_witch.Rectangle.X + 100, _witch.Rectangle.Y + 50, 2, 0);
                    _witch.Projectiles.Add(proRight);
                    break;
                case Keys.Left:
                    Projectil proLeft = new Projectil(_witch.Rectangle.X, _witch.Rectangle.Y + 50, -2, 0);
                    _witch.Projectiles.Add(proLeft);
                    break;

            }
        }
        private void UpdateColission(int x, int y)
        {
            bool _condition = false;
            foreach (Rock e in _rocks)
            {
                if (e.IsTouching(_witch.Rectangle))
                {
                    _condition = true;
                }
            }
            if (_condition)
            {
                _witch.Move(x, y);
            }
        }
        /// <summary>
        /// Ajouter un slime à la liste
        /// </summary>
        /// <returns></returns>
        private void SpawnSlime()
        {
            foreach (Spawn zone in _zones)
            {
                Slime slime = new Slime(zone.Rectangle.X, zone.Rectangle.Y);
                _slimes.Add(slime);
            }
        }
    }
}
