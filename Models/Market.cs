namespace CRUD_exam.Models;

public class Market
{
    public int Id { get; set; }

    public string? MarketName { get; set; }

    public string? Location { get; set; }

    public int ownerId { get; set; }
}