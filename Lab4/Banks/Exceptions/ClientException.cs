namespace Banks.Exceptions;

public class ClientException
{
    private ClientException(string message) { }

    public static ClientException NeedName()
    {
        return new ClientException("the client must have a name");
    }

    public static ClientException ClientDontExist()
    {
        return new ClientException("the client dont exist");
    }
}