using Banks.BankServise;
using Banks.Client;
using Spectre.Console;

namespace Banks.Console;

public class ClientConsole
{
    public static void CreateClient(BankService service)
    {
        AnsiConsole.MarkupLine("let's create a [lightpink3]client[/]\n");
        var builder = new Client.Client.ClientBuilder();
        string? name = AnsiConsole.Ask<string>("[lightpink3]enter the name of the client?[/]");
        builder.AddName(name);
        string? address = null;
        if (AnsiConsole.Confirm("Do you want to enter your address?"))
        {
            address = AnsiConsole.Ask<string>("[lightpink3]enter the address of the client[/]");
            builder.AddAddress(address);
        }

        string? passport = null;
        if (AnsiConsole.Confirm("Do you want to enter your passport data?"))
        {
            passport = AnsiConsole.Ask<string>("[lightpink3]enter the passport data of the client[/]");
            builder.AddPassportData(passport);
        }

        IClient client = builder.Build();
        service.AddClient(client);
        AnsiConsole.MarkupLineInterpolated($"ID of new client is {client.Id.ToString()}");
        Thread.Sleep(6000);

        AnsiConsole.Clear();
    }
}