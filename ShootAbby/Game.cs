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
            InitializeComponent();
            _currentContext = BufferedGraphicsManager.Current;
            _graphics = _currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            _witch = new Witch(400,200);
        }
        private void NewFrame(object sender, EventArgs e)
        {
            Console.WriteLine("c");
            Render();
        }

        private void Render()
        {
            _graphics.Graphics.Clear(Color.LightGreen);
            _witch.Render(_graphics);
            _graphics.Render();
            
        }
    }
}
