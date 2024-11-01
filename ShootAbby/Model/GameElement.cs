using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class GameElement
    {
        //Attributs
        protected Image _image;
        protected Rectangle _rectangle;
        protected int _pv;
        //Propriétés
        public Rectangle Rectangle { get => _rectangle; set => _rectangle = value; }
        public int Pv { get => _pv; set => _pv = value; }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="pv"></param>
        public GameElement(int x, int y, int width, int height, int pv)
        {
            // if (x < 0 || y < 0 || x > 500 || y > 500) throw new Exception("GameElement is out of line!");
            _rectangle = new Rectangle(x - width/2, y - height/2, width, height);
            _pv = pv;
         
           // _image = Image.FromFile("Image/grass.png");
        }
        /// <summary>
        /// Controle si deux rectangle se touchent
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public bool IsTouching(Rectangle rectangle)
        {
            return _rectangle.IntersectsWith(rectangle);
        }
        /// <summary>
        /// Controle si la vie est supérieur à 0
        /// </summary>
        /// <returns></returns>
        public bool IsDead()
        {
            if (_pv > 0)
            {
                return false;
            }
            return true;
        }
    }
}

