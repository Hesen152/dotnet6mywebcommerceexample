namespace ECommercenet6.Application.Abstractions.Token;

public interface ITokenHandler
{
    DTOs.Token   CreateAccessToken(int minute);

}