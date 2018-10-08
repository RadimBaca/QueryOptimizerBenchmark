using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.DbProviders
{
    public class QueryStatistics
    {
        private TimeSpan queryProcessingTime;
        private int resultSize;

        public TimeSpan QueryProcessingTime
        {
            get => queryProcessingTime;
            set => queryProcessingTime = value;
        }

        public int ResultSize
        {
            get => resultSize;
            set => resultSize = value;
        }
    }
}
