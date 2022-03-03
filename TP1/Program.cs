using System;
using System.Text;
using System.Threading;

namespace Tp01
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quitter = false;
            // Si l'utilisateur gagne, aGagner deviendrait vrai et repartira une nouvelle grille
            bool aGagner = false;
            // le symbole de base est X
            string symbole = "X";
            // créer une nouvelle grille à l'ouverture du programme
            Grille grille = new Grille();
            Console.Clear();




            while (!quitter) // boucle infinie
            {
                Console.Clear(); // Efface ce qui était afficher sur l'écran auparavant
                AfficherEntete(); // Affiche l'entête
                grille.Afficher(); // Appel la fonction afficher de grille, ce qui affiche la grille
                // Ici c'est pour afficher le symbole en une couleur
                AfficherSymboleCouleur(symbole);


                string choix = Choix(); // Retourne la valeur de choix  en appelant la fonction choix
                aGagner = grille.JouerSonTour(symbole, choix); //Appel jouer son tour. Si l'utilisateur à gagner, aGagner deviendra vrai
                if (aGagner) // Si l'utilisateur à une condition gagnante
                {
                    string veuxRejouer;
                    Console.Clear();
                    Console.WriteLine("La partie est terminée. Souhaitez-vous continuer à jouer? Y/N");
                    veuxRejouer = Console.ReadLine();
                    if (veuxRejouer == "Y" || veuxRejouer == "y")
                    {
                        grille = new Grille();  // Recréer une nouvelle grille, donc c'est comme si la partie recommencerait

                    }
                    else
                    {
                        quitter = true;
                    }
                }

                // Pour changer le symbole à chaque tour
                if (symbole == "X")
                {
                   
                    symbole = "O";
                }
                else
                {
                   
                    symbole = "X";
                }
            }
        }


        /// <summary>
        /// Affiche l'entête au dessus du jeu
        /// </summary>
        static void AfficherEntete()
        {
            Console.SetCursorPosition(0, 0); // Met le curseur à 0 de X et 0 de Y
            Console.Write("------------ CONNECT 4 ------------\n ");
            Console.Write("Par Vincent Diaferia \n");
            Console.Write("----------------------------------- \n");
            Console.Write("  A   B   C   D   E   F   G\n");
        }

        /// <summary>
        /// Pour afficher le symbole du joueur en couleur
        /// Rouge pour X et jaune pour 0
        /// </summary>
        /// <param name="symbole"></param>
        static void AfficherSymboleCouleur(string symbole)
        {
            if (symbole == "X")
            {
                Console.Write("\nAu ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("{0} ", symbole);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("de jouer\n");
            }
            else
            {
                Console.Write("\nAu ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0} ", symbole);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("de jouer\n");
            }
        }
        /// <summary>
        /// Pour faire un choix dans le jeu
        /// </summary>
        /// <returns></returns>
        static string Choix()
        {
            Console.WriteLine("Veuillez entrer la lettre de la colonne :");
            return Console.ReadLine();
        }
    }
}