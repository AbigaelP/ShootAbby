using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class GameElement
    {
        protected Image _image;
        protected Rectangle _rectangle;
        protected int _pv;
        public Rectangle Rectangle { get => _rectangle; set => _rectangle = value; }
        public int Pv { get => _pv; set => _pv = value; }

        public GameElement(int x, int y, int width, int height, int pv)
        {
            // if (x < 0 || y < 0 || x > 500 || y > 500) throw new Exception("GameElement is out of line!");
            _rectangle = new Rectangle(x, y, width, height);
            _pv = pv;
         
            _image = Image.FromFile("Image/grass.png");
        }

        public bool IsTouching(Rectangle rectangle)
        {
            return _rectangle.IntersectsWith(rectangle);
        }

        public bool IsDead()
        {
            if (_pv > 0)
            {
                return false;
            }
            return true;
        }
    }
}

