using System.Numerics;

public struct User 
{
    public BigInteger balance;
    public string address;

    public User(BigInteger _balance, string _address)
    {
        balance = _balance;
        address = _address;
    }
}
