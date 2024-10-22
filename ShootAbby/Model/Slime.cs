using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Sensors;

namespace ShootAbby.Model
{
    public partial class Slime
    {
        private Rectangle _rectangle;
        private int _x;
        private int _y;
        private int _pv;

        public Rectangle Rectangle { get => _rectangle; set => _rectangle = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Pv { get => _pv; set => _pv = value; }

        public Slime(int x, int y)
        {
            _x = x;
            _y = y;
            _rectangle = new Rectangle(_x, _y, 50, 50);
            _pv = 5;
        }

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
        public bool IsTouching(Rectangle rectangle)
        {
            return _rectangle.IntersectsWith(rectangle);
        }
        /// <summary>
        /// Controle si le slime est mort
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
