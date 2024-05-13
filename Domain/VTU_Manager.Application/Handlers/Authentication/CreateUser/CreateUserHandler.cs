using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VTU_Manager.Domain.Entities;
using VTU_Manager.Domain.Interfaces.Repositories;

namespace VTU_Manager.Application.Handlers.Authentication.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResp>
    {
        private const string USER_ROLE_NAME = "User";
        private readonly IReadOnlyRepository<EligibleEmail, int> readOnlyRepository;
        private readonly UserManager<VTUser> userManager;

        public CreateUserHandler(
            IReadOnlyRepository<EligibleEmail, int> readOnlyRepository,
            UserManager<VTUser> userManager)
        {
            this.readOnlyRepository = readOnlyRepository;
            this.userManager = userManager;
        }

        public async Task<CreateUserResp> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var eligibleEmails = await readOnlyRepository.ListAsync();

            var errors = new List<IdentityError>();

            if (eligibleEmails is null)
            {
                errors.Add(new IdentityError { Description = "Няма имейли в базата" });
            }

            if (!eligibleEmails.Select(x => x.Email).Contains(request.Email))
            {
                errors.Add(new IdentityError { Description = "Имейлът, с който се опитвате да се регистрирате не е в списъка с упълномощени  имейли" });
            }

            var registeredEmails = await userManager.Users.Select(user => user.Email).ToListAsync();

            if (registeredEmails.Contains(request.Email))
            {
                errors.Add(new IdentityError { Description = "Имейлът, с който се опитвате да се регистрирате е вече регистриран. Моля използвайте друг." });
            }

            var user = new VTUser
            {
                UserName = request.Email,
                Email = request.Email,
                Created = DateTime.Now
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, USER_ROLE_NAME);
            }
            else
            {
                errors.AddRange(result.Errors);
            }

            return new CreateUserResp(user.Id, errors, true);
        }
    }

    public record CreateUserCommand(string Email, string Password) : IRequest<CreateUserResp>;

    public record CreateUserResp(string UserId, List<IdentityError> Errors, bool Succeeded);
}
