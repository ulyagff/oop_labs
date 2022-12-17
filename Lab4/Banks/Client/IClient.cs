using Banks.BankAccount;

namespace Banks.Client;

public interface IClient
{
    public string Name { get; }
    public string? Address { get; }
    public string? PassportData { get; }
    public ClientStatusEnum Status { get; }
    public Guid Id { get; }
    public IReadOnlyCollection<IBankAccount> Accounts();
}