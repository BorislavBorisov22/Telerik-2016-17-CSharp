using System;

public class CSharpExam : Exam
{
    private const int MinScore = 0;
    private const int MaxScore = 100;

    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentNullException("Score must be a non-negative number!");
            }

            if (value < MinScore || value > MaxScore)
            {
                throw new InvalidOperationException("Score");
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}
