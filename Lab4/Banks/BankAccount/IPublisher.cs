namespace Banks.BankAccount;

public interface IPublisher
{
    void AddSubscriber(ISubscriber subscriber);
    void RemoveSubscriber(ISubscriber subscriber);
    void NotifySubscribers(DateTime time);
}