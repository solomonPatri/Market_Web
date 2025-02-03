﻿namespace Market_Web.Markets.Dtos
{
    public class MarketUpdateRequest
    {

        public string? Name { get; set; }

        public int? Employee { get; set; }

        public DateOnly? Inauguration { get; set; }

        public double? SalesPerMonth { get; set; }


    }
}
