using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp01
{
    class Grille
    {
        Colonne[] colonnes = new Colonne[7];

        public Grille()
        {
            for (int i = 0; i < 7; i++)
            {
                colonnes[i] = new Colonne();
            }
        }
        public void Afficher()
        {
            Console.SetCursorPosition(0, 5);


            for (int i = 0; i < 7; i++)
            {
                colonnes[i].Afficher(i);
            }
        }

        public int JouerSonTour(string symbole, string choix)
        {
            int numRangee = 0;
            int numColonne = 0;
            int prochainTour = 0;
            int coupGagnant = 1;
            int colPleine = 2;
            switch (choix)
            {
                case "A":

                    if (!colonneEstPleine(0))
                    {
                        numRangee = colonnes[0].RemplirUneCase(symbole);
                        numColonne = 0;
                        Afficher();
                        break;
                    }
                    else
                        return colPleine;
                    
                case "a":
                    numRangee = colonnes[0].RemplirUneCase(symbole);
                    numColonne = 0;
                    Afficher();

                    break;
                case "B":

                    numRangee = colonnes[1].RemplirUneCase(symbole);
                    numColonne = 1;
                    Afficher();
                    break;
                case "b":

                    numRangee = colonnes[1].RemplirUneCase(symbole);
                    numColonne = 1;
                    Afficher();

                    break;
                case "C":
                    numRangee = colonnes[2].RemplirUneCase(symbole);
                    numColonne = 2;
                    Afficher();
                    break;
                case "c":
                    numRangee = colonnes[2].RemplirUneCase(symbole);
                    numColonne = 2;
                    Afficher();
                    break;
                case "D":
                    numRangee = colonnes[3].RemplirUneCase(symbole);
                    numColonne = 3;
                    Afficher();
                    break;
                case "d":
                    numRangee = colonnes[3].RemplirUneCase(symbole);
                    numColonne = 3;
                    Afficher();
                    break;
                case "E":
                    numRangee = colonnes[4].RemplirUneCase(symbole);
                    numColonne = 4;
                    Afficher();
                    break;
                case "e":
                    numRangee = colonnes[4].RemplirUneCase(symbole);
                    numColonne = 4;
                    Afficher();
                    break;
                case "F":
                    numRangee = colonnes[5].RemplirUneCase(symbole);
                    numColonne = 5;
                    Afficher();
                    break;
                case "f":
                    numRangee = colonnes[5].RemplirUneCase(symbole);
                    numColonne = 5;
                    Afficher();
                    break;
                case "G":
                    numRangee = colonnes[6].RemplirUneCase(symbole);
                    numColonne = 6;
                    Afficher();
                    break;
                case "g":
                    numRangee = colonnes[6].RemplirUneCase(symbole);
                    numColonne = 6;
                    Afficher();
                    break;

            }
            
           
            if (conditionGagnante(numColonne, numRangee, symbole))
            {
                return coupGagnant;
            }

           
            return prochainTour;

        }
        public bool colonneEstPleine (int numColonne)
        {
            if (colonnes[numColonne].valeurDeCase(0) != " ")
            {
                return true;
            }

            return false;
        }
        public bool conditionGagnante(int numColonne, int numRangee, string symbole)
        {
            
            if (   gagnerVerticalement(numColonne, numRangee) 
                || gagnerHorizontalement(numColonne,numRangee) 
                || gagnerDiagonalementHaut(numColonne,numRangee) 
                || gagnerDiagonalementBas(numColonne, numRangee))
                return true;
            else             
                return false;         
        } 

        public bool gagnerVerticalement(int colonneJouee, int rangeesJouees)
        {
            string symbole;
            symbole = colonnes[colonneJouee].valeurDeCase(rangeesJouees);
            
            if (rangeesJouees <= 2 
                && colonnes[colonneJouee].valeurDeCase(rangeesJouees + 1) == symbole 
                && colonnes[colonneJouee].valeurDeCase(rangeesJouees + 2) == symbole 
                && colonnes[colonneJouee].valeurDeCase(rangeesJouees + 3) == symbole)
            {
                Console.WriteLine("\nLe joueur {0} à gagné verticalement!", symbole);
                Console.ReadKey();
                return true;

            }
            else
            {
                return false;
            } 
        }

        public bool gagnerHorizontalement(int colonnesJouees, int rangeeJouee)
        {
            string symbole;
            symbole = colonnes[colonnesJouees].valeurDeCase(rangeeJouee);
           
            if (colonnesJouees <= 2
                && colonnes[colonnesJouees + 1].valeurDeCase(rangeeJouee) == symbole
                && colonnes[colonnesJouees + 2].valeurDeCase(rangeeJouee) == symbole
                && colonnes[colonnesJouees + 3].valeurDeCase(rangeeJouee) == symbole)
            {
                Console.WriteLine("\nLe joueur {0} à gagné horizontalement!", symbole);
                Console.ReadKey();
                return true;

            }
            
            if (colonnesJouees == 3 && 
                 ( (colonnes[colonnesJouees + 1].valeurDeCase(rangeeJouee) == symbole
                && colonnes[colonnesJouees + 2].valeurDeCase(rangeeJouee) == symbole
                && colonnes[colonnesJouees + 3].valeurDeCase(rangeeJouee) == symbole) 
                || 
                   (colonnes[colonnesJouees - 1].valeurDeCase(rangeeJouee) == symbole
                && colonnes[colonnesJouees - 2].valeurDeCase(rangeeJouee) == symbole
                && colonnes[colonnesJouees - 3].valeurDeCase(rangeeJouee) == symbole)) )
            {
                Console.WriteLine("\nLe joueur {0} à gagné horizontalement!", symbole);
                Console.ReadKey();
                return true;

            }
            if (colonnesJouees >= 4
                && colonnes[colonnesJouees - 1].valeurDeCase(rangeeJouee) == symbole
                && colonnes[colonnesJouees - 2].valeurDeCase(rangeeJouee) == symbole
                && colonnes[colonnesJouees - 3].valeurDeCase(rangeeJouee) == symbole)
            {
                Console.WriteLine("\nLe joueur {0} à gagné horizontalement!", symbole);
                Console.ReadKey();
                return true;

            }
            
            else
            {
                return false;
            }
        }
     
           public bool gagnerDiagonalementHaut(int colonnesJouee, int rangeeJouee)
           {
           string symbole;
            symbole = colonnes[colonnesJouee].valeurDeCase(rangeeJouee);

            if (colonnesJouee <= 3 
                && rangeeJouee >= 3  
                &&(colonnes[colonnesJouee + 1].valeurDeCase(rangeeJouee - 1) == symbole
                && colonnes[colonnesJouee + 2].valeurDeCase(rangeeJouee - 2) == symbole
                && colonnes[colonnesJouee + 3].valeurDeCase(rangeeJouee - 3) == symbole))
            {
                Console.WriteLine("\nLe joueur {0} à gagné diagonalement!", symbole);
                Console.ReadKey();
                return true;

            } 
            if (colonnesJouee >= 3 
                && rangeeJouee >= 3
                &&(colonnes[colonnesJouee + -1].valeurDeCase(rangeeJouee - 1) == symbole
                && colonnes[colonnesJouee + -2].valeurDeCase(rangeeJouee - 2) == symbole
                && colonnes[colonnesJouee + -3].valeurDeCase(rangeeJouee - 3) == symbole)
                )
            {
                Console.WriteLine("\nLe joueur {0} à gagné diagonalement!", symbole);
                Console.ReadKey();
                return true;

            }
            else
            {
               
                return false;
            }
        }
        
           public bool gagnerDiagonalementBas(int colonnesJouee, int rangeeJouee)
           {
            string symbole;
            symbole = colonnes[colonnesJouee].valeurDeCase(rangeeJouee);

            if (colonnesJouee <= 3
                && rangeeJouee <= 2
                && (colonnes[colonnesJouee + 1].valeurDeCase(rangeeJouee + 1) == symbole
                && colonnes[colonnesJouee + 2].valeurDeCase(rangeeJouee + 2) == symbole
                && colonnes[colonnesJouee + 3].valeurDeCase(rangeeJouee + 3) == symbole))
            {
                Console.WriteLine("\nLe joueur {0} à gagné diagonalement!", symbole);
                Console.ReadKey();
                return true;

            }
            if (colonnesJouee >= 3
                && rangeeJouee <= 2
                && (colonnes[colonnesJouee  - 1].valeurDeCase(rangeeJouee + 1) == symbole
                && colonnes[colonnesJouee  - 2].valeurDeCase(rangeeJouee + 2) == symbole
                && colonnes[colonnesJouee  - 3].valeurDeCase(rangeeJouee + 3) == symbole)
                )
            {
                Console.WriteLine("\nLe joueur {0} à gagné diagonalement!", symbole);
                Console.ReadKey();
                return true;

            }
            else
            {

                return false;
            }
        }
   
    }
}