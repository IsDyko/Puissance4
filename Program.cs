using System;

namespace puissance4_Martins
{
    internal class Program
    {
        static int joueurActif = 1;

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

            var navigation = GenNavigation(nombreColonnes, 1);
            // Creation du tableau
            var tableau = new char[nombreLignes, nombreColonnes];
            // Initialisation du tableau
            for (int r = 0; r < nombreLignes; r++)
                for (int c = 0; c < nombreColonnes; c++)
                    tableau[r, c] = ' ';

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
        static char[,] GenNavigation(int Colonnes, int navCol)
        {

            // Délimitation du tableau pour empêcher les sorties du tableau et l'erreur OutOfRange
            if (navCol < 0) navCol = 0;
            if (navCol >= Colonnes) navCol = Colonnes - 1;

            // Initialisation de la barre de navigation
            char[,] barreNav = new char[1, Colonnes];

            // Boucle pour création des lignes avec boucle imbriquée pour création des colonnes
            for (int r = 0; r < 1; r++)
            {
                for (int c = 0; c < Colonnes; c++)
                {
                    barreNav[0, c] = ' ';
                }
            }

            // Initialisation du pion
            barreNav[0, navCol] = '■';

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
                        Console.Write("\t║  ");
                        if (joueurActif == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(barreNav[r, c]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("  ");
                    }
                    else if (c < Colonnes - 1)
                    {
                        Console.Write("║  ");
                        if (joueurActif == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(barreNav[r, c]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write("║  ");
                        if (joueurActif == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(barreNav[r, c]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("  ║");
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
        static void GenTableau(char[,] tableau)
        {
            int Lignes = tableau.GetLength(0);
            int Colonnes = tableau.GetLength(1);

            for (int r = 0; r < Lignes; r++)
            {
                // Ligne du haut
                for (int c = 0; c < Colonnes; c++)
                {
                    if (c == 0 && r == 0)
                        Console.Write("\t╔═════╦");
                    else if (r == 0 && c < Colonnes - 1)
                        Console.Write("═════╦");
                    else if (r == 0 && c < Colonnes)
                        Console.Write("═════╗");
                }

                Console.WriteLine();

                // Ligne du milieu
                for (int c = 0; c < Colonnes; c++)
                {
                    if (c == 0) Console.Write("\t║  ");
                    else Console.Write("║  ");

                    char pion = tableau[r, c];

                    if (pion == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("■");
                        Console.ResetColor();
                        Console.Write("  ");
                    }
                    else if (pion == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("■");
                        Console.ResetColor();
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }

                    if (c == Colonnes - 1) Console.Write("║");
                }
                Console.WriteLine();

                // Ligne du bas
                for (int c = 0; c < Colonnes; c++)
                {
                    if (r < Lignes - 1)
                    {
                        if (c == 0) Console.Write("\t╠═════╬");
                        else if (c == Colonnes - 1) Console.Write("═════╣");
                        else Console.Write("═════╬");
                    }
                    else
                    {
                        if (c == 0) Console.Write("\t╚═════╩");
                        else if (c == Colonnes - 1) Console.Write("═════╝");
                        else Console.Write("═════╩");
                    }
                }
            }

            // Menu aide
            MenuAide(Colonnes);
        }

        /// <summary>
        /// Création du menu aide à coté du tableau
        /// </summary>
        /// <param name="Colonnes">Prend le nombre de colonnes choisi par l'utilisateur</param>
        static void MenuAide(int Colonnes)
        {
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
        }
        static bool DeposePiece(int joueurActif, char[,] tableau, int col)
        {
            int lignes = tableau.GetLength(0);
            int colonnes = tableau.GetLength(1);

            if (col < 0 || col >= colonnes)
                return false;

            for (int r = lignes - 1; r >= 0; r--)
            {
                if (tableau[r, col] == ' ')
                {
                    tableau[r, col] = (joueurActif == 1) ? 'X' : 'O';
                    return true;
                }
            }
            return false;
        }
        static void Gameplay(char[,] tableau, char[,] barreNav)
        {
            int lignes = tableau.GetLength(0);
            int colonnes = tableau.GetLength(1);
            int navCol = 0;
            Console.Clear();

            CreationEnTete();

            int navTop = Console.CursorTop;
            GenNavigation(colonnes, navCol);
            int tableauTop = Console.CursorTop;
            GenTableau(tableau);

            while (true)
            {
                var key = Console.ReadKey(intercept: true).Key;

                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        if (navCol < colonnes - 1)
                        {
                            navCol++;
                        }
                        Console.SetCursorPosition(0, navTop);
                        GenNavigation(colonnes, navCol);
                        break;

                    case ConsoleKey.LeftArrow:
                        if (navCol > 0)
                        {
                            navCol--;
                        }
                        Console.SetCursorPosition(0, navTop);
                        GenNavigation(colonnes, navCol);
                        break;

                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (navCol < 0)
                        {
                            navCol = 0;
                        }
                        if (navCol >= colonnes)
                        {
                            navCol = colonnes - 1;
                        }
                        if (DeposePiece(joueurActif, tableau, navCol))
                        {
                            joueurActif = (joueurActif == 1) ? 2 : 1;
                        }
                        Console.SetCursorPosition(0, navTop);
                        GenNavigation(colonnes, navCol);
                        Console.SetCursorPosition(0, tableauTop);
                        GenTableau(tableau);
                        break;

                    case ConsoleKey.Escape:
                        return;
                }

            }
        }
    }
}
