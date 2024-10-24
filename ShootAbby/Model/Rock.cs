using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class Rock : GameElement
    {
        /// <summary>
        /// Constructeur du rocher
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Rock(int x, int y) : base(x, y, 50, 50, 0)
        {
            brush = new Pen(new SolidBrush(Color.Gray), 3);
        }
    }
}
