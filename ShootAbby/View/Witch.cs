using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby.Model
{
    public partial class Witch
    {
        //le stylo nommée witchBush pour écrire dans l'affichage
        private Pen witchBrush = new Pen(new SolidBrush(Color.Purple), 3);

        //forme de la sorcière
        public void Render(BufferedGraphics drawingGame)    //zone de dessin = Buffergraphics
        {
            drawingGame.Graphics.DrawRectangle(witchBrush, new Rectangle(_x, _y, 50, 50));
        }
    }
}
