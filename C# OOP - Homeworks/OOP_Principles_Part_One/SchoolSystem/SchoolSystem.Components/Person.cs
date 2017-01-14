namespace SchoolSystem.Components
{
    public abstract class Person : NamableEntity, ICommentable, INamable
    {
        public Person(string name)
            : base(name)
        {
        }

        public Person(string name, string comment)
            : base(name, comment)
        {
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Additional Comments: {1}", this.Name, this.Comment);
        }
    }
}
