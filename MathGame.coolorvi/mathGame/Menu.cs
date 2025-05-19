namespace MathGame
{
    public class GameHistory
    {
       public required string Expression { get; set; }
       public required int ResultCorrect { get; set; }
       public required int ResultUser { get; set; }
       public required bool IsWin { get; set; }
       public required TimeSpan TimeGame { get; set; }
       public required string LevelDifficulty { get; set; } 
    }

    class ActionsMenu
    {
    
    static void Main()
    {
        Random random = new Random();
        bool gameRunning = true;
        List<GameHistory> history = new List<GameHistory>();
        string? levelDifficulty;
        string? choiceOperation = null;
        TimeSpan timeGame;
        
        while (gameRunning)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("|Hi! This is Math game. Do you want to play?|");
            Console.WriteLine("|                   Yes                     |");
            Console.WriteLine("|                 No(exit)                  |");
            Console.WriteLine("|                 History                   |");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            string? choiceRunning = Console.ReadLine();
            (string expression, int result) expressionInPlaying = ("", 0);

            if (choiceRunning == null)
            {
                Console.WriteLine("Oops! Error - invalid value");
                continue;
            }

            if (choiceRunning.ToLower() == "no")
            {
                gameRunning = false;
                continue;
            }
            else if (choiceRunning.ToLower() == "history")
            {
                if (history.Count() == 0)
                {
                    Console.WriteLine("No games played yet");
                    continue;
                }

                Console.WriteLine("-----Game History-----");

                foreach (var record in history)
                {
                    Console.WriteLine($"Expression: {record.Expression}");
                    Console.WriteLine($"Level of difficulty: {record.LevelDifficulty}");
                    Console.WriteLine($"Correct answer: {record.ResultCorrect}");
                    Console.WriteLine($"Your answer: {record.ResultUser}");
                    Console.WriteLine($"Result: {(record.IsWin ? "Win" : "Lose")}");
                    Console.WriteLine($"Time: {record.TimeGame}");
                    Console.WriteLine("----------------------------");
                }
                continue;
                
            }
            else if (choiceRunning.ToLower() == "yes")
            {   
                choiceOperation = null;
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("|Choose level of difficulty:|");
                Console.WriteLine("|           Easy            |");
                Console.WriteLine("|          Medium           |");
                Console.WriteLine("|           Hard            |");
                Console.WriteLine("|          Random           |");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                levelDifficulty = Console.ReadLine();
                int difficultStartNum;
                int difficultFinalNum;

                if (!string.IsNullOrEmpty(levelDifficulty))
                {
                    switch (levelDifficulty.ToLower())
                    {
                        case "easy":
                            difficultStartNum = 0;
                            difficultFinalNum = 10;
                            break;
                        case "medium":
                            difficultStartNum = 10;
                            difficultFinalNum = 100;
                            break;
                        case "hard":
                            difficultStartNum = 100;
                            difficultFinalNum = 1001;
                            break;
                        case "random":
                            difficultStartNum = 0;
                            difficultFinalNum = 1001;
                            string[] operations = { "+", "-", "*", "/" };
                            int index = random.Next(operations.Length);
                            choiceOperation = operations[index];
                            break;    
                        default:
                            Console.WriteLine("Oops! Error - invalid input");
                            continue;            
                    }
                }
                else
                {
                    Console.WriteLine("Oops! Error - invalid input");
                    continue;
                }

                if (string.IsNullOrEmpty(choiceOperation))
                {

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("|Great! Choose operation:|");
                Console.WriteLine("|             +          |");
                Console.WriteLine("|             -          |");
                Console.WriteLine("|             *          |");
                Console.WriteLine("|             /          |");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
                
                choiceOperation = Console.ReadLine();
                }
                ActionsExpressions expressions = new ActionsExpressions();

                switch (choiceOperation)
                {
                    case "+":
                        expressionInPlaying = expressions.GenerateExpression("+", difficultStartNum, difficultFinalNum);
                        break;
                    case "-":
                        expressionInPlaying = expressions.GenerateExpression("-", difficultStartNum, difficultFinalNum);
                        break;
                    case "*":
                        expressionInPlaying = expressions.GenerateExpression("*",difficultStartNum, difficultFinalNum);
                        break;
                    case "/":
                        expressionInPlaying = expressions.GenerateExpression("/", difficultStartNum, difficultFinalNum);
                        break; 
                    default:
                        Console.WriteLine("Oops! Error - invalid operation");
                        break;     
                }
            }
            else
            {
                Console.WriteLine("Oops! Error - invalid value");
                continue;
            }

            Console.WriteLine($"Here's your expression: {expressionInPlaying.expression}. Figure it out and tell me the answer.");

            DateTime startTime = DateTime.Now;
            DateTime endTime;

            string? resultUserNotParse = Console.ReadLine();

            if (!int.TryParse(resultUserNotParse, out int resultUser))
            {
                Console.WriteLine("Oops! Error - not number");
                continue;
            }

            if (resultUser == expressionInPlaying.result)
            {
                Console.WriteLine("YOU WIN!");
                endTime = DateTime.Now;
                timeGame = endTime - startTime;
                history.Add(new GameHistory
                {
                    Expression = expressionInPlaying.expression,
                    ResultCorrect = expressionInPlaying.result,
                    ResultUser = resultUser,
                    IsWin = true,
                    TimeGame = timeGame,
                    LevelDifficulty = levelDifficulty
                });
                continue;
            }
            Console.WriteLine("You lost!");
            endTime = DateTime.Now;
            timeGame = endTime - startTime;
            history.Add(new GameHistory
            {
                Expression = expressionInPlaying.expression,
                ResultCorrect = expressionInPlaying.result,
                ResultUser = resultUser,
                IsWin = false,
                TimeGame = timeGame,
                LevelDifficulty = levelDifficulty
            });
            continue;
        }
    }

    }

}

