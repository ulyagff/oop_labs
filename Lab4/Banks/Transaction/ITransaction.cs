using Banks.BankAccount;

namespace Banks.Transaction;

public interface ITransaction
{
    public decimal TransferAmount { get; }
    public IBankAccount? TranslationSource { get; }
    public IBankAccount? ToTranslation { get; }
    public TransactionStatus Status { get; set; }
    public Guid Id { get; }
    public void Execute();
    public void Undo();
}