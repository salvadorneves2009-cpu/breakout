using System.Numerics;

namespace Breakout;

static partial class Program
{
    /// <summary>Pose la balle au milieu du dessus de la raquette.</summary>
    static void CollerBalleARaquette()
    {
        positionBalle.X = positionRaquette.X + (LARGEUR_RAQUETTE / (float)2);

        
        positionBalle.Y = positionRaquette.Y - RAYON_BALLE;
    }

    /// <summary>Donne à la balle sa vitesse de départ.</summary>
    static void LancerBalle()
    {
        // sin(45 degre) ou cos(45 degre) = ~0.7071 
        float valeurDiagonale = (float)0.7071 * VITESSE_BALLE;

        vitesseBalle.X = valeurDiagonale;  // Positif = va vers la droite
        vitesseBalle.Y = -valeurDiagonale;
    }

    /// <summary>Avance la balle selon sa vitesse.</summary>
    static void DeplacerBalle(float dt) 
    {
        positionBalle.X += vitesseBalle.X * dt; 
        positionBalle.Y += vitesseBalle.Y * dt;
    }

    /// <summary>Fait rebondir la balle sur les murs gauche, droit et haut.</summary>
    static void RebondirSurMurs()
    {
        if (positionBalle.X < RAYON_BALLE)
        {
            positionBalle.X = RAYON_BALLE; 
            vitesseBalle.X = -vitesseBalle.X; 
        }

        
        if (positionBalle.X > LARGEUR - RAYON_BALLE)
        {
            positionBalle.X = LARGEUR - RAYON_BALLE;
            vitesseBalle.X = -vitesseBalle.X;
        }

        
        if (positionBalle.Y < RAYON_BALLE)
        {
            positionBalle.Y = RAYON_BALLE; 
            vitesseBalle.Y = -vitesseBalle.Y; 
        }
    }

    /// <summary>Indique si la balle est entièrement sortie par le bas de la fenêtre.</summary>
    static bool BalleSortieEnBas()
    {
        return false;
    }
}
