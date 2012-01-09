using System;

namespace Core.Interfaces
{
    public interface IClient
    {
        string Id { get; set; }
        string Forename { get; set; }
        string Surname { get; set; }
        int Age { get; set; }
        bool IsEmployed { get; set; }
        Enumerations.Enumerations.Gender? Gender { get; set; }
        DateTime LastUpdated { get; set; }
    }
}