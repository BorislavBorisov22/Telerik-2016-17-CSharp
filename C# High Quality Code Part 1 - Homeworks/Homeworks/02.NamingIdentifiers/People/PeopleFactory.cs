namespace People
{ 
    public class PeopleFactory
    {  
        public Person MakePerson(Gender personsGender, int personsAge)
        {
            Person newPerson = new Person();

            newPerson.Age = personsAge;

            if (personsGender == Gender.Male)
            {
                newPerson.Name = "Батката";
                newPerson.Gender = Gender.Male;
            }
            else
            {
                newPerson.Name = "Мацето";
                newPerson.Gender = Gender.Female;
            }

            return newPerson;
        }
    }
}
