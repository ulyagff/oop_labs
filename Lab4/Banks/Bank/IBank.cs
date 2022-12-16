using Banks.BankAccount;
using Banks.Client;

namespace Banks.Bank;

public interface IBank : ISubscriber
{
    public string Name { get; }
    public double DebitInterest { get; }
    public List<DepositRate> DepositRates { get; }
    public double CreditInterest { get; }
    public decimal CreditLimit { get; }
    public IReadOnlyCollection<IBankAccount> Accounts();
    public IEnumerable<string> ClientOfAccount();
    public void AddBankAccount(IBankAccount bankAccount);
    public IBankAccount GetBankAccount(string clientName);
}