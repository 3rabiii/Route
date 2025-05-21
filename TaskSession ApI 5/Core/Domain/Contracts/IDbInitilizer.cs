namespace Domain.Contracts;

public interface IDbInitilizer
{
    Task InitializeAsync();
    Task IdentityInitializeAsync();
}