using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class BackGround : GameElement
    {
        /// <summary>
        /// Constructeur du background
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public BackGround(int x, int y) : base(x, y, 1800, 1200, 0)
        {
            _image = Image.FromFile("Image/background.jpg");
        }
    }
}
