namespace MessagingApp.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Gender { get; private set; }
        public string CountryOfOrigin { get; private set; }
        public string Email { get; private set; }

        protected User() { }

        public User(string firstName, string lastName, DateTime dateOfBirth, string gender, string countryOfOrigin, string email)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            CountryOfOrigin = countryOfOrigin;
            Email = email;
        }

        // Helper method to calculate age
        public int GetAge()
        {
            var age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear)
                age--;
            return age;
        }
    }
}