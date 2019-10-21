using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.DbProviders
{
    public class QueryStatistics
    {
        private TimeSpan queryProcessingTime;
        private int resultSize;
        private DataTable result;

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

        public DataTable Result
        {
            get => result;
            set => result = value;
        }
    }
}
