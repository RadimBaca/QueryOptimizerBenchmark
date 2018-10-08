using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Executor
{
    public enum ExecutorMessageType
    {
        StatementCompleted = 0,
        QueryExecuted = 1,
        Error = 2,
        UserCancelled = 3,
        UserInterrupt = 4,
        TestCompleted = 5
    }
}
