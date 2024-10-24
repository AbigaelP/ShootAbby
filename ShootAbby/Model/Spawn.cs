using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class Spawn : GameElement
    {
        /// <summary>
        /// Constructeur de la zone de spawn
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Spawn(int x, int y) : base(x, y, 50, 50, 0)
        {
        }
    }
}
