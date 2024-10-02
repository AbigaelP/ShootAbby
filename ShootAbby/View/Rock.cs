using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class Rock
    {   
        //le stylo nommée witchBush pour écrire dans l'affichage
        private Pen witchBrush = new Pen(new SolidBrush(Color.Gray), 3);

        /// <summary>
        /// Forme du rocher
        /// </summary>
        /// <param name="drawingGame"></param>
        public void Render(BufferedGraphics drawingGame)    //zone de dessin = Buffergraphics
        {
            drawingGame.Graphics.DrawRectangle(witchBrush, new Rectangle(X, Y, 25, 25));
        }
    }
}
