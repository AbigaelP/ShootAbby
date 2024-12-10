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
        protected Pen pen;

        /// <summary>
        /// Afficher les éléments et leur point de vie
        /// </summary>
        /// <param name="drawingGame"></param>
        public void Render(BufferedGraphics drawingGame)    //zone de dessin = Buffergraphics
        {
            Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);
            Pen pen = new Pen (new SolidBrush(Color.Red), 3);

            drawingGame.Graphics.DrawImage(_image, Rectangle); //image propre au la classe du rectangle
            drawingGame.Graphics.DrawRectangle(pen, _rectangle); //image propre au la classe du rectangle
            int healthBarWidth = (int)((float)_pv / 1000 * _rectangle.Width); // Largeur de la barre de santé proportionnelle aux points de vie
            drawingGame.Graphics.FillRectangle(Brushes.Red, _rectangle.X, _rectangle.Y - 10, healthBarWidth, 5); // Barre de santé au-dessus de l'élément

        }
    }
}
