namespace Methods.Students
{
    using System;

    public interface IStudent
    {
        DateTime BirthDate { get; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string OtherInfo { get; set; }

        bool IsOlderThan(IStudent other);
    }
}