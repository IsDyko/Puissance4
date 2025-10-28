# 🟡 PUISSANCE 4 — Projet C# Console  
**Auteur :** Diogo Martins  
**École :** ETML  
**Langage :** C# (.NET Console App)  
**Date de création :** 2025  

██████╗ ██╗ ██╗██╗███╗ ██╗███████╗███████╗ █████╗ ███╗ ██╗ ██████╗ █████╗ ██████╗ ███████╗
██╔══██╗██║ ██║██║████╗ ██║██╔════╝██╔════╝██╔══██╗████╗ ██║██╔════╝ ██╔══██╗██╔════╝ ██╔════╝
██████╔╝██║ ██║██║██╔██╗ ██║███████╗███████╗███████║██╔██╗ ██║██║ ███╗███████║██║ ███╗███████╗
██╔═══╝ ██║ ██║██║██║╚██╗██║╚════██║╚════██║██╔══██║██║╚██╗██║██║ ██║██╔══██║██║ ██║╚════██║
██║ ╚██████╔╝██║██║ ╚████║███████║███████║██║ ██║██║ ╚████║╚██████╔╝██║ ██║╚██████╔╝███████║
╚═╝ ╚═════╝ ╚═╝╚═╝ ╚═══╝╚══════╝╚══════╝╚═╝ ╚═╝╚═╝ ╚═══╝ ╚═════╝ ╚═╝ ╚═╝ ╚═════╝ ╚══════╝
by Diogo Martins


---

## 🎯 Description du projet
Ce projet est une **application console** qui reproduit le célèbre jeu **Puissance 4** (*Connect Four*).  
Le but du jeu est d’aligner 4 pions de la même couleur (horizontalement, verticalement ou en diagonale) avant l’adversaire.  

Le programme est développé en **C#**, avec une interface console claire, une logique robuste et une gestion sécurisée des entrées utilisateur.

---

## 🧩 Fonctionnalités principales
- ✅ Menu de démarrage interactif  
- ✅ Choix du nombre de lignes et de colonnes  
- ✅ Gestion du tour des joueurs (1 = X, 2 = O)  
- ✅ Vérification automatique de la victoire  
- ✅ Protection contre les erreurs (`TryParse`, limites du tableau, etc.)  
- ✅ Affichage dynamique du plateau de jeu  
- ✅ Navigation fluide avec les flèches du clavier  

---

## ⚙️ Structure du code
Le projet est organisé en plusieurs **méthodes** pour plus de clarté :

| Méthode | Rôle |
|----------|------|
| `Main()` | Point d’entrée du programme |
| `MenuDemarrage()` | Configuration du jeu (taille du plateau) |
| `CreationEnTete()` | Affiche le titre du jeu |
| `GenTableau()` | Génère et affiche la grille |
| `Gameplay()` | Logique principale du jeu |
| `DeposePiece()` | Place la pièce du joueur actif |
| `CheckVictoire()` | Vérifie si un joueur a gagné |
| `AfficherGagnant()` | Affiche le message de victoire |

---

## 🧠 Exemple d’utilisation

Bienvenue dans le jeu PUISSANCE 4 !

Merci d'entrer le nombre de lignes :

6

Merci d'entrer le nombre de colonnes :

7

Le jeu commence ! Joueur 1 (X) commence.


Le joueur déplace le curseur avec les flèches du clavier et dépose une pièce avec **Entrée** ou **Espace**.

---

## 💡 Exemple de code

```csharp
if (tableau[r, col] == ' ')
{
    // Poser la pièce
    tableau[r, col] = (joueurActif == 1) ? 'X' : 'O';
    return true;
}
```
👉 Ce bloc vérifie si la case est vide, puis place la pièce du joueur actif (X ou O).

## 🧰 Technologies utilisées

Langage : C#

Framework : .NET 8 (ou équivalent)

IDE : Visual Studio / VS Code

Compatibilité : Windows, macOS, Linux (console UTF-8)

## 🚀 Installation et exécution
1️⃣ Cloner le projet
git clone https://github.com/<ton-utilisateur>/Puissance4_Martins.git

2️⃣ Ouvrir le dossier
cd Puissance4_Martins

3️⃣ Exécuter
dotnet run

## 📜 Règles du jeu

Deux joueurs jouent à tour de rôle.

Chaque joueur place un pion dans une colonne.

Le pion tombe à la position libre la plus basse.

Le premier à aligner 4 pions gagne.

Si la grille est pleine sans gagnant → match nul.

## 🧩 Bonnes pratiques respectées

✅ Variables explicites

✅ Indentation homogène

✅ Validation des entrées avec int.TryParse

✅ Gestion d’erreurs (try/catch)

✅ Code commenté et clair

✅ Respect des conventions C# (PascalCase / camelCase)

## 💬 Améliorations futures

🟢 Mode solo contre IA

🟢 Sauvegarde / chargement de partie

🟢 Interface graphique (Windows Forms ou WPF)

🟢 Statistiques et scores automatiques

## 👨‍💻 Auteur

Diogo Martins
Étudiant en développement d’applications — ETML
📧 [
]
🌐 github.com/DiogoMartins

⭐ Si tu aimes ce projet :

N’hésite pas à mettre une étoile sur GitHub ⭐ et à partager ton retour !
Ce projet est un excellent exercice pour renforcer ta logique et ta maîtrise du C# console.


---
