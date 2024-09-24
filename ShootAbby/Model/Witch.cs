using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    internal partial class  Witch
    {
        private int _x;
        private int _y;
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        
        //constructeur de sorcière
        public Witch(int x, int y)
        {
           _x = x;
           _y = y;
        }

    }
}
