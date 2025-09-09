using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puissance4_Martins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nombreColonnes;
            int nombreLignes;
            MenuDemarrage(out nombreColonnes, out nombreLignes);
            genTableau(nombreColonnes, nombreLignes);
        }

        /// <summary>
        /// Cette fonction sert à créer le menu principal du jeu
        /// </summary>
        /// <param name="nombreColonnes"></param>
        /// <param name="nombreLignes"></param>
        static void MenuDemarrage(out int nombreColonnes, out int nombreLignes)
        {
            bool valeurOK;

            // Création de l'entête
            Console.WriteLine("\t╔════════════════════════════════════════╗\n\t║   Bienvenue dans le jeu Puissance 4    ║\n\t║   Réalisé par Diogo Martins\t\t ║");
            Console.WriteLine("\t╚════════════════════════════════════════╝");
            Console.WriteLine("");

            //Nombre de lignes
            Console.Write("\tMerci d'entrer le nombre de lignes\n \tLa valeur doit être plus grande que ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" et plus petite que ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(13);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\tVotre valeur: ");

            // Vérification de la première valeur
            do
            {
                valeurOK = int.TryParse(Console.ReadLine(), out nombreLignes);

                if (!valeurOK)
                {
                    Console.WriteLine("\tVotre valeur n'est pas un nombre ! Merci de réessayer !");
                    Console.Write("\tVotre valeur: ");
                }
                else if (nombreLignes < 5 || nombreLignes > 13)
                {
                    Console.WriteLine("\tVotre valeur n'est pas dans les limites fixées > 5 et < 13. Merci de réessayer !");

                    do
                    {
                        Console.Write("\tVotre valeur: ");
                        valeurOK = int.TryParse(Console.ReadLine(), out nombreLignes);

                        // Verification si c'est un chiffre ou pas la prochaine qu'on presse
                        if (!valeurOK)
                        {
                            Console.WriteLine("\tVotre valeur n'es pas un chiffre. Réessayez");
                            continue;
                        }

                        // Verification si c'est dans les limites la prochaine fois qu'on presse
                        if (nombreLignes < 5 || nombreLignes > 13)
                        {
                            Console.WriteLine("\tVotre valeur n'est pas dans les limites fixées > 5 et < 13, Merci de réessayer !");
                        }
                    }
                    while (nombreLignes < 5 || nombreLignes > 13 || !valeurOK);
                }
            }
            while (!valeurOK);

            // Nombre colonnes
            Console.Write("\tMerci d'entrer le nombre de colonnes\n \tLa valeur doit être plus grande que ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(6);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" et plus petite que ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(16);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\tVotre valeur: ");

            // Vérification nombre colonnes
            do
            {
                valeurOK = int.TryParse(Console.ReadLine(), out nombreColonnes);

                if (!valeurOK)
                {
                    Console.WriteLine("\tVotre valeur n'est pas un nombre ! Merci de réessayer !");
                    Console.Write("\tVotre valeur: ");
                }
                else if (nombreColonnes < 6 || nombreColonnes > 16)
                {
                    Console.WriteLine("\tVotre valeur n'est pas dans les limites fixées > 6 et < 16. Merci de réessayer !");

                    do
                    {
                        Console.Write("\tVotre valeur: ");
                        valeurOK = int.TryParse(Console.ReadLine(), out nombreColonnes);

                        if (!valeurOK)
                        {
                            Console.WriteLine("\tVotre valeur n'es pas un chiffre. Réessayez");
                            continue;
                        }
                        if (nombreColonnes < 6 || nombreColonnes > 16)
                        {
                            Console.WriteLine("\tVotre valeur n'est pas dans les limites fixées > 6 et < 16, Merci de réessayer !");
                        }
                    }
                    while (nombreColonnes < 6 || nombreColonnes > 16 || !valeurOK);
                }
            }
            while (!valeurOK);
        }

        /// <summary>
        /// Cette fonction permet la création et l'affichage du tableau
        /// </summary>
        /// <param name="Colonnes"></param>
        /// <param name="Lignes"></param>
        static void genTableau(int Colonnes, int Lignes)
        {
            // Création d'un nouvel élement tableau
            char[,] tableau = new char[Lignes, Colonnes];

            // Boucle pour création des lignes avec boucle imbriquée pour création des colonnes
            for (int r = 0; r < Lignes; r++)
            {
                for (int c = 0; c < Colonnes; c++)
                {
                    tableau[r, c] = '.';
                }
            }

            // Boucles pour affichage du tableau
            for (int r = 0; r < Lignes; r++)
            {
                for (int c = 0; c < Colonnes; c++)
                {
                    if (c == 0 && r == 0)
                    {
                        Console.Write("╔═════╦");
                    }
                    else if (r == 0 && c < Colonnes - 1)
                    {
                        Console.Write("═════╦");
                    }
                    else if (r == 0 && c < Colonnes)
                    {
                        Console.Write("═════╗");
                    }
                }
                Console.WriteLine();
                for (int c = 0; c< Colonnes; c++)
                {
                    Console.Write("║  " + tableau[r, c] + "  ");
                }
                Console.WriteLine();
                for(int c = 0; c < Colonnes; c++)
                {
                    if (c == 0 && r < Lignes - 1)
                    {
                        Console.Write("╠═════╬");
                    }
                    else if (c > 0 && r < Lignes - 1)
                    {
                        Console.Write("═════╬");
                    }
                    else if (c == 0)
                    {
                        Console.Write("╚═════╩");
                    }
                    else
                    {
                        Console.Write("═════╩");
                    }
                }
            };
        }
    }
}
