using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class Spawn
    {
        //le stylo nommée witchBush pour écrire dans l'affichage
        private Pen witchBrush = new Pen(new SolidBrush(Color.Orange), 3);

        /// <summary>
        /// Forme de la sorcière
        /// </summary>
        /// <param name="drawingGame"></param>
        public void Render(BufferedGraphics drawingGame)    //zone de dessin = Buffergraphics
        {
            drawingGame.Graphics.DrawRectangle(witchBrush, _rectangle);
        }
    }
}
