
namespace Domain.Entities;

public enum WalletType
{
    Cash = 1,
    EWallet = 2,
    Bank = 3,
};

public class UserWallet
{
    public int Id { get; set; }
    public decimal Balance { get; set; }
    public int UserId { get; set; }
    public Wallet Wallet { get; set; } = null;
    public int WalletId { get; set; }
    public WalletType WalletType { get; set; }
}
