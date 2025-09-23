using System;

namespace puissance4_Martins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nombreColonnes;
            int nombreLignes;

            Console.SetWindowPosition(0, 0);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowSize(200, 50);

            CreationEnTete();
            MenuDemarrage(out nombreColonnes, out nombreLignes);

            Console.Clear();

            CreationEnTete();
            var navigation = GenNavigation(1, nombreColonnes);
            var tableau = GenTableau(nombreColonnes, nombreLignes);
            Gameplay(tableau, navigation);
        }

        /// <summary>
        /// Fonction pour la création de l'en-tête
        /// </summary>
        static void CreationEnTete()
        {
            // Création de l'entête
            Console.WriteLine("\t╔════════════════════════════════════════╗\n\t║   Bienvenue dans le jeu Puissance 4    ║\n\t║   Réalisé par Diogo Martins\t\t ║");
            Console.WriteLine("\t╚════════════════════════════════════════╝");
            Console.WriteLine("");
        }
        /// <summary>
        /// Cette fonction sert à créer le menu principal du jeu
        /// </summary>
        /// <param name="nombreColonnes">Ressort le nombre de colonnes choisi</param>
        /// <param name="nombreLignes">Ressort le nombre de lignes choisi</param>
        /// <returns>Retourne le nombre de lignes et colonnes choisies par l'utilisateur</returns>
        static void MenuDemarrage(out int nombreColonnes, out int nombreLignes)
        {
            bool valeurOK;

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
        /// Création de la ligne de navigation pour le jeu
        /// </summary>
        /// <param name="ligne">Prend le param 1 pour definir une ligne</param>
        /// <param name="Colonnes">Prend la quantité de colonnes choisie</param>
        /// <returns>Retourne la ligne de navigation créée</returns>
        static char[,] GenNavigation(int ligne, int Colonnes)
        {
            char[,] barreNav = new char[ligne, Colonnes];

            // Boucle pour création des lignes avec boucle imbriquée pour création des colonnes
            for (int r = 0; r < ligne; r++)
            {
                for (int c = 0; c < Colonnes; c++)
                {
                    barreNav[r, c] = ' ';
                }
            }

            // Boucles pour affichage de la barre de navigation
            for (int r = 0; r < 1; r++)
            {
                //Ligne du haut
                for (int c = 0; c < Colonnes; c++)
                {
                    if (c == 0)
                    {
                        Console.Write("\t╔═════╦");
                    }
                    else if (c < Colonnes - 1)
                    {
                        Console.Write("═════╦");
                    }
                    else if (c < Colonnes)
                    {
                        Console.Write("═════╗");
                    }
                }

                Console.WriteLine();

                //Ligne du milieu
                for (int c = 0; c < Colonnes; c++)
                {
                    if (c == 0)
                    {
                        Console.Write("\t║  " + barreNav[r, c] + "  ");
                    }
                    else if (c < Colonnes - 1)
                    {
                        Console.Write("║  " + barreNav[r, c] + "  ");
                    }
                    else
                    {
                        Console.Write("║  " + barreNav[r, c] + "  ║");
                    }

                }

                Console.WriteLine();

                //Ligne du bas
                for (int c = 0; c < Colonnes; c++)
                {
                    {
                        if (c == 0)
                        {
                            Console.Write("\t╚═════╩");
                        }
                        else if (c < Colonnes - 1)
                        {
                            Console.Write("═════╩");
                        }
                        else
                        {
                            Console.Write("═════╝");
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            return barreNav;
        }
        /// <summary>
        /// Cette fonction permet la création et l'affichage du tableau
        /// </summary>
        /// <param name="Colonnes">Prend le nombre de colonnes de l'utilisateur</param>
        /// <param name="Lignes">Prend le nombre de lignes de l'utilisateur</param>
        /// <returns>Retourne le tableau créé</returns>
        static char[,] GenTableau(int Colonnes, int Lignes)
        {
            // Création d'un nouvel élement tableau
            char[,] tableau = new char[Lignes, Colonnes];

            // Boucle pour création des lignes avec boucle imbriquée pour création des colonnes
            for (int r = 0; r < Lignes; r++)
            {
                for (int c = 0; c < Colonnes; c++)
                {
                    tableau[r, c] = ' ';
                }
            }

            // Boucles pour affichage du tableau
            // Boucle pour la première ligne
            for (int r = 0; r < Lignes; r++)
            {
                for (int c = 0; c < Colonnes; c++)
                {
                    if (c == 0 && r == 0)
                    {
                        Console.Write("\t╔═════╦");
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

                // Boucle pour la ligne du milieu
                for (int c = 0; c < Colonnes; c++)
                {
                    if (c == 0)
                    {
                        Console.Write("\t║  " + tableau[r, c] + "  ");
                    }
                    else if (c < Colonnes - 1)
                    {
                        Console.Write("║  " + tableau[r, c] + "  ");
                    }
                    else
                    {
                        Console.Write("║  " + tableau[r, c] + "  ║");
                    }

                }

                Console.WriteLine();

                // Boucle pour la ligne du bas
                for (int c = 0; c < Colonnes; c++)
                {
                    if (r < Lignes - 1)
                    {
                        if (c == 0)
                        {
                            Console.Write("\t╠═════╬"); // bord gauche
                        }
                        else if (c == Colonnes - 1)
                        {
                            Console.Write("═════╣"); // bord droit
                        }
                        else
                        {
                            Console.Write("═════╬"); // milieux
                        }
                    }
                    else
                    {
                        if (c == 0)
                        {
                            Console.Write("\t╚═════╩"); // coin bas gauche
                        }
                        else if (c == Colonnes - 1)
                        {
                            Console.Write("═════╝"); // coin bas droit
                        }
                        else
                        {
                            Console.Write("═════╩"); // bas milieu
                        }
                    }
                }
            }

            // Calcul de la distance du tableau pour afficher le menu "Aide"
            int tableauLargeur = 8 * Colonnes;
            int offset = tableauLargeur + 10;

            // Création du menu "Aide"
            Console.SetCursorPosition(offset, 5);
            Console.Write("Mode d'utilisation");
            Console.WriteLine();
            Console.SetCursorPosition(offset, 6);
            Console.Write("-------------------");
            Console.WriteLine();
            Console.SetCursorPosition(offset + 3, 7);
            Console.Write("Déplacement\tTouches directionnelles");
            Console.WriteLine();
            Console.SetCursorPosition(offset + 3, 8);
            Console.Write("Tir\t\tSpacebar ou Enter");
            Console.WriteLine();
            Console.SetCursorPosition(offset + 3, 9);
            Console.Write("Quitter\t\tEscape");
            Console.WriteLine();
            Console.SetCursorPosition(offset + 3, 11);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Jouer 1: ■");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\t\tJoueur 2: ■ ");
            Console.ForegroundColor = ConsoleColor.White;

            return tableau;
        }
        static void Gameplay(char[,] tableau, char[,] barreNav)
        {
            tableau[0, 0] = 'X';
        }
    }
}
