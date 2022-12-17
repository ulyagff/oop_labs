using Banks.BankAccount;
using Banks.Exceptions;

namespace Banks.Client;

public class Client : IClient
{
    private List<IBankAccount> _accounts;
    private Client(string name, string? address, string? passportData, ClientStatusEnum status, List<IBankAccount> accounts)
    {
        _accounts = accounts;
        Name = name;
        Address = address;
        PassportData = passportData;
        Status = status;
        Id = Guid.NewGuid();
    }

    public string Name { get; }
    public string? Address { get; private set; }
    public string? PassportData { get; private set; }
    public Guid Id { get; }
    public ClientStatusEnum Status { get; private set; }
    public IReadOnlyCollection<IBankAccount> Accounts() => _accounts;
    public void AddAddress(string address)
    {
        Address = address;
        if (PassportData != null)
        {
            Status = ClientStatusEnum.Verified;
        }
    }

    public void AddPassportData(string data)
    {
        PassportData = data;
        if (Address != null)
        {
            Status = ClientStatusEnum.Verified;
        }
    }

    public void AddBankAccount(IBankAccount account)
    {
        _accounts.Add(account);
    }

    public class ClientBuilder
    {
        private string _name;
        private string? _address;
        private string? _passportData;
        private ClientStatusEnum _status;
        private List<IBankAccount> _accounts;

        public ClientBuilder()
        {
            _name = "name";
            _accounts = new List<IBankAccount>();
            _address = null;
            _passportData = null;
        }

        public void AddName(string name)
        {
            _name = name;
        }

        public void AddAddress(string address)
        {
            _address = address;
        }

        public void AddPassportData(string data)
        {
            _passportData = data;
        }

        public Client Build()
        {
            if (_name == "name")
            {
                ClientException.NeedName();
            }

            _status = ClientStatusEnum.Verified;
            if (_address == null || _passportData == null)
            {
                _status = ClientStatusEnum.Doubtful;
            }

            return new Client(_name, _address, _passportData, _status, _accounts);
        }
    }
}