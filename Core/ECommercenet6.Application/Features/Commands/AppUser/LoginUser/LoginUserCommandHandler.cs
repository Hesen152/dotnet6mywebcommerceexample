using ECommercenet6.Application.Abstractions.Token;
using ECommercenet6.Application.DTOs;
using ECommercenet6.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommercenet6.Application.Features.Commands.AppUser.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    private UserManager<Domain.Entities.Identity.AppUser> _userManager;
    private SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
    private ITokenHandler _tokenHandler;

    public LoginUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager,
        SignInManager<Domain.Entities.Identity.AppUser> signInManager, ITokenHandler tokenHandler)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenHandler = tokenHandler;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
        if (user == null)
            user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
        if (user == null)
            throw new NotFoundUserException();


        SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (result.Succeeded) //Authentication succesffult 
        {
            Token token = _tokenHandler.CreateAccessToken(5);

            return new LoginUserSuccessCommandResponse()
            {
                Token = token
            };
        }
        //
        // return new LoginUserErrorCommandResponse()
        // {
        //     Message = "username or password is incorrect"
        // };

        throw new AuthenticationErrorException();
    }
}