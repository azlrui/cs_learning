using System.Runtime.CompilerServices;
using FindTheNumber;
using FindTheNumber.Enums;

Game game = Game.Start();
ConsoleKey userKeyInput;


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

        } while (!CheckUserInput(text));

        if (CheckSolution(game.Stats().NumberStatus))
        {
            game.Stop();
        }

    } while (game?.Stats().GameStatus == GameStatus.Running);

    Console.WriteLine("Est-ce que vous voulez recommencer? Appuyer sur [y] pour 'oui' ou [n] pour 'non'");
    
    do
    {
        userKeyInput = Console.ReadKey().Key;

        Console.ReadLine();

    } while(!ControlUserInput(userKeyInput));
    
    wannaReplay(userKeyInput);

} while(wannaReplay(userKeyInput));

return;

bool CheckUserInput(string? userInput)
{
    bool isNumber;

    isNumber = int.TryParse(userInput, out int nbChosen);

    if (isNumber)
    {
        game.FindNumber(nbChosen);
    }
    else
    {
        Console.Write("Veuillez insérer un numéro s'il vous plaît entre 0 et 100:\t");
    }

    return isNumber;
}

bool CheckSolution(NumberStatus state)
{
    bool isComplete = false;
    switch (state)
    {
        case (NumberStatus.Equal):
            isComplete = true;
            Console.WriteLine($"Bravo! Vous avez réussi à trouver le numéro {game.NumberToFind} après {game.UserTries} essais");
            break;
        case (NumberStatus.Small):
            Console.WriteLine($"Votre nombre est trop petit.\nEssayez à nouveau de trouver le numéro entre 0 et 100:");
            break;
        case (NumberStatus.Large):
            Console.WriteLine($"Votre nombre est trop grand.\nEssayez à nouveau de trouver le numéro entre 0 et 100:");
            break;
    }
    return isComplete;
}

bool wannaReplay(ConsoleKey userKeyInput)
{
    bool wannaContinue = false;

    if (userKeyInput == ConsoleKey.Y)
    {
        wannaContinue = true;
        return wannaContinue;
    }
    else if(userKeyInput == ConsoleKey.N)
    {
        wannaContinue = false;
        return wannaContinue;
    }
    else
    {
        return wannaContinue;
    }
}

bool ControlUserInput(ConsoleKey userKeyInput)
{
    bool isKeyValid = true;
    if (userKeyInput == ConsoleKey.Y || userKeyInput == ConsoleKey.N) return isKeyValid;
    Console.WriteLine("Veuillez seulement cliquer sur [y] pour continuer ou [n] pour arrêter");
    isKeyValid = false;
    return isKeyValid;

}