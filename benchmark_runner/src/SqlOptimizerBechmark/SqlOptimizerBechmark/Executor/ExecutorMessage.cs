using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Executor
{
    public class ExecutorMessage
    {
        private DateTime dateTime = DateTime.Now;
        private ExecutorMessageType messageType;
        private string message;
        private string statement;

        public DateTime DateTime
        {
            get => dateTime;
            set => dateTime = value;
        }
        
        public ExecutorMessageType MessageType
        {
            get => messageType;
            set => messageType = value;
        }

        public string Message
        {
            get => message;
            set => message = value;
        }

        public string Statement
        {
            get => statement;
            set => statement = value;
        }
    }
}
