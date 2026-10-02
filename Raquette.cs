using System.Numerics;
using Raylib_cs;

namespace Breakout;

static partial class Program
{
    /// <summary>Le rectangle occupé par la raquette à l'écran.</summary>
    static Rectangle RectangleRaquette()
    {
        return new Rectangle(positionRaquette.X, positionRaquette.Y, LARGEUR_RAQUETTE, HAUTEUR_RAQUETTE);
    }

    /// <summary>Déplace la raquette avec les flèches, sans sortir de la fenêtre.</summary>
    static void DeplacerRaquette(float dt)
    {
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            positionRaquette.X -= VITESSE_RAQUETTE * dt;
        }

        if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            positionRaquette.X += VITESSE_RAQUETTE * dt;
        }

        // Bloque cote gauche
        if (positionRaquette.X < 0)
        {
            positionRaquette.X = 0;
        }
        // Bloque coté droit
        if (positionRaquette.X > LARGEUR - LARGEUR_RAQUETTE)
        {
            positionRaquette.X = LARGEUR - LARGEUR_RAQUETTE;
        }
    
    }
    

    /// <summary>Fait rebondir la balle si elle touche la raquette.</summary>
    static void RebondirSurRaquette()
    {
        if (positionBalle.X >= positionRaquette.X &&
        positionBalle.X <= positionRaquette.X + LARGEUR_RAQUETTE &&
        positionBalle.Y + RAYON_BALLE >= positionRaquette.Y &&
        positionBalle.Y - RAYON_BALLE <= positionRaquette.Y + HAUTEUR_RAQUETTE)
        {
            
            if (vitesseBalle.Y > 0)
            {
                vitesseBalle.Y = -vitesseBalle.Y;
                positionBalle.Y = positionRaquette.Y - RAYON_BALLE; 
            }
        }
    }
}
