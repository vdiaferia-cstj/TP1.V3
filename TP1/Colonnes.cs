using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp01
{
    class Colonne
    {
        Case[] lesCases = new Case[6];


        public Colonne()
        {
            for (int i = 0; i < 6; i++)
            {
                lesCases[i] = new Case();
            }
        }

        public void Afficher(int nbDeColonnes)
        {


            for (int i = 0; i < 6; i++)
            {
                lesCases[i].Afficher(nbDeColonnes, i);
            }


        }

        public int RemplirUneCase(string symbole)
        {
            int numCase = 5;
            for (; numCase >= 0; numCase--)
            {
                if (caseVide(numCase))
                {

                    lesCases[numCase].Valeur = symbole;


                    break;

                }

            }
            return numCase;

        }

        public string valeurDeCase(int rangee)
        {
            string valeurDansCase;
            if (rangee <= 5 && rangee >= 0)
            {
                valeurDansCase = lesCases[rangee].Valeur;
                return valeurDansCase;

            }
            valeurDansCase = "";
            return valeurDansCase;
          
            
        }


        public bool caseVide(int rangee)
        {
            if (lesCases[rangee].Valeur == " ")
            {


                return true;
            }
            else
            {
                return false;
            }
        }
    }
}