using System;

namespace Response
{
    public record PortionResponse
    {
        public Guid Id { get; set; }
        public int Weight { get; set; }
        public DateTime Date { get; set; }
    }
}