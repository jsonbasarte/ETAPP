namespace Domain.Entities;

public class ExpenseEntry
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public int PaymentMethodId { get; set; }
    public string Subject { get; set; }
    public decimal Amount { get; set; }
    public DateTime  Date { get; set; }
}
