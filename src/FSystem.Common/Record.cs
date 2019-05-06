using System;
using FSystem.Common.Interfaces;

namespace FSystem.Common
{
    public class Record : IRecord
    {
        public Record(string firstName, string lastName, string favoriteColor, string dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            FavoriteColor = favoriteColor;
            DateOfBirth = dateOfBirth;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string FavoriteColor { get; }

        public string DateOfBirth { get; }
    }
}
