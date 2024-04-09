﻿namespace SignalR.DtoLayer.ProductDto;

public class ResultProductWithCategoryDto
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public bool ProductStatus { get; set; }
    public string CategoryName { get; set; }
}