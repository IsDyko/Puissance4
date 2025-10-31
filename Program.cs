// ETML
// Créé par : Diogo Martins
// Application en mode console du jeu Puissance 4

using System;
using System.Diagnostics;

namespace puissance4_Martins
{
	internal class Program
	{
		// Limites autorisées pour la taille du plateau. Ces bornes servent à valider les entrées utilisateur.
		// Les valeurs sont choisies pour conserver un affichage aligné en console avec votre "grille ASCII".
		const int MIN_LIGNES = 5;   // Nombre minimal de lignes du plateau
		const int MAX_LIGNES = 13;  // Nombre maximal de lignes du plateau
		const int MIN_COLONNES = 6; // Nombre minimal de colonnes du plateau
		const int MAX_COLONNES = 16;// Nombre maximal de colonnes du plateau

		// Dimensions de la fenêtre console. Utilisé pour offrir un espace suffisant à l’affichage du plateau et du menu d’aide.
		const int LARGEUR_FENETRE = 200;
		const int HAUTEUR_FENETRE = 50;

		// Paramètres d’affichage. Permettent de calculer l’offset pour placer proprement le menu d’aide.
		const int LARGEUR_COLONNE_AFFICHAGE = 8; // Largeur d’une cellule "ASCII" dans la grille
		const int OFFSET_AIDE = 10;              // Décalage horizontal entre la grille et le panneau d’aide

		// Symboles de jeu
		const char CASE_VIDE = ' '; // Contenu d’une case vide dans le tableau logique
		const char PION_JOUEUR1 = 'X';
		const char PION_JOUEUR2 = 'O';
		const char CURSEUR = '■';   // Curseur de navigation en haut, dans la barre

		// Palette de couleurs pour distinguer les joueurs et réinitialiser le texte
		const ConsoleColor COULEUR_JOUEUR1 = ConsoleColor.Red;
		const ConsoleColor COULEUR_JOUEUR2 = ConsoleColor.Yellow;
		const ConsoleColor COULEUR_TEXTE = ConsoleColor.White;

		// État global minimal de la partie.
		static int joueurActif = 1; // 1 ou 2
		static bool partie = true; // Vrai tant que l’application doit continuer d’enchaîner des parties

		static void Main(string[] args)
		{
			// Boucle générale qui permet d’enchaîner plusieurs parties tant que "partie" reste vrai.
			do
			{
				Console.CursorVisible = false; // Masque le curseur pour un rendu plus propre
				Console.Clear();

				int nombreColonnes;
				int nombreLignes;

				// Prépare la fenêtre console pour l’affichage large
				Console.SetWindowPosition(0, 0);
				Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
				Console.SetWindowSize(LARGEUR_FENETRE, HAUTEUR_FENETRE);

				// En-tête et saisie des dimensions de plateau
				CreationEnTete();
				MenuDemarrage(out nombreColonnes, out nombreLignes);

				Console.Clear();

				// Génère la barre de navigation initiale. Le curseur démarre sur la colonne d’index 1.
				char[,] navigation = GenNavigation(nombreColonnes, 1);

				// Crée et initialise le tableau logique du jeu avec des cases vides.
				char[,] tableau = new char[nombreLignes, nombreColonnes];
				for (int r = 0; r < nombreLignes; r++)
				{
					for (int c = 0; c < nombreColonnes; c++)
					{
						tableau[r, c] = CASE_VIDE;
					}
				}

				// Démarre la boucle de gameplay pour cette partie.
				Gameplay(tableau, navigation);
			}
			while (partie); // Si "partie" passe à false, l’application se termine.
		}

		/// <summary>
		/// Affiche l’en-tête statique du jeu.
		/// </summary>
		static void CreationEnTete()
		{
			// Utilise une "boîte ASCII" pour styliser le titre.
			Console.WriteLine("\t╔════════════════════════════════════════╗\n\t║   Bienvenue dans le jeu Puissance 4    ║\n\t║   Réalisé par Diogo Martins\t\t ║");
			Console.WriteLine("\t╚════════════════════════════════════════╝");
			Console.WriteLine();
		}

		/// <summary>
		/// Saisie interactive et validation robuste du nombre de lignes et de colonnes.
		/// Les valeurs sont bornées par les constantes MIN_* et MAX_*.
		/// </summary>
		/// <param name="nombreColonnes">Nombre de colonnes validé</param>
		/// <param name="nombreLignes">Nombre de lignes validé</param>
		static void MenuDemarrage(out int nombreColonnes, out int nombreLignes)
		{
			bool valeurOK;

			// Prompt pour le nombre de lignes
			Console.Write("\tMerci d'entrer le nombre de lignes\n \tLa valeur doit être plus grande que ");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(MIN_LIGNES);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" et plus petite que ");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(MAX_LIGNES);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("\n\tVotre valeur: ");

			// Validation robuste du nombre de lignes
			do
			{
				valeurOK = int.TryParse(Console.ReadLine(), out nombreLignes);

				if (!valeurOK)
				{
					Console.WriteLine("\tVotre valeur n'est pas un nombre ! Merci de réessayer !");
					Console.Write("\tVotre valeur: ");
				}
				else if (nombreLignes < MIN_LIGNES || nombreLignes > MAX_LIGNES)
				{
					Console.WriteLine("\tVotre valeur n'est pas dans les limites fixées > MIN_LIGNES et < MAX_LIGNES. Merci de réessayer !");
					// Si la valeur est numérique mais hors bornes, on boucle jusqu’à en obtenir une valide.
					do
					{
						Console.Write("\tVotre valeur: ");
						valeurOK = int.TryParse(Console.ReadLine(), out nombreLignes);

						if (!valeurOK)
						{
							Console.WriteLine("\tVotre valeur n'es pas un chiffre. Réessayez");
							continue;
						}

						if (nombreLignes < MIN_LIGNES || nombreLignes > MAX_LIGNES)
						{
							Console.WriteLine("\tVotre valeur n'est pas dans les limites fixées > MIN_LIGNES et < MAX_LIGNES, Merci de réessayer !");
						}
					}
					while (nombreLignes < MIN_LIGNES || nombreLignes > MAX_LIGNES || !valeurOK);
				}
			}
			while (!valeurOK);

			// Prompt pour le nombre de colonnes
			Console.Write("\tMerci d'entrer le nombre de colonnes\n \tLa valeur doit être plus grande que ");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(MIN_COLONNES);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" et plus petite que ");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(MAX_COLONNES);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("\n\tVotre valeur: ");

			// Validation robuste du nombre de colonnes, même stratégie que pour les lignes
			do
			{
				valeurOK = int.TryParse(Console.ReadLine(), out nombreColonnes);

				if (!valeurOK)
				{
					Console.WriteLine("\tVotre valeur n'est pas un nombre ! Merci de réessayer !");
					Console.Write("\tVotre valeur: ");
				}
				else if (nombreColonnes < MIN_COLONNES || nombreColonnes > MAX_COLONNES)
				{
					Console.WriteLine("\tVotre valeur n'est pas dans les limites fixées > MIN_COLONNES et < MAX_COLONNES. Merci de réessayer !");

					do
					{
						Console.Write("\tVotre valeur: ");
						valeurOK = int.TryParse(Console.ReadLine(), out nombreColonnes);

						if (!valeurOK)
						{
							Console.WriteLine("\tVotre valeur n'es pas un chiffre. Réessayez");
							continue;
						}
						if (nombreColonnes < MIN_COLONNES || nombreColonnes > MAX_COLONNES)
						{
							Console.WriteLine("\tVotre valeur n'est pas dans les limites fixées > MIN_COLONNES et < MAX_COLONNES, Merci de réessayer !");
						}
					}
					while (nombreColonnes < MIN_COLONNES || nombreColonnes > MAX_COLONNES || !valeurOK);
				}
			}
			while (!valeurOK);
		}

		/// <summary>
		/// Construit la barre de navigation supérieure et l’affiche.
		/// Le tableau retourné contient un seul rang et "Colonnes" colonnes, avec CURSEUR à l’index navCol.
		/// </summary>
		/// <param name="Colonnes">Nombre total de colonnes</param>
		/// <param name="navCol">Index de la colonne sélectionnée pour le curseur</param>
		/// <returns>Tableau 2D [1 x Colonnes] représentant visuellement la barre de navigation</returns>
		static char[,] GenNavigation(int Colonnes, int navCol)
		{
			// Sécurise navCol pour éviter toute tentative d’accès hors bornes
			if (navCol >= Colonnes)
				navCol = Colonnes - 1;

			// Initialise la barre de navigation avec des espaces
			char[,] barreNav = new char[1, Colonnes];
			for (int c = 0; c < Colonnes; c++)
				barreNav[0, c] = ' ';

			// Positionne le curseur sur la colonne active
			barreNav[0, navCol] = CURSEUR;

			// Rendu ASCII de la barre de navigation
			// Ligne du haut
			for (int c = 0; c < Colonnes; c++)
			{
				if (c == 0)
					Console.Write("\t╔═════╦");
				else if (c < Colonnes - 1)
					Console.Write("═════╦");
				else
					Console.Write("═════╗");
			}
			Console.WriteLine();

			// Ligne du milieu, avec le curseur coloré selon le joueur
			for (int c = 0; c < Colonnes; c++)
			{
				Console.Write(c == 0 ? "\t║  " : "║  ");

				Console.ForegroundColor = (joueurActif == 1) ? COULEUR_JOUEUR1 : COULEUR_JOUEUR2;
				Console.Write(barreNav[0, c]); // Affiche le curseur si présent
				Console.ForegroundColor = COULEUR_TEXTE;

				Console.Write(c == Colonnes - 1 ? "  ║" : "  ");
			}
			Console.WriteLine();

			// Ligne du bas
			for (int c = 0; c < Colonnes; c++)
			{
				if (c == 0)
					Console.Write("\t╚═════╩");
				else if (c < Colonnes - 1)
					Console.Write("═════╩");
				else
					Console.Write("═════╝");
			}

			Console.WriteLine();
			Console.WriteLine();
			return barreNav;
		}

		/// <summary>
		/// Rendu ASCII du plateau de jeu à partir du tableau logique.
		/// Les pions sont colorés par joueur, les cases vides restent transparentes.
		/// </summary>
		/// <param name="tableau">Tableau 2D [lignes x colonnes] représentant l’état du jeu</param>
		static void GenTableau(char[,] tableau)
		{
			int Lignes = tableau.GetLength(0);
			int Colonnes = tableau.GetLength(1);

			for (int r = 0; r < Lignes; r++)
			{
				// Bord supérieur de la ligne r
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

				// Contenu de la ligne r
				for (int c = 0; c < Colonnes; c++)
				{
					Console.Write(c == 0 ? "\t║  " : "║  ");

					char pion = tableau[r, c];

					// Choisit le rendu de la case selon son contenu
					if (pion == PION_JOUEUR1)
					{
						Console.ForegroundColor = COULEUR_JOUEUR1;
						Console.Write("■");
						Console.ForegroundColor = COULEUR_TEXTE;
						Console.Write("  ");
					}
					else if (pion == PION_JOUEUR2)
					{
						Console.ForegroundColor = COULEUR_JOUEUR2;
						Console.Write("■");
						Console.ForegroundColor = COULEUR_TEXTE;
						Console.Write("  ");
					}
					else
					{
						// Case vide
						Console.Write("   ");
					}

					if (c == Colonnes - 1)
						Console.Write("║"); // Bord droit de la ligne
				}
				Console.WriteLine();

				// Bord inférieur de la ligne r, ou fond de la grille si r est la dernière ligne
				for (int c = 0; c < Colonnes; c++)
				{
					if (r < Lignes - 1)
					{
						if (c == 0)
							Console.Write("\t╠═════╬");
						else if (c == Colonnes - 1)
							Console.Write("═════╣");
						else
							Console.Write("═════╬");
					}
					else
					{
						if (c == 0)
							Console.Write("\t╚═════╩");
						else if (c == Colonnes - 1)
							Console.Write("═════╝");
						else
							Console.Write("═════╩");
					}
				}
			}

			// Affiche le panneau d’aide à droite de la grille
			MenuAide(Colonnes);
		}

		/// <summary>
		/// Affiche le panneau "Mode d’utilisation" à droite de la grille.
		/// La position est calculée en fonction du nombre de colonnes pour garder un alignement propre.
		/// </summary>
		/// <param name="Colonnes">Nombre de colonnes de la grille</param>
		static void MenuAide(int Colonnes)
		{
			int tableauLargeur = LARGEUR_COLONNE_AFFICHAGE * Colonnes;
			int offset = tableauLargeur + OFFSET_AIDE;

			Console.SetCursorPosition(offset, MIN_LIGNES);
			Console.Write("Mode d'utilisation");
			Console.WriteLine();
			Console.SetCursorPosition(offset, MIN_COLONNES);
			Console.Write("-------------------");
			Console.WriteLine();

			// Lignes d’aide. Les SetCursorPosition garantissent un alignement stable sur des tailles de plateau variables.
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

		/// <summary>
		/// Dépose un pion dans la colonne demandée si une case est disponible.
		/// Recherche depuis le bas de la colonne vers le haut pour simuler la gravité.
		/// </summary>
		/// <param name="joueurActif">Indice du joueur courant, 1 ou 2</param>
		/// <param name="tableau">Tableau logique du plateau</param>
		/// <param name="col">Index de la colonne ciblée</param>
		/// <returns>Vrai si la pièce a été déposée, faux sinon</returns>
		static bool DeposePiece(int joueurActif, char[,] tableau, int col)
		{
			int lignes = tableau.GetLength(0);
			int colonnes = tableau.GetLength(1);

			// Vérifie immédiatement la validité de la colonne
			if (col < 0 || col >= colonnes)
				return false;

			// Parcourt la colonne depuis la dernière ligne jusqu’en haut
			for (int r = lignes - 1; r >= 0; r--)
			{
				if (tableau[r, col] == CASE_VIDE)
				{
					// Détermine le pion selon le joueur actif et dépose la pièce
					tableau[r, col] = (joueurActif == 1) ? PION_JOUEUR1 : PION_JOUEUR2;
					return true;
				}
			}
			// Colonne pleine
			return false;
		}

		/// <summary>
		/// Boucle principale de jeu. Gère l’entrée clavier, le déplacement du curseur, le tir, l’affichage et la fin de partie.
		/// </summary>
		/// <param name="tableau">État du plateau</param>
		/// <param name="barreNav">Barre de navigation, non modifiée ici, seulement régénérée pour l’affichage</param>
		static void Gameplay(char[,] tableau, char[,] barreNav)
		{
			int lignes = tableau.GetLength(0);
			int colonnes = tableau.GetLength(1);
			int navCol = 0; // Position initiale du curseur de navigation

			Console.Clear();
			CreationEnTete();

			// Capture des positions verticales pour pouvoir réécrire proprement la barre et la grille sans tout scroll
			int navTop = Console.CursorTop;
			GenNavigation(colonnes, navCol);

			int tableauTop = Console.CursorTop;
			GenTableau(tableau);

			bool partieEnCours = true;

			// Boucle événementielle
			while (partieEnCours)
			{
				// Lecture non bloquante de la touche
				var key = Console.ReadKey(intercept: true).Key;

				switch (key)
				{
					case ConsoleKey.RightArrow:
						// Déplacement à droite si on n’est pas à la dernière colonne
						if (navCol < colonnes - 1)
							navCol++;
						Console.SetCursorPosition(0, navTop);
						GenNavigation(colonnes, navCol);
						break;

					case ConsoleKey.LeftArrow:
						// Déplacement à gauche si on n’est pas à la première colonne
						if (navCol > 0)
							navCol--;
						Console.SetCursorPosition(0, navTop);
						GenNavigation(colonnes, navCol);
						break;

					case ConsoleKey.Enter:
					case ConsoleKey.Spacebar:
						// Sécurisation défensive des bornes de navCol avant un tir
						if (navCol < 0)
							navCol = 0;
						if (navCol >= colonnes)
							navCol = colonnes - 1;

						// Tente de déposer la pièce. Si réussi, alterne le joueur.
						if (DeposePiece(joueurActif, tableau, navCol))
						{
							joueurActif = (joueurActif == 1) ? 2 : 1;

							// Test d’état de plateau. Ici, la condition de victoire au sens "alignement" n’est pas implémentée.
							// La fin de partie intervient uniquement lorsque la grille est pleine.
							if (TableauPlein(tableau))
							{
								// Affiche la fenêtre d’égalité et propose de relancer
								ConditionVictoire(tableau);
								partieEnCours = false;
								continue;
							}
						}

						// Rafraîchit l’affichage après un coup
						Console.SetCursorPosition(0, navTop);
						GenNavigation(colonnes, navCol);
						Console.SetCursorPosition(0, tableauTop);
						GenTableau(tableau);
						break;

					case ConsoleKey.Escape:
						// Quitte immédiatement l’application
						Environment.Exit(0);
						break;
				}
			}
		}

		/// <summary>
		/// Indique si le plateau contient encore au moins une case vide.
		/// Sert ici d’unique condition de fin, ce qui produit une "égalité" lorsque tout est rempli.
		/// </summary>
		/// <param name="tableau">État du plateau</param>
		/// <returns>Vrai si le plateau est plein, faux sinon</returns>
		static bool TableauPlein(char[,] tableau)
		{
			int lignes = tableau.GetLength(0);
			int colonnes = tableau.GetLength(1);

			// Recherche d’une case vide. Optimisé pour sortir dès la première case vide trouvée.
			for (int i = 0; i < lignes; i++)
			{
				for (int j = 0; j < colonnes; j++)
				{
					if (tableau[i, j] == CASE_VIDE)
						return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Gère la fin de partie dans le cas d’une égalité, propose de recommencer, et met à jour l’état global "partie".
		/// Remarque: malgré son nom, cette méthode ne valide pas des "alignements gagnants".
		/// </summary>
		/// <param name="tableau">État du plateau au moment de l’égalité</param>
		/// <returns>Vrai si l’application doit s’arrêter, faux si l’on relance une nouvelle partie</returns>
		static bool ConditionVictoire(char[,] tableau)
		{
			bool verif = true;
			Console.Clear();

			do
			{
				try
				{
					Console.WriteLine("Egalité, votre grille est pleine");
					Console.WriteLine("Souhaitez vous recommencer ? (o/O)");

					// Lecture d’un caractère pour confirmer le redémarrage
					char confirmation = Convert.ToChar(Console.ReadLine());

					// Toute réponse différente de o/O arrête l’application
					if (!(confirmation == 'o' || confirmation == 'O'))
					{
						Console.WriteLine("Au revoir");
						partie = false; // Met fin à la boucle du Main
						return true;
					}

					// L’utilisateur souhaite rejouer. On sort de la boucle locale.
					verif = false;
				}
				catch (SystemException erreur)
				{
					// Toute erreur d’entrée est tracée en Debug, puis on repropose le choix.
					Console.WriteLine("Votre choix n'est pas valide\n");
					Debug.WriteLine(erreur);
				}
			}
			while (verif);

			return false;
		}
	}
}
