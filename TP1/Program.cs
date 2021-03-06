using System;
using System.Text;
using System.Threading;

namespace Tp01
{
    class Program
    {
        private static bool quitter = false;
        private static bool recommencer = false;
        static void Main(string[] args)
        {
           
            // Si l'utilisateur gagne, aGagner deviendrait vrai et repartira une nouvelle grille
            int statut;
            bool colonnePleine;
            int coupDansTableau =0;
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
                while (!(choix == "A" || choix == "a" || choix == "B" || choix == "b" 
                      || choix == "C" || choix == "c" || choix == "D" || choix == "d"
                      || choix == "E" || choix == "e" || choix == "F" || choix == "f"
                      || choix == "G" || choix == "g"))
                {
                    Console.WriteLine("Erreur: Veuillez entrer une colonne valide.");
                    choix = Choix();
                }
                statut = grille.JouerSonTour(symbole, choix); //Appel jouer son tour. Si l'utilisateur à gagner, aGagner deviendra vrai
                colonnePleine = FinDeCoup(statut);
                if (recommencer)
                {
                    grille = new Grille();
                }
                // Pour changer le symbole à chaque tour
                if (!colonnePleine)
                {
                    if (symbole == "X")
                    {

                        symbole = "O";
                    }
                    else
                    {

                        symbole = "X";
                    }
                }
                coupDansTableau++;
                if (coupDansTableau == 42 )
                {
                    FinDeCoup(1);
                    grille = new Grille(); // Recréer une nouvelle grille, donc c'est comme si la partie recommencerait
                    coupDansTableau = 0;
                }
            }
        }
        static bool FinDeCoup(int statut)
        {
            string choix;
            if (statut == 1) // Si l'utilisateur à une condition gagnante ou partie nulle
            {
                string veuxRejouer;
                Console.Clear();
                Console.WriteLine("La partie est terminée. Souhaitez-vous continuer à jouer? Y/N");
                veuxRejouer = Console.ReadLine();
                if (veuxRejouer == "Y" || veuxRejouer == "y")
                {
                    recommencer = true;
                    return false;
                }
                else
                {
                    quitter = true;
                    return false;
                }
            }
            if (statut == 2) // Si la colonne est pleine
            {
                Console.WriteLine("Erreur: La colonne est pleine. Veuillez choisir une autre colonne.");
                choix = Choix();
                return true;
            }
            return false;
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