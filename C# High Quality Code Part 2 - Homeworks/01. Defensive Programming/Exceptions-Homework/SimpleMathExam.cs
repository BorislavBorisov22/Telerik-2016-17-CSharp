using System;

public class SimpleMathExam : Exam
{
    private const int MinProblemsSolved = 0;
    private const int MaxProblemsSolved = 2;

    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < MinProblemsSolved || value > MaxProblemsSolved)
            {
                throw new ArgumentOutOfRangeException($"Problems solved must be between ${MinProblemsSolved} and ${MaxProblemsSolved}!");
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (this.ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }
        else
        {
            throw new ArgumentOutOfRangeException($"ProblemsSolved must be between ${MinProblemsSolved} and ${MaxProblemsSolved} in order to check result!");
        }
    }
}
