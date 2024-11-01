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
        /// Afficher les éléments et leur point de vie
        /// </summary>
        /// <param name="drawingGame"></param>
        public void Render(BufferedGraphics drawingGame)    //zone de dessin = Buffergraphics
        {
            Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);

            drawingGame.Graphics.DrawImage(_image, Rectangle); //image propre au la classe du rectangle
            drawingGame.Graphics.DrawLine(droneBrush, new Point(Rectangle.X, Rectangle.Y), new Point(Rectangle.X + Pv/10, Rectangle.Y)); // barre des points de vie
        }
    }
}
