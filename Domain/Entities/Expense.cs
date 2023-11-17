﻿using ETAPP.Domain.Entities;

namespace Domain.Entities;

public class Expense
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public int PaymentMethodId { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime  Date { get; set; }
    public Categories Category { get; set; } = null;
    public PaymentType PaymentType { get; set; } = null;
}