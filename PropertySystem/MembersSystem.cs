namespace BooksProject.PropertySystem
{
    internal class MembersSystem
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationData { get; set; }
        public int Id { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nLastname: {LastName}\nMail: {Email}\nRegistrationData: {RegistrationData.ToShortDateString()}\nPassword: {Password}";
        }
    }
}
