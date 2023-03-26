using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.Domain.Entities
{
    public enum ItemStatus
    {
        New,
        Started,
        Idle,
        Completed,
        Cancelled
    }
}
