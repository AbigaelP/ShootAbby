using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class  Witch : GameElement
    {
        public List<Projectil> Projectiles = new List<Projectil>();

        /// <summary>
        /// Constructeur de la sorcière
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Witch(int x, int y) : base(x, y, 100, 100, 1000)
        {
            _image = Image.FromFile("Image/witch.png");
        }
        /// <summary>
        /// Empecher la sorcière de sortir de la map
        /// </summary>
        public void PreventOutside()
        {
            if (_rectangle.X < 0 )
            {
                _rectangle.X = 0;
            }
            if (_rectangle.X + _rectangle.Width > Game.WIDTH)
            {
                _rectangle.X = Game.WIDTH - _rectangle.Width;
            }
            if (_rectangle.Y < 0 )
            { 
                _rectangle.Y = 0;
            }
            if (_rectangle.Y + _rectangle.Height> Game.HEIGHT)
            {
                _rectangle.Y = Game.HEIGHT - _rectangle.Height;
            }
        }
        // TODO: héritage déplacement
        public void Move(int deplacementX, int deplacementY)
        {
            _rectangle.X += deplacementX;
            _rectangle.Y += deplacementY;
        }    
    }
}
