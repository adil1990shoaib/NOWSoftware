using MediatR;

namespace Application.Command
{
    public class SignupUserCommand : IRequest<int>
    {
        public string Username { get; set; }= string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Device { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;
    }
}
