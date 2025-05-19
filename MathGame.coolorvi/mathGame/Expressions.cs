namespace MathGame
{
    
    public class ActionsExpressions
    
    {
        
        public (string expression, int result) GenerateExpression(string operation, int startLevelDifficult, int finalLevelDifficult)
        {
            Random generateNums = new Random();
            int firstOperand = generateNums.Next(startLevelDifficult, finalLevelDifficult);
            int secondOperand = generateNums.Next(startLevelDifficult, finalLevelDifficult);
            int result = 0;

            switch (operation)
            {
                case "+":
                    result = firstOperand + secondOperand;
                    break;
                case "-":
                    result = firstOperand - secondOperand;
                    break;
                case "*":
                    result = firstOperand * secondOperand;
                    break;
                case "/":
                    do
                    {
                        secondOperand = generateNums.Next(startLevelDifficult, finalLevelDifficult);
                    } while (secondOperand == 0);

                    result = generateNums.Next(startLevelDifficult, finalLevelDifficult);
                    firstOperand = result * secondOperand;
                    break;    
            }

            string expression = firstOperand.ToString() + " " + operation + " " + secondOperand.ToString();

            return (expression, result);
        }
    }
}
