using Banks.BankAccount;
using Banks.Client;

namespace Banks.Bank;

public class Bank : IBank
{
    private List<IBankAccount> _accounts;

    public Bank(string name, double debitInterest, List<DepositRate> depositRates, double creditInterest, decimal creditLimit)
    {
        Name = name;
        DebitInterest = debitInterest;
        DepositRates = depositRates;
        CreditInterest = creditInterest;
        CreditLimit = creditLimit;
        _accounts = new List<IBankAccount>();
    }

    public double DebitInterest { get; }
    public List<DepositRate> DepositRates { get; }
    public double CreditInterest { get; }
    public decimal CreditLimit { get; }
    public string Name { get; }
    public IReadOnlyCollection<IBankAccount> Accounts() => _accounts;

    public IEnumerable<string> ClientOfAccount()
    {
        return _accounts.Select(i => i.Client.Name);
    }

    public void AddBankAccount(IBankAccount bankAccount)
    {
        _accounts.Add(bankAccount);
    }

    public IBankAccount GetBankAccount(string clientName)
    {
        return _accounts.First(i => i.Client.Name == clientName);
    }

    public void Update(DateTime time)
    {
        foreach (IBankAccount subscriber in _accounts)
        {
            subscriber.Update(time);
        }
    }
}