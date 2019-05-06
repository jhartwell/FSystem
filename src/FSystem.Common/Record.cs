using System;
using FSystem.Common.Interfaces;

namespace FSystem.Common
{
    /// <summary>
    /// Represents a single record
    /// </summary>
    public class Record : IRecord
    {
        public Record(string firstName, string lastName, string gender, string favoriteColor, string dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            FavoriteColor = favoriteColor;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }

        /// <summary>
        /// First name of the individual
        /// </summary>
        /// <value>The second field on a given record string</value>
        public string FirstName { get; }

        /// <summary>
        /// The last name of an individual
        /// </summary>
        /// <value>The first field on a given record string</value>
        public string LastName { get; }


        /// <summary>
        /// The favorite color of the individual
        /// </summary>
        /// <value>The fourth field on a given record string</value>
        public string FavoriteColor { get; }

        /// <summary>
        /// The date of birth of the individual
        /// </summary>
        /// <value>The fifth field on a given record string</value>
        public string DateOfBirth { get; }

        /// <summary>
        /// The gender of the individual
        /// </summary>
        /// <value>The third field on a given record string</value>
        public string Gender { get; }
    }
}
