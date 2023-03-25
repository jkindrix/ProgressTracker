using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.Domain
{
    public enum TaskStatus
    {
        New,
        Started,
        Idle,
        Completed,
        Cancelled
    }
}
