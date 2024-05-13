using MediatR;
using Microsoft.AspNetCore.Identity;
using VTU_Manager.Domain.Entities;

namespace VTU_Manager.Application.Handlers.Authentication.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, SignInResult>
    {
        private readonly SignInManager<VTUser> signInManager;

        public LoginUserHandler(SignInManager<VTUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<SignInResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, false);
        }
    }

    public record LoginUserCommand(string Email, string Password, bool RememberMe) : IRequest<SignInResult>;
}
