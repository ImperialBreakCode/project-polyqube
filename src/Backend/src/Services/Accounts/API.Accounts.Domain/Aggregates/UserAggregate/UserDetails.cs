using API.Shared.Domain.Base.Entity;
using API.Shared.Domain.Interfaces.Entity;

namespace API.Accounts.Domain.Aggregates.UserAggregate
{
    public class UserDetails : BaseCreatedAtEntity, IAuditable
    {
        private UserDetails(string firstName, string lastName, DateOnly birthdate, GenderEnum gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Gender = gender;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthdate { get; set; }
        public GenderEnum Gender { get; set; }
        public string? ProfilePicturePath { get; set; }

        public DateTime UpdatedAt { get; set; }

        public static UserDetails Create(string firstName, string lastName, DateOnly birthdate, GenderEnum gender)
        {
            return new UserDetails(firstName, lastName, birthdate, gender);
        }
    }
}
