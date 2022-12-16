using Banks.Bank;
using Banks.Client;
using Banks.Exceptions;
using Banks.Transaction;

namespace Banks.BankAccount;

public class DebitBankAccount : IBankAccount
{
    private List<ITransaction> _history;
    private decimal _accumulatedInterest;

    public DebitBankAccount(IClient client, IBank bank)
    {
        _history = new List<ITransaction>();
        Client = client;
        Balance = 0;
        Bank = bank;
        Interest = bank.DebitInterest / 365;
        _accumulatedInterest = 0;
    }

    public IClient Client { get; }
    public decimal Balance { get; private set; }
    public double Interest { get; }
    public IBank Bank { get; }

    public IReadOnlyCollection<ITransaction> History() => _history;

    public void WithdrawMoney(decimal money)
    {
        if (Balance < money)
        {
            BankAccountException.NotEnoughMoney();
        }

        var newTransaction = new Transaction.Transaction(money, this, null);
        _history.Add(newTransaction);
        Balance -= money;
        newTransaction.Status = TransactionStatus.Completed;
    }

    public void Replenishment(decimal money)
    {
        var newTransaction = new Transaction.Transaction(money, null, this);
        _history.Add(newTransaction);
        Balance += money;
        newTransaction.Status = TransactionStatus.Completed;
    }

    public void WithdrawMoney(decimal money, IBankAccount toTranslation)
    {
        if (Balance < money)
        {
            BankAccountException.NotEnoughMoney();
        }

        var newTransaction = new Transaction.Transaction(money, this, toTranslation);
        _history.Add(newTransaction);
        Balance -= money;
        newTransaction.Status = TransactionStatus.Completed;
    }

    public void Replenishment(decimal money, IBankAccount fromTranslation)
    {
        var newTransaction = new Transaction.Transaction(money, fromTranslation, this);
        _history.Add(newTransaction);
        Balance += money;
        newTransaction.Status = TransactionStatus.Completed;
    }

    public void TransferMoney(IBankAccount toTranslation, decimal money)
    {
        this.WithdrawMoney(money, toTranslation);
        toTranslation.Replenishment(money, this);
    }

    public void CancelTransaction(ITransaction toCancel)
    {
        if (!_history.Contains(toCancel))
        {
            BankAccountException.TransactionNotFound();
        }

        if (toCancel.Status == TransactionStatus.Canceled)
        {
            BankAccountException.TransactionCanceled();
        }

        this.Replenishment(toCancel.TransferAmount);
        toCancel.Status = TransactionStatus.Canceled;
    }

    public void Update(DateTime time)
    {
        if (time.Day == 1)
        {
            this.Replenishment(_accumulatedInterest);
            _accumulatedInterest = 0;
        }

        _accumulatedInterest += Balance * (decimal)Interest;
    }
}