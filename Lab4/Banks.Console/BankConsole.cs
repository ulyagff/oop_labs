using Banks.Bank;
using Banks.BankServise;
using Spectre.Console;

namespace Banks.Console;

public class BankConsole
{
    public static void CreateBank(BankService service)
    {
        var depositRates = new List<DepositRate>();

        AnsiConsole.MarkupLine("let's create a [lightpink3]bank[/]\n");
        string name = AnsiConsole.Ask<string>("[lightpink3]enter the name of the bank[/]");
        double debit = AnsiConsole.Ask<double>("what is the annual rate of the [navy]debit account[/]?");
        int deposit = AnsiConsole.Ask<int>("how many levels will the [lightpink3]deposit account[/] have?");
        for (int i = 0; i < deposit; i++)
        {
            decimal upperLimit = AnsiConsole.Ask<decimal>("what is the [red]upper limit[/]?");
            double interest = AnsiConsole.Ask<double>("what is the [red]interest rate[/]?");
            depositRates.Add(new DepositRate(upperLimit, interest));
        }

        double creditInterest = AnsiConsole.Ask<double>("\nwhat is the [red]credit rate[/]?");
        decimal creditLimit = AnsiConsole.Ask<decimal>("what is the [red]credit limit[/]?");
        var bank = new Bank.Bank(name, debit, depositRates, creditInterest, creditLimit);
        service.AddBank(bank);
        AnsiConsole.Clear();
    }
}