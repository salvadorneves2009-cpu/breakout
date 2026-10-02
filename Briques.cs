using Raylib_cs;

namespace Breakout;

static partial class Program
{
    /// <summary>Le rectangle occupé à l'écran par la brique (ligne, colonne).</summary>
    static Rectangle RectangleBrique(int ligne, int colonne)
    {
        float x = ESPACE_BRIQUES + colonne * (LARGEUR_BRIQUE + ESPACE_BRIQUES);

        // Calcul de Y : la marge du haut + (la brique + l'espace suivant) pour chaque ligne précédente
        float y = MARGE_HAUT_BRIQUES + ligne * (HAUTEUR_BRIQUE + ESPACE_BRIQUES);

        return new Rectangle(x, y, LARGEUR_BRIQUE, HAUTEUR_BRIQUE);
        
    }

    /// <summary>Casse la brique touchée par la balle, fait rebondir la balle et ajoute les points.</summary>
    static void CasserBriques()
    {
        for (int l = 0; l < LIGNES_BRIQUES; l++)
            for (int c = 0; c < COLONNES_BRIQUES; c++)
                if (briques[l, c])
                {
                    Rectangle rectangleCollision = RectangleBrique(l, c);
                    
                    if (positionBalle.X + RAYON_BALLE >= rectangleCollision.X && positionBalle.X - RAYON_BALLE <= rectangleCollision.X + LARGEUR_BRIQUE &&
                        positionBalle.Y + RAYON_BALLE >= rectangleCollision.Y && positionBalle.Y - RAYON_BALLE <= rectangleCollision.Y + HAUTEUR_BRIQUE)
                    {
                        briques[l, c] = false;
                        vitesseBalle.Y = -vitesseBalle.Y;
                        score += POINTS_PAR_BRIQUE;
                        return; 
                    }
                }
    }

    /// <summary>Le nombre de briques encore présentes.</summary>
    static int CompterBriques()
    {
        return 0;
    }

    /// <summary>Dessine les briques encore présentes, une couleur par ligne.</summary>
    static void DessinerBriques()
    {
        for (int l = 0; l < LIGNES_BRIQUES; l++)
        {
            for (int c = 0; c < COLONNES_BRIQUES; c++)
            {
                if (briques[l, c])
                {
                    Rectangle rect = RectangleBrique(l, c);
                    Color couleur = couleursLignes[l]; 

                    Raylib.DrawRectangleRec(rect, couleur);
                }
            }
        }
    }
}
