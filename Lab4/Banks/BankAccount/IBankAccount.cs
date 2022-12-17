using Banks.Client;
using Banks.Transaction;

namespace Banks.BankAccount;

public interface IBankAccount : ISubscriber
{
    public IClient Client { get; }
    public decimal Balance { get; }
    public void WithdrawMoney(decimal money);
    public void Replenishment(decimal money);
    public void WithdrawMoney(decimal money, IBankAccount toTranslation);
    public void Replenishment(decimal money, IBankAccount fromTranslation);
    public void TransferMoney(IBankAccount toTranslation, decimal money);
    public void CancelTransaction(ITransaction toCancel);
    public void DoTransaction(ITransaction transaction);
}