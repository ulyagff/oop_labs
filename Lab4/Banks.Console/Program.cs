using Banks.Bank;
using Banks.BankAccount;
using Banks.BankServise;
using Banks.Client;

namespace Banks.Console;
using Spectre.Console;
public static class Program
{
    public static void Main(string[] args)
    {
        AnsiConsole.Write(
            new FigletText("Banks")
                .Color(Color.Orange1));
        Thread.Sleep(1000);

        var service = new BankService();

        BankConsole.CreateBank(service);
        while (true)
        {
            string select = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("what do you want to do?")
                    .PageSize(10)
                    .AddChoices(new[]
                    {
                        "Create Bank", "Create Client", "Create Bank Account",
                        "Use Bank Account", "Rewind time",
                    }));
            switch (select)
            {
                case "Create Bank":
                    BankConsole.CreateBank(service);
                    break;
                case "Create Client":
                    ClientConsole.CreateClient(service);
                    break;
                case "Create Bank Account":
                    BankAccountConsole.CreateBankAccount(service);
                    break;
                case "Use Bank Account":
                    string selectBank = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Where your Bank Account?")
                            .PageSize(10)
                            .AddChoices(service.BanksName()));
                    IBank bank = service.GetBank(selectBank);

                    string selectAccount = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("which of these accounts is needed?")
                            .PageSize(10)
                            .AddChoices(bank.ClientOfAccount()));
                    IBankAccount account = bank.GetBankAccount(selectAccount);

                    string selectAction = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[red]what do you want to do with account[/]?")
                            .PageSize(10)
                            .AddChoices(new[]
                            {
                                "deposit money to the account",
                                "withdraw money from the account",
                                "transfer money",
                                "Check balance",
                            }));
                    switch (selectAction)
                    {
                        case "deposit money to the account":
                            BankAccountConsole.Replenishment(account);
                            AnsiConsole.MarkupLine("Done!");
                            break;
                        case "withdraw money from the account":
                            BankAccountConsole.WithdrawMoney(account);
                            AnsiConsole.MarkupLine("Done!");
                            break;
                        case "transfer money":
                            string selectBankTransfer = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("Where your Bank Account?")
                                    .PageSize(10)
                                    .AddChoices(service.BanksName()));
                            IBank bankToTransfer = service.GetBank(selectBank);

                            string selectAccountToTransfer = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("which of these accounts is needed?")
                                    .PageSize(10)
                                    .AddChoices(bank.ClientOfAccount()));
                            IBankAccount accountToTransfer = bank.GetBankAccount(selectAccount);
                            BankAccountConsole.TransferMoney(accountToTransfer);
                            AnsiConsole.MarkupLine("Done!");
                            break;
                        case "Check balance":
                            BankAccountConsole.Balance(account);
                            break;
                    }

                    break;
                case "Rewind time":
                    int year = AnsiConsole.Ask<int>("how many [lightpink3]years[/] do you want to rewind time by");
                    int month = AnsiConsole.Ask<int>("how many [lightpink3]month[/] do you want to rewind time by");
                    int days = AnsiConsole.Ask<int>("how many [lightpink3]day[/] do you want to rewind time by");
                    var timeMachine = new TimeMachine.TimeMachine(service.MainBank);
                    timeMachine.RewindTime(year, month, days);
                    break;
            }
        }
    }
}