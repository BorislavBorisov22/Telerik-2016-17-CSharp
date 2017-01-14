namespace SchoolSystem.Components
{
    using System;

    public class Discipline : NamableEntity, ICommentable, INamable
    {
        private int numberOfLectures;
        private int numberOfExercises;

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
            : base(name)
        {
            this.NumberOfLectures = numberOfLectures;
            this.numberOfExercises = numberOfExercises;
        }

        public Discipline(string name, string comment, int numberOfLectures, int numberOfExercises)
            : base(name, comment)
        {
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
        }

        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Discipline's number of exercises cannot be zero or less");
                }

                this.numberOfExercises = value;
            }
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Discipline's number of lectures cannot be zero ot less");
                }

                this.numberOfLectures = value;
            }
        }
    }
}
