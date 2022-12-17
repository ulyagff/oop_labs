using Banks.Bank;
using Banks.BankAccount;
using Banks.BankServise;
using Banks.Client;
using Spectre.Console;

namespace Banks.Console;

public class BankAccountConsole
{
    public static void CreateBankAccount(BankService service)
    {
        string selectAccount = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("which [red]bank account[/] do you want to create?")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "Debit", "Deposit", "Credit",
                }));
        string id = AnsiConsole.Ask<string>("enter the [lightpink3]id of the client[/] you want to create an account for");
        IClient client = service.GetClient(id);

        string selectBank = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("which [red]bank[/] do you want to create an account with?")
                .PageSize(10)
                .AddChoices(service.BanksName()));

        IBank bank = service.GetBank(selectBank);
        switch (selectAccount)
        {
            case "Debit":
                var debitBankAccount1 = new DebitBankAccount(client, bank);
                service.AddBankAccount(debitBankAccount1, bank);
                AnsiConsole.MarkupLine("Create debit account");
                break;
            case "Deposit":
                var debitBankAccount2 = new DebitBankAccount(client, bank);
                service.AddBankAccount(debitBankAccount2, bank);
                AnsiConsole.MarkupLine("Create deposit account");
                break;
            case "Credit":
                var debitBankAccount3 = new DebitBankAccount(client, bank);
                service.AddBankAccount(debitBankAccount3, bank);
                AnsiConsole.MarkupLine("Create credit account");
                break;
        }
    }

    public static void Replenishment(IBankAccount account)
    {
        decimal deposit = AnsiConsole.Ask<int>("how much money do you want to put into the account");
        account.Replenishment(deposit);
    }

    public static void WithdrawMoney(IBankAccount account)
    {
        decimal deposit = AnsiConsole.Ask<int>("how much money do you want withdraw from the account");
        account.WithdrawMoney(deposit);
    }

    public static void TransferMoney(IBankAccount account)
    {
        decimal deposit = AnsiConsole.Ask<int>("how much money do you want transfer to the account");
        account.TransferMoney(account, deposit);
    }

    public static void Balance(IBankAccount account)
    {
        AnsiConsole.MarkupLineInterpolated($"Balance is {account.Balance}");
    }
}