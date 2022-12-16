using Banks.BankAccount;

namespace Banks.Transaction;

public class Transaction : ITransaction
{
    public Transaction(decimal transferAmount, IBankAccount? translationSource, IBankAccount? toTranslation)
    {
        TransferAmount = transferAmount;
        TranslationSource = translationSource;
        ToTranslation = toTranslation;
        Id = Guid.NewGuid();
        Status = TransactionStatus.None;
    }

    public decimal TransferAmount { get; }
    public IBankAccount? TranslationSource { get; }
    public IBankAccount? ToTranslation { get; }
    public TransactionStatus Status { get; set; }
    public Guid Id { get; }
}