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
            if (X < 0 )
            {
                X = 0;
            }
            if (X + 50 > Game.HEIGHT)
            {
                X = Game.HEIGHT -50;
            }
            if (Y < 0 )
            {
                Y = 0;
            }
            if (Y + 50 > Game.WIDTH)
            {
                Y = Game.WIDTH -50;
            }
        }

    }
}
