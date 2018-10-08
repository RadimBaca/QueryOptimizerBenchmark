using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Executor
{
    public class ExecutorMessageEventArgs: EventArgs
    {
        private string message;
        ExecutorMessageType messageType;

        public string Message
        {
            get => message;
        }

        public ExecutorMessageType MessageType
        {
            get => messageType;
        }

        public ExecutorMessageEventArgs(string message, ExecutorMessageType messageType)
        {
            this.message = message;
            this.messageType = messageType;
        }
    }
}
