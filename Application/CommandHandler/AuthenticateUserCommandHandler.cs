using Domain;
using Infrastructure.Repository;
using MediatR;

public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, User>
{
    private readonly IUserRepository _userRepository;

    public AuthenticateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByUsernameAsync(request.Username);

        if (user == null || !VerifyPassword(user.Password, request.Password))
        {
            return null !;
        }

        return user;
    }

    private bool VerifyPassword(string storedPassword, string providedPassword)
    {
        return storedPassword == providedPassword;
    }
}