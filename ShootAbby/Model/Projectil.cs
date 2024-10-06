using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby
{
    public partial class Projectil
    {
        private int _deplacementX;   //déplacement selon axe x
        private int _deplacementY;   //déplacement selon axe y
        private Rectangle _rectangle;

        public Rectangle Rectangle { get => _rectangle; set => _rectangle = value; }
        public int DeplacementX { get => _deplacementX; set => _deplacementX = value; }
        public int DeplacementY { get => _deplacementY; set => _deplacementY = value; }

        public Projectil(int x, int y, int depX, int depY) 
        { 
            _deplacementX = depX;
            _deplacementY = depY;
            _rectangle = new Rectangle(x, y, 20, 20);
        }
        public void MoveProjectile()
        {
            _rectangle.X += _deplacementX;
            _rectangle.Y += _deplacementY;
        }
    }
}
