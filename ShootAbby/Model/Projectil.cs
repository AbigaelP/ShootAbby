using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class Projectil : GameElement
    {
        private int _deplacementX;   //déplacement selon axe x
        private int _deplacementY;   //déplacement selon axe y
        /// <summary>
        /// Constructeur du projectile
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="depX"></param>
        /// <param name="depY"></param>
        public Projectil(int x, int y, int depX, int depY) : base(x, y, 20, 20, 1)
        {
            _deplacementX = depX;
            _deplacementY = depY;
            _image = Image.FromFile("Image/projectil.png");
        }
        /// <summary>
        /// Déplacement du projectile
        /// </summary>
        public void MoveProjectile()
        {
            _rectangle.X += _deplacementX;
            _rectangle.Y += _deplacementY;
        }
        /// <summary>
        /// Controle si le projectile est toujours dans l'écran
        /// </summary>
        /// <returns></returns>
        public bool IsInside()
        {
            bool result = true;
            if (_rectangle.X + _rectangle.Width < 0)
            {
                result = false;
            }
            if (_rectangle.X > Game.WIDTH)
            {
                result = false;
            }
            if (_rectangle.Y > Game.HEIGHT)
            {
                result = false;
            }
            if (_rectangle.Y + _rectangle.Height < 0)
            {
                result = false;
            }
            return result;
        }
    }
}
