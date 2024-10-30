using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class GameElement
    {
        //le stylo nommée brush pour écrire dans l'affichage
        protected Pen brush;

        /// <summary>
        /// Forme du rocher
        /// </summary>
        /// <param name="drawingGame"></param>
        public void Render(BufferedGraphics drawingGame)    //zone de dessin = Buffergraphics
        {
            Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);

            drawingGame.Graphics.DrawImage(_image, Rectangle);
            drawingGame.Graphics.DrawLine(droneBrush, new Point(Rectangle.X, Rectangle.Y), new Point(Rectangle.X + Pv/10, Rectangle.Y));
        }
    }
}
