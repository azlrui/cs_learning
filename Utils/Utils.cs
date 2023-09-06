using FindTheNumber.Enums;

namespace FindTheNumber.Utils
{
    public static class Utils
    {
        private static ConsoleKey _userKeyInput;
        public static bool CheckUserInput(string? userInput, Game game)
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

        public static bool CheckSolution(NumberStatus state, Game game)
        {
            switch (state)
            {
                case (NumberStatus.Equal):
                    Console.WriteLine($"Bravo! Vous avez réussi à trouver le numéro {game.NumberToFind} après {game.UserTries} essais");
                    return true;
                    break;
                case (NumberStatus.Small):
                    Console.WriteLine($"Votre nombre est trop petit.\nEssayez à nouveau de trouver le numéro entre 0 et 100:");
                    break;
                case (NumberStatus.Large):
                    Console.WriteLine($"Votre nombre est trop grand.\nEssayez à nouveau de trouver le numéro entre 0 et 100:");
                    break;
            }
            return false;
        }

        public static bool WannaReplay()
        {
            Console.WriteLine("Est-ce que vous voulez recommencer? Appuyer sur [y] pour 'oui' ou [n] pour 'non'");
    
            do
            {
                _userKeyInput = Console.ReadKey().Key;

            } while(!ControlUserInput(_userKeyInput));

            if (_userKeyInput == ConsoleKey.Y)
            {
                return true;
            }
            else if(_userKeyInput == ConsoleKey.N)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public static bool ControlUserInput(ConsoleKey userKeyInput)
        {
            if (userKeyInput == ConsoleKey.Y || userKeyInput == ConsoleKey.N) return true;
            Console.WriteLine("Veuillez seulement cliquer sur [y] pour continuer ou [n] pour arrêter");
            return false;
        }
    }
}



