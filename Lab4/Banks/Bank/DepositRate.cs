namespace Banks.Bank;

public class DepositRate
{
    public DepositRate(decimal upperLimit, double interest)
    {
        UpperLimit = upperLimit;
        Interest = interest;
    }

    public decimal UpperLimit { get; }
    public double Interest { get; }
}