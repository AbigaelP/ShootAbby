using ShootAbby.Model;

namespace ShootAbby
{
    public partial class Game : Form
    {
        BufferedGraphicsContext _currentContext;
        BufferedGraphics _graphics;
        Witch _witch;
        public Game()
        {
            try
            {
                _witch = new Witch(600, 200);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ça va la tête ???");
            }
            InitializeComponent();
            _currentContext = BufferedGraphicsManager.Current;
            _graphics = _currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            //fluidifie le mouvement 
            ticker.Interval = 10;
        }
        private void NewFrame(object sender, EventArgs e)
        {
            Render();
        }
        private void Render()
        {
            _graphics.Graphics.Clear(Color.LightGreen);
            _witch.Render(_graphics);
            _graphics.Render();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PressKey(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);

            switch (e.KeyCode)
            {
                case Keys.A:
                    _witch.X += -1;
                    break;
                case Keys.W:
                    _witch.Y += -1;
                    break;
                case Keys.S:
                    _witch.Y += 1;
                    break;
                case Keys.D:
                    _witch.X += 1;
                    break;
            }
        }
    }
}
