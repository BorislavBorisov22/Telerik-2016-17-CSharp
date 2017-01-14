namespace SchoolSystem.Components
{
    using System;

    public abstract class NamableEntity : INamable, ICommentable
    {
        private string name;

        public NamableEntity(string name)
        {
            this.Name = name;
        }

        public NamableEntity(string name, string comment)
            : this(name)
        {
            this.Comment = comment;
        }

       public string Comment { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Namable Entity's name cannot be less than 3 symbols long");
                }

                this.name = value;
            }
        }
    }
}
