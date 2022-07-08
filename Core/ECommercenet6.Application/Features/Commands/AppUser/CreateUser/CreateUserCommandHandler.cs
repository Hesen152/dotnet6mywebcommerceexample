using ECommercenet6.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ECommercenet6.Application.Features.Commands.AppUser.CreateUser;

public class CreateUserCommandHandler:IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
{
    private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

    public CreateUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async  Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        IdentityResult result = await _userManager.CreateAsync(new()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = request.UserName,
            Email = request.Email,
            NameSurName = request.NameSurName,


        }, request.Password);

        CreateUserCommandResponse response= new() { Suceeded = result.Succeeded };

        if (result.Succeeded)
            response.Message = "User registiration is successfully";

        else
            foreach (var error in result.Errors)
            {
                response.Message = $"{error.Code}-{error.Description}<br>";
            }

        return response;

           


    }
}