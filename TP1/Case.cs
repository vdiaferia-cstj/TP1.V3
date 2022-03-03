using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp01
{
    class Case
    {
        public string Valeur { get; set; }
        const int offsetX = 0;
        const int offsetY = 5;

        public Case()
        {
            Valeur = " ";
        }

        public void Afficher(int colonne, int rangee)
        {
            Console.SetCursorPosition(colonne * 4 + offsetX, rangee + offsetY);
          

         
                Console.Write(Valeur);
              
                Console.Write("_");
          
            
            if (colonne == 6)
            {
                Console.Write("|");
            }

        }

    }
}