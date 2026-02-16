using System;
using System.Collections.Generic;
using System.Text;

namespace Fintalks.Common.Models
{
    public class ErrorResponse
    {
        public bool Success { get; set; } = false;
        public required string Message { get; set; }
        public object? Errors { get; set; }
        public string? Stack { get; set; }
    }
}
