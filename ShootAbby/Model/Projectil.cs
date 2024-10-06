using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby
{
    public partial class Projectil
    {
        private int _x;              //position axe x
        private int _y;              //position axe y
        private int _deplacementX;   //déplacement selon axe x
        private int _deplacementY;   //déplacement selon axe y
        private Rectangle _rectangle;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public Rectangle Rectangle { get => _rectangle; set => _rectangle = value; }
        public int DeplacementX { get => _deplacementX; set => _deplacementX = value; }
        public int DeplacementY { get => _deplacementY; set => _deplacementY = value; }

        public Projectil(int x, int y, int depX, int depY) 
        { 
            _x = x;
            _y = y;
            _deplacementX = depX;
            _deplacementY = depY;
            _rectangle = new Rectangle(X, Y, 20, 20);
        }
    }
}
