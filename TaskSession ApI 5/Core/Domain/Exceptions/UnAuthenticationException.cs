namespace Domain.Exceptions;

public sealed class UnAuthenticationException(string msg = "Email or Password is not correct") : Exception(msg)
{
}