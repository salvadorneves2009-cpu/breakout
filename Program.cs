using System.Numerics;
using Raylib_cs;

namespace Breakout;

static partial class Program
{
    static void Main()
    {
        
        Raylib.InitWindow(LARGEUR, HAUTEUR, "Breakout");
        Raylib.SetTargetFPS(60);


        Reinitialiser();

        while (!Raylib.WindowShouldClose())
        {
            float dt = Raylib.GetFrameTime();

            if (Raylib.IsKeyPressed(KeyboardKey.R))
            {
                Reinitialiser();
            }


            switch (etat)
            {
                case EtatJeu.Attente:
                    MettreAJourAttente(dt);
                    break;
                case EtatJeu.Jeu:
                    MettreAJourJeu(dt);
                    break;
                case EtatJeu.Perdu:
                case EtatJeu.Gagne:
                    MettreAJourFin();
                    break;
            }

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            DessinerJeu();


            if (etat == EtatJeu.Perdu || etat == EtatJeu.Gagne)
            {
                DessinerFin();
            }


            Raylib.EndDrawing();


        }

        Raylib.CloseWindow();
    }

    /// <summary>Remet le jeu dans son état de départ.</summary>
    static void Reinitialiser()
    {
        positionRaquette.X = (LARGEUR / (float)2) - (LARGEUR_RAQUETTE / (float)2);

        positionRaquette.Y = HAUTEUR - HAUTEUR_RAQUETTE - MARGE_BAS_RAQUETTE;

        etat = EtatJeu.Attente;
    }

    /// <summary>Une image de jeu dans l'état Attente.</summary>
    static void MettreAJourAttente(float dt)
    {
        

        DeplacerRaquette(dt);
        CollerBalleARaquette();
        LancerBalle();

        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            etat = EtatJeu.Jeu;
        } 

    }

    /// <summary>Une image de jeu dans l'état Jeu.</summary>
    static void MettreAJourJeu(float dt)
    {
        DeplacerRaquette(dt);

        
        positionBalle.X += vitesseBalle.X * dt;
        positionBalle.Y += vitesseBalle.Y * dt;
    }

    /// <summary>Une image de jeu dans les états Perdu et Gagne.</summary>
    static void MettreAJourFin()
    {
    }
}
