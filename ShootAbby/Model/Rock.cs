using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class Rock
    {
        private int _x;
        private int _y;
        private Rectangle _rectangle;
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public Rectangle Rectangle { get => _rectangle;}

        /// <summary>
        /// Constructeur du rocher
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Rock(int x, int y)
        {
            _x = x;
            _y = y;
            _rectangle = new Rectangle(X, Y, 50, 50);
        }
        public void PreventOutside()
        {
            if (X < 0)
            {
                X = 0;
            }
            if (X + 50 > Game.WIDTH)
            {
                X = Game.WIDTH - 50;
            }
            if (Y < 0)
            {
                Y = 0;
            }
            if (Y + 50 > Game.HEIGHT)
            {
                Y = Game.HEIGHT - 50;
            }
        }
        public bool IsTouching(Rectangle rectangle)
        {
            return this.Rectangle.IntersectsWith(rectangle);
        }
    }
}
