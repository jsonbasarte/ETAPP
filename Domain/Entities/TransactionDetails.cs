using ETAPP.Domain.Entities;

namespace Domain.Entities;

public enum TransactionType
{
    Income = 1,
    Expense = 2,
}

public class TransactionDetails
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public int WalletId { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime  Date { get; set; }
    public Categories Category { get; set; } = null;
    public Wallet Wallet { get; set; }
    public TransactionType TransactionType { get; set; }
}