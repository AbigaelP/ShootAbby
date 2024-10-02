using ShootAbby.Model;

namespace ShootAbby
{
    public partial class Game : Form
    {
        public static readonly int WIDTH = 1200;
        public static readonly int HEIGHT = 600;

        BufferedGraphicsContext _currentContext;
        BufferedGraphics _game;
        Witch _witch;
        Rock _rocher;
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
            _rocher = new Rock(105,20);
   
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
            _rocher.Render(_game);
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
                    _witch.X += -5;
                    break;
                case Keys.W:
                    _witch.Y += -5;
                    break;
                case Keys.S:
                    _witch.Y += 5;
                    break;
                case Keys.D:
                    _witch.X += 5;
                    break;
            }
        }
    }
}
