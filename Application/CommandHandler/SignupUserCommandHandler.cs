using Application.Command;
using Domain;
using Infrastructure.Repository;
using MediatR;

namespace Application.CommandHandler
{
    public class SignupUserCommandHandler : IRequestHandler<SignupUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public SignupUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(SignupUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Password = request.Password, 
                FirstName = request.FirstName,
                LastName = request.LastName,
                Device = request.Device,
                IPAddress = request.IPAddress,
                Balance = 0
            };

            return await _userRepository.AddUserAsync(user);
        }
    }
}
