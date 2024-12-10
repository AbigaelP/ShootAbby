using System;
using System.Collections.Generic;
using System.Drawing;
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
        public Slime(int x, int y) : base(x, y, 60, 50, 5)
        {
            _image = Image.FromFile("Image/slime.png");
        }
        /// <summary>
        /// Déplacement du slime par rapoort a la position de la sorcière
        /// </summary>
        /// <param name="sorciere"></param>
        public void Move(Rectangle sorciere)
        {
            if (_rectangle.X < sorciere.X + 25)
            {
                _rectangle.X += 1;
            }
            else if (_rectangle.X > sorciere.X - 25)
            {
                _rectangle.X += -1;
            }
            if (_rectangle.Y < sorciere.Y + 25)
            {
                _rectangle.Y += 1;
            }
            else if (_rectangle.Y > sorciere.Y - 25)
            {
                _rectangle.Y += -1;
            }
        }
        /// <summary>
        /// Déplacement du slime par rapoort a la position d'un rocher
        /// </summary>
        /// <param name="rock"></param>
        public void MoveBack(Rectangle rock)
        {
            if (_rectangle.X < rock.X)
            {
                _rectangle.X += -1;
            }
            else if (_rectangle.X > rock.X)
            {
                _rectangle.X += 1;
            }
            if (_rectangle.Y < rock.Y)
            {
                _rectangle.Y += -1;
            }
            else if (_rectangle.Y > rock.Y)
            {
                _rectangle.Y += 1;
            }
        }
    }
}
