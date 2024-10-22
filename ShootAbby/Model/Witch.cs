using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class  Witch
    {
        // TODO: mettre en place héritage pour ce qui touche au rectangle, les mouvements de déplacement , point de vie
        private int _x;
        private int _y;
        private Rectangle _rectangle;
        private int _pv;
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public Rectangle Rectangle { get => _rectangle; set => _rectangle = value; }
        public int Pv { get => _pv; set => _pv = value; }

        public List<Projectil> Projectiles = new List<Projectil>();

        /// <summary>
        /// Constructeur de la sorcière
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Witch(int x, int y)
        {
            // if (x < 0 || y < 0 || x > 500 || y > 500) throw new Exception("Witch is out of line!");
           _x = x;
           _y = y;
           _rectangle = new Rectangle(X, Y, 50, 50);
            _pv = 1000;


        }
        /// <summary>
        /// Empecher la sorcière de sortir de la map
        /// </summary>
        public void PreventOutside()
        {
            if (_rectangle.X < 0 )
            {
                _rectangle.X = 0;
            }
            if (_rectangle.X + _rectangle.Width > Game.WIDTH)
            {
                _rectangle.X = Game.WIDTH - _rectangle.Width;
            }
            if (_rectangle.Y < 0 )
            { 
                _rectangle.Y = 0;
            }
            if (_rectangle.Y + _rectangle.Height> Game.HEIGHT)
            {
                _rectangle.Y = Game.HEIGHT - _rectangle.Height;
            }
        }
        // TODO: héritage déplacement
        public void Move(int deplacementX, int deplacementY)
        {
            _rectangle.X += deplacementX;
            _rectangle.Y += deplacementY;
        }
        // TODO :
        public bool IsTouching(Rectangle rectangle)
        {
            return _rectangle.IntersectsWith(rectangle);
        }
        /// <summary>
        /// Controle si la sorcière n'a plus de point de vie
        /// </summary>
        /// <returns></returns>
        public bool IsDead() 
        {
            if (_pv > 0)
            {
                return false;
            }
            //Console.WriteLine("Vous êtes mort");
            return true;

        }
    }
}
