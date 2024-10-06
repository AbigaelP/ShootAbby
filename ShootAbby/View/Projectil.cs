using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class Projectil
    {
        //le stylo nommée witchBush pour écrire dans l'affichage
        private Pen witchBrush = new Pen(new SolidBrush(Color.Black), 3);

        /// <summary>
        /// Forme du rocher
        /// </summary>
        /// <param name="drawingGame"></param>
        public void Render(BufferedGraphics drawingGame)    //zone de dessin = Buffergraphics
        {
            drawingGame.Graphics.DrawRectangle(witchBrush, Rectangle);
        }
    }
}
