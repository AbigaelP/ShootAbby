using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Sensors;

namespace ShootAbby.Model
{
    public partial class Slime : GameElement
    {
        /// <summary>
        /// Constructeur du slime
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Slime(int x, int y) : base(x, y, 50, 50, 5)
        {
        }
        /// <summary>
        /// Déplacement du slime par rapoort a la position de la sorcière
        /// </summary>
        /// <param name="sorciere"></param>
        public void Move(Rectangle sorciere)
        {
            if (_rectangle.X < sorciere.X)
            {
                _rectangle.X += 1;
            }
            else if (_rectangle.X > sorciere.X)
            {
                _rectangle.X += -1;
            }
            if (_rectangle.Y < sorciere.Y)
            {
                _rectangle.Y += 1;
            }
            else if (_rectangle.Y > sorciere.Y)
            {
                _rectangle.Y += -1;
            }
        }
    }
}
