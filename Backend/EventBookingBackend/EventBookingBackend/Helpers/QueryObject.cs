﻿namespace EventBookingBackend.Helpers
{
    public class QueryObject
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Status { get; set; } = null;
    }
}