using System;

namespace Request
{
    public record PortionUpdateRequest
    {
        public int Weight { get; set; }
        public DateTime Date { get; set; }
    }
}