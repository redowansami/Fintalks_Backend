using System;
using System.Collections.Generic;
using System.Text;

namespace Fintalks.Common.Interfaces
{
    public interface ISoftDeletable
    {
        public DateTime? DeletedAt { get; set; }
    }
}
