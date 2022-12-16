using Banks.Bank;
using Banks.BankAccount;

namespace Banks.CentralBank;

public interface ICentralBank : IPublisher
{
    IReadOnlyCollection<IBank> Banks();
    public void AddBank(IBank newBank);
}