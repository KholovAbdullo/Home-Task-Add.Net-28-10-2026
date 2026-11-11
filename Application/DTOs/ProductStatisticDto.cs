namespace Application.DTOs;

public class ProductStatisticDto
{
    public int AmountOfProducts { get; set; }
    public int AmountOfProductsByCategory { get; set; }
    public decimal MinPriceOfProduct { get; set; }
    public decimal MaxPriceOfProduct { get; set; }
    public decimal AveragePriceOfProduct { get; set; }
    public decimal TotalPriceOfProducts { get; set; }
}
