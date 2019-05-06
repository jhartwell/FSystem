using System;
namespace FSystem.Common.Interfaces
{
    public interface IRecord
    {
        string FirstName { get; }
        string LastName { get; }
        string Gender { get; }
        string FavoriteColor { get; }
        string DateOfBirth { get; }
    }
}