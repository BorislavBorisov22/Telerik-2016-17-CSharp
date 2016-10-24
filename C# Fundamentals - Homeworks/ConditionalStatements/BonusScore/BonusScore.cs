using System;


namespace BonusScore
{
    class BonusScore
    {
        static void Main()
        {
            int score = int.Parse(Console.ReadLine());
            bool correctScore = true;

            if (score >= 1 && score <= 3)
            {
                score *= 10;

            }
            else if (score >= 4 && score <= 6)
            {
                score *= 100;
            }
            else if (score >= 7 && score <= 9)
            {
                score *= 1000;
            }
            else
            {
                Console.WriteLine("invalid score");
                correctScore = false;
            }


            if (correctScore)
            {
                Console.WriteLine(score);
            }


            
            
        }
    }
}
