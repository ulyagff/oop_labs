using Banks.Bank;
using Banks.BankAccount;
using Banks.Client;
using Banks.Exceptions;

namespace Banks.BankServise;

public class BankService
{
    private List<IClient> _clients;

    public BankService()
    {
        MainBank = new CentralBank.CentralBank();
        _clients = new List<IClient>();
    }

    public CentralBank.CentralBank MainBank { get; }

    public IReadOnlyCollection<IBank> Banks => MainBank.Banks();

    public IEnumerable<string> BanksName()
    {
        return MainBank.Banks().Select(i => i.Name);
    }

    public void AddClient(IClient client)
    {
        _clients.Add(client);
    }

    public void AddBank(IBank bank)
    {
        MainBank.AddBank(bank);
    }

    public void AddBankAccount(IBankAccount account, IBank bank)
    {
        bank.AddBankAccount(account);
    }

    public IClient GetClient(string id)
    {
        IClient client = _clients.First(i => i.Id == Guid.Parse(id));
        return client;
    }

    public IBank GetBank(string name)
    {
        IBank bank = MainBank.Banks().First(i => i.Name == name);
        return bank;
    }
}