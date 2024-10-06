using ShootAbby.Model;
using System.Diagnostics;

namespace ShootAbby
{
    public partial class Game : Form
    {
        public static readonly int WIDTH = 1800;
        public static readonly int HEIGHT = 1200;

        BufferedGraphicsContext _currentContext;
        BufferedGraphics _game;
        Witch _witch;
        private List<Rock> _rocks = new List<Rock>();
        private List<Spawn> _zones = new List<Spawn>();

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
            // Les slimes
            //
            Spawn zone1 = new Spawn(300, 300);
            _zones.Add(zone1);
            Spawn zone2 = new Spawn(1500, 300);
            _zones.Add(zone2);
            Spawn zone3 = new Spawn(300, 900);
            _zones.Add(zone3);
            Spawn zone4 = new Spawn(1500,900);
            _zones.Add(zone4);
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
                    foreach(Spawn element in _zones)
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
            UpdatePosition();
            Render();
        }
        /// <summary>
        /// Empecher la sortie de zone
        /// </summary>
        private void UpdatePosition()
        {
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

        }
        private void Render()
        {
            _game.Graphics.Clear(Color.LightGreen);
            _witch.Render(_game);
            for (int i = 0; i < _rocks.Count; i++)
            {
                _rocks[i].Render(_game);
            }
            for (int i = 0; i < _witch.Projectiles.Count; i++)
            {
                _witch.Projectiles[i].Render(_game);
            }
            foreach(Spawn zone in _zones)
            {
                zone.Render(_game);
            }
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
                    Projectil proUp = new Projectil(_witch.Rectangle.X, _witch.Rectangle.Y, 0, -2);
                    _witch.Projectiles.Add(proUp);
                    break;
                case Keys.Down:
                    Projectil proDown = new Projectil(_witch.Rectangle.X, _witch.Rectangle.Y, 0, 2);
                    _witch.Projectiles.Add(proDown);
                    break;
                case Keys.Right:
                    Projectil proRight = new Projectil(_witch.Rectangle.X, _witch.Rectangle.Y, 2, 0);
                    _witch.Projectiles.Add(proRight);
                    break;
                case Keys.Left:
                    Projectil proLeft = new Projectil(_witch.Rectangle.X, _witch.Rectangle.Y, -2, 0);
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
    }
}
