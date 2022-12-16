namespace Banks.TimeMachine;

public class TimeMachine
{
    private CentralBank.CentralBank _centralBank;
    private DateTime _currentTime;

    public TimeMachine(CentralBank.CentralBank centralBank)
    {
        _centralBank = centralBank;
        _currentTime = DateTime.Now;
    }

    public void RewindTime(int years, int months, int days)
    {
        DateTime tepmTime = _currentTime;
        _currentTime = _currentTime.AddYears(years).AddMonths(months).AddDays(days);
        while (tepmTime < _currentTime)
        {
            _centralBank.NotifySubscribers(tepmTime);
            tepmTime = tepmTime.AddDays(1);
        }
    }
}