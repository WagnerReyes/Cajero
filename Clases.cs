using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cajero
{
    class Clases
    {
        public static void centraX(Control padre, Control hijo)
        {
            int x = 0;

            //un poco de matematicas, restando los anchos y dividiendo entre 2  
            x = (padre.Width / 2) - (hijo.Width / 2);

            //asignamos la nueva ubicación                                      
            hijo.Location = new System.Drawing.Point(x, hijo.Location.Y);
        }

        public static void centraXY(Control padre, Control hijo)
        {
            int x = 0;
            int y = 0;
            x = (padre.Width / 2) - (hijo.Width / 2);
            y = (padre.Height / 2) - (hijo.Height / 2);
            hijo.Location = new System.Drawing.Point(x, y);
        }
    }
}
