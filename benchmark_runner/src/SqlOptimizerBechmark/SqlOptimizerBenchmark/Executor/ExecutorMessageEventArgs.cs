using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Executor
{
    public class ExecutorMessageEventArgs: EventArgs
    {
        private ExecutorMessage message;

        public ExecutorMessage Message
        {
            get => message;
            set => message = value;
        }

        public ExecutorMessageEventArgs(ExecutorMessage message)
        {
            this.message = message;
        }
    }
}
