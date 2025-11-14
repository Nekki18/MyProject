namespace BackendAPI_1.Contacts.User
{
    public class GetUserResponse
    {
        public string Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Middlename { get; set; } = null!;
        public DateTime Burthdate { get; set; }
        public string Login { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public object Birthdate { get; internal set; }
    }
}
