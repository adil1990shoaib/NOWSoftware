namespace Domain
{
    /// <summary>
    /// User model to hold all user properties
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;  
        public string Device { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }

}
