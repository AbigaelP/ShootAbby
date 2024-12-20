﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class  Witch : GameElement
    {
        public List<Projectil> Projectiles = new List<Projectil>();
        private int _numberOfProjectile = 10;


        public int NumberOfProjectile1 { get => _numberOfProjectile; set => _numberOfProjectile = value; }


        /// <summary>
        /// Constructeur de la sorcière
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Witch(int x, int y) : base(x, y, 100, 100, 1000)
        {
            _image = Image.FromFile("Image/witch.png");
            _rectangle = new Rectangle (x,y, 100, 100);
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
        /// <summary>
        /// Déplacement de la sorcière
        /// </summary>
        /// <param name="deplacementX"></param>
        /// <param name="deplacementY"></param>
        public void Move(int deplacementX, int deplacementY)
        {
            _rectangle.X += deplacementX;
            _rectangle.Y += deplacementY;
        }
        public void Fire(Direction direction)
        {
            if (_numberOfProjectile <= 0) return;
            Projectil projectil= new Projectil(0,0,0,0);
            switch (direction)
            {
                case Direction.DOWN:
                    projectil = new Projectil(this.Rectangle.X + 50, this.Rectangle.Y + 80, 0, 2);
                    break;
                case Direction.UP:
                    projectil = new Projectil(this.Rectangle.X + 50, this.Rectangle.Y +20, 0, -2);
                    break;
                case Direction.LEFT:
                    projectil = new Projectil(this.Rectangle.X +20, this.Rectangle.Y  +50, -2, 0);
                    break;
                case Direction.RIGHT:
                    projectil = new Projectil(this.Rectangle.X + 80 , this.Rectangle.Y + 50, 2, 0);
                    break;
            }
            this.Projectiles.Add(projectil);
            _numberOfProjectile --;

        }
    }
}
