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
            ///
            ///Création des crocher
            ///
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

        }
        private void Render()
        {
            _game.Graphics.Clear(Color.LightGreen);
            _witch.Render(_game);
            for (int i = 0; i < _rocks.Count; i++)
            {
                _rocks[i].Render(_game);
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
