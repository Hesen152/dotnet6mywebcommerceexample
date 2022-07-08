using MediatR;

namespace ECommercenet6.Application.Features.Commands.AppUser.CreateUser;

public class CreateUserCommandRequest:IRequest<CreateUserCommandResponse>
{

    public string NameSurName { get; set; }
    public string UserName  { get; set; }
    public string Email   { get; set; }
    public string Password  { get; set; }
    
    public string PasswordConfirm  { get; set; }

}