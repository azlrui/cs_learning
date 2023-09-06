using System.Runtime.CompilerServices;
using FindTheNumber;
using FindTheNumber.Enums;
using static FindTheNumber.Utils;

Game game = Game.Start();

do
{
    game.Restart();
    game.RunGame();
    
    Console.Write($"Bienvenue à FindTheNumber! Saurez-vous trouver le bon numéro? Ecrivez-un numéro entre 0 et 100:\t");

    do
    {
        string? text;
        do
        {
            text = Console.ReadLine();

        } while (!Utils.CheckUserInput(text,game));

        if (Utils.CheckSolution(game.Stats().NumberStatus, game))
        {
            game.Stop();
        }

    } while (game?.Stats().GameStatus == GameStatus.Running);
    
} while(Utils.WannaReplay());

