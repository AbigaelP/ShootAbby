using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class  Witch
    {
        private int _x;
        private int _y;
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        
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
            
        }
        /// <summary>
        /// Empecher la sorcière de sortir de la map
        /// </summary>
        public void PreventOutside()
        {
            if (_x < 0 )
            {
                _x = 0;
            }
            if (_x + 50 > Game.HEIGHT)
            {
                _x = Game.HEIGHT -50;
            }
            if (_y < 0 )
            {
                _y = 0;
            }
            if (_y + 50 > Game.WIDTH)
            {
                _y = Game.WIDTH -50;
            }
        }

    }
}
