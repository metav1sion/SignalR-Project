﻿namespace SignalRWebUI.Dtos.DiscountDtos
{
    public class GetDiscountDto
    {
        public int DiscountID { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
