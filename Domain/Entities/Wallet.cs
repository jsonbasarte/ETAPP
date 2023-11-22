
namespace Domain.Entities;

public enum WalletType
{
    Cash = 1,
    EWallet = 2,
    Bank = 3,
};

public class Wallet
{
    public int Id { get; set; }
    public decimal Balance { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = null;
    public WalletType Type { get; set; }
}
