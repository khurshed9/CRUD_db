namespace CRUD_exam.Models;

public class Item
{
    public int Id { get; set; }

    public string? ItemName { get; set; }

    public decimal Price { get; set; }

    public int Amount { get; set; }

    public int market_Id { get; set; }
}