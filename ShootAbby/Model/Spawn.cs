using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class Spawn
    {
        private int _x;
        private int _y;
        private Rectangle _rectangle = new Rectangle();

        public Spawn(int x, int y)
        {
            _x = x;
            _y = y;
            _rectangle = new Rectangle(_x,_y, 50,50);
        }

        public Rectangle Rectangle { get => _rectangle; set => _rectangle = value; }
    }
}
