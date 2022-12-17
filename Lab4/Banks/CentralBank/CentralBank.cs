using Banks.Bank;
using Banks.BankAccount;
using Banks.Exceptions;

namespace Banks.CentralBank;

public class CentralBank : ICentralBank
{
    private static CentralBank? _instance;
    private List<IBank> _banks;
    private List<ISubscriber> _subscribers;

    private CentralBank()
    {
        _banks = new List<IBank>();
        _subscribers = new List<ISubscriber>();
    }

    public static CentralBank GetInstance()
    {
        if (_instance == null)
            _instance = new CentralBank();
        return _instance;
    }

    public IReadOnlyCollection<IBank> Banks() => _banks;

    public void AddBank(IBank newBank)
    {
        if (_banks.Contains(newBank))
        {
            CentralBankException.BankExists();
        }

        _banks.Add(newBank);
        AddSubscriber(newBank);
    }

    public void AddSubscriber(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void RemoveSubscriber(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void NotifySubscribers(DateTime time)
    {
        foreach (ISubscriber subscriber in _subscribers)
        {
            subscriber.Update(time);
        }
    }
}