using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Executor
{
    public class Executor
    {
        private static Executor instance = new Executor();
        private Benchmark.Benchmark benchmark;
        private Benchmark.TestRun testRun;
        private Thread testingThread = null;
        private bool runInitScript = true;
        private bool runCleanUpScript = true;
        private bool checkResultSizes = true;

        private volatile bool stopTesting = false;
        private volatile bool interruptTesting = false;

        public static Executor Instance => instance;

        public Benchmark.Benchmark Benchmark => benchmark;

        public Benchmark.TestRun TestRun => testRun;

        public bool Testing => testingThread != null;


        public event EventHandler<ExecutorMessageEventArgs> Message;
        
        protected virtual void OnMessage(ExecutorMessage message)
        {
            if (Message != null)
            {
                Message(this, new ExecutorMessageEventArgs(message));
            }
        }

        public event EventHandler TestingStarted;

        protected virtual void OnTestingStarted()
        {
            if (TestingStarted != null)
            {
                TestingStarted(this, EventArgs.Empty);
            }
        }

        public event EventHandler TestingEnded;

        protected virtual void OnTestingEnded()
        {
            if (TestingEnded != null)
            {
                TestingEnded(this, EventArgs.Empty);
            }
        }

        public void Prepare(string name)
        {
            if (benchmark == null)
            {
                throw new Exception("Benchmark is not set.");
            }

            DbProviders.DbProvider db = benchmark.ConnectionSettings.DbProvider;
            
            testRun = new Benchmark.TestRun(benchmark);
            testRun.Name = name;

            foreach (Benchmark.TestGroup testGroup in benchmark.TestGroups)
            {
                Benchmark.TestGroupResult testGroupResult = new Benchmark.TestGroupResult(testRun);
                testGroupResult.TestGroupId = testGroup.Id;
                testGroupResult.TestGroupNumber = testGroup.Number;
                testGroupResult.TestGroupName = testGroup.Name;
                testRun.TestGroupResults.Add(testGroupResult);

                foreach (Benchmark.Configuration configuration in testGroup.Configurations)
                {
                    Benchmark.ConfigurationResult configurationResult = new Benchmark.ConfigurationResult(testRun);
                    configurationResult.ConfigurationId = configuration.Id;
                    configurationResult.ConfigurationNumber = configuration.Number;
                    configurationResult.ConfigurationName = configuration.Name;
                    testRun.ConfigurationResults.Add(configurationResult);

                    foreach (Benchmark.Test test in testGroup.Tests)
                    {
                        if (!test.Active)
                        {
                            continue;
                        }

                        if (test is Benchmark.PlanEquivalenceTest planEquivalenceTest)
                        {
                            Benchmark.PlanEquivalenceTestResult planEquivalenceTestResult = new Benchmark.PlanEquivalenceTestResult(testRun);
                            planEquivalenceTestResult.TestId = test.Id;
                            planEquivalenceTestResult.TestNumber = test.Number;
                            planEquivalenceTestResult.TestName = test.Name;
                            planEquivalenceTestResult.TestGroupId = testGroup.Id;
                            planEquivalenceTestResult.ConfigurationId = configuration.Id;

                            foreach (Benchmark.QueryVariant variant in planEquivalenceTest.Variants)
                            {
                                Benchmark.QueryVariantResult queryVariantResult = new Benchmark.QueryVariantResult(planEquivalenceTestResult);
                                Benchmark.Statement statement = variant.GetStatement(db.Name);

                                // Skip not supported variants.
                                if (statement is Benchmark.SpecificStatement specificStatement)
                                {
                                    if (specificStatement.NotSupported)
                                    {
                                        continue;
                                    }
                                }

                                queryVariantResult.Query = statement.CommandText;
                                queryVariantResult.QueryVariantId = variant.Id;
                                queryVariantResult.QueryVariantNumber = variant.Number;
                                queryVariantResult.QueryVariantName = variant.Name;
                                planEquivalenceTestResult.QueryVariantResults.Add(queryVariantResult);
                            }

                            if (planEquivalenceTestResult.QueryVariantResults.Count > 0)
                            {
                                testRun.TestResults.Add(planEquivalenceTestResult);
                            }
                        }
                        // TODO - other test types.
                    }
                }
            }

            benchmark.TestRuns.Add(testRun);
        }

        private void Execute()
        {
            try
            {
                DbProviders.DbProvider db = benchmark.ConnectionSettings.DbProvider;
                db.Connect();

                // Init script.
                if (runInitScript)
                {
                    Benchmark.StatementList initScriptStatements = benchmark.InitScript.GetStatementList(db.Name);
                    foreach (Benchmark.Statement statement in initScriptStatements.Statements)
                    {
                        if (interruptTesting)
                        {
                            testingThread = null;
                            OnTestingEnded();
                            return;
                        }

                        string commandText = statement.CommandText;
                        try
                        {
                            db.Execute(commandText);

                            ExecutorMessage message = new ExecutorMessage();
                            message.Message = "Statement completed";
                            message.MessageType = ExecutorMessageType.Info;
                            message.Statement = commandText;

                            OnMessage(message);
                        }
                        catch (Exception ex)
                        {
                            ExecutorMessage message = new ExecutorMessage();
                            message.Message = ex.Message;
                            message.MessageType = ExecutorMessageType.Error;
                            message.Statement = commandText;

                            OnMessage(message);
                            testingThread = null;
                            OnTestingEnded();
                            return;
                        }
                    }
                }

                try
                {
                    foreach (Benchmark.TestGroup testGroup in benchmark.TestGroups)
                    {
                        if (interruptTesting)
                        {
                            testingThread = null;
                            OnTestingEnded();
                            return;
                        }
                        if (stopTesting)
                        {
                            break;
                        }

                        bool activeTests = false;
                        foreach (Benchmark.Test test in testGroup.Tests)
                        {
                            if (test.Active)
                            {
                                activeTests = true;
                                break;
                            }
                        }

                        if (activeTests)
                        {
                            foreach (Benchmark.Configuration configuration in testGroup.Configurations)
                            {
                                if (interruptTesting)
                                {
                                    testingThread = null;
                                    OnTestingEnded();
                                    return;
                                }
                                if (stopTesting)
                                {
                                    break;
                                }

                                Benchmark.ConfigurationResult currentConfigurationResult = null;
                                foreach (Benchmark.ConfigurationResult configurationResult in testRun.ConfigurationResults)
                                {
                                    if (configurationResult.ConfigurationId == configuration.Id)
                                    {
                                        currentConfigurationResult = configurationResult;
                                        break;
                                    }
                                }
                                
                                try
                                {
                                    // Init script.
                                    currentConfigurationResult.InitScriptStarted = true;

                                    Benchmark.StatementList configurationInitScriptStatements = configuration.InitScript.GetStatementList(db.Name);
                                    foreach (Benchmark.Statement statement in configurationInitScriptStatements.Statements)
                                    {
                                        if (interruptTesting)
                                        {
                                            testingThread = null;
                                            OnTestingEnded();
                                            return;
                                        }

                                        string commandText = statement.CommandText;
                                        try
                                        {
                                            db.Execute(commandText);

                                            ExecutorMessage message = new ExecutorMessage();
                                            message.Message = "Statement completed";
                                            message.MessageType = ExecutorMessageType.Info;
                                            message.Statement = commandText;

                                            OnMessage(message);
                                        }
                                        catch (Exception ex)
                                        {
                                            currentConfigurationResult.InitScriptErrorMessage = ex.Message;

                                            ExecutorMessage message = new ExecutorMessage();
                                            message.Message = ex.Message;
                                            message.MessageType = ExecutorMessageType.Error;
                                            message.Statement = commandText;

                                            OnMessage(message);
                                            testingThread = null;
                                            OnTestingEnded();
                                            return;
                                        }
                                    }
                                    currentConfigurationResult.InitScriptCompleted = true;


                                    try
                                    {
                                        foreach (Benchmark.Test test in testGroup.Tests)
                                        {
                                            if (!test.Active)
                                            {
                                                continue;
                                            }

                                            if (interruptTesting)
                                            {
                                                testingThread = null;
                                                OnTestingEnded();
                                                return;
                                            }
                                            if (stopTesting)
                                            {
                                                break;
                                            }

                                            Benchmark.TestResult currentTestResult = null;
                                            foreach (Benchmark.TestResult testResult in testRun.TestResults)
                                            {
                                                if (testResult.TestId == test.Id &&
                                                    testResult.ConfigurationId == configuration.Id)
                                                {
                                                    currentTestResult = testResult;
                                                    break;
                                                }
                                            }
                                            if (currentTestResult != null)
                                            {
                                                if (currentTestResult is Benchmark.PlanEquivalenceTestResult planEquivalenceTestResult)
                                                {
                                                    planEquivalenceTestResult.Started = true;
                                                    HashSet<string> distinctPlans = new HashSet<string>();
                                                    planEquivalenceTestResult.SuccessfullyCompletedVariants = 0;

                                                    Benchmark.PlanEquivalenceTest planEquivalenceTest = (Benchmark.PlanEquivalenceTest)test;

                                                    foreach (Benchmark.QueryVariantResult queryVariantResult in planEquivalenceTestResult.QueryVariantResults)
                                                    {
                                                        try
                                                        {
                                                            if (interruptTesting)
                                                            {
                                                                testingThread = null;
                                                                OnTestingEnded();
                                                                return;
                                                            }
                                                            if (stopTesting)
                                                            {
                                                                break;
                                                            }

                                                            queryVariantResult.Started = true;

                                                            DbProviders.QueryStatistics stats = db.GetQueryStatistics(queryVariantResult.Query);
                                                            string plan = db.GetQueryPlan(queryVariantResult.Query);

                                                            if (checkResultSizes && stats.ResultSize != planEquivalenceTest.ExpectedResultSize)
                                                            {
                                                                throw new Exception(string.Format("Unexpected result size ({0} instead of {1}).", stats.ResultSize, planEquivalenceTest.ExpectedResultSize));
                                                            }

                                                            queryVariantResult.QueryProcessingTime = stats.QueryProcessingTime;
                                                            queryVariantResult.ResultSize = stats.ResultSize;
                                                            queryVariantResult.QueryPlan = plan;

                                                            //// TODO - remove.
                                                            //planEquivalenceTest.ExpectedResultSize = stats.ResultSize;
                                                            //break;

                                                            if (!distinctPlans.Contains(plan))
                                                            {
                                                                distinctPlans.Add(plan);
                                                            }

                                                            ExecutorMessage message = new ExecutorMessage();
                                                            message.Message = "Query executed";
                                                            message.MessageType = ExecutorMessageType.Info;
                                                            message.Statement = queryVariantResult.Query;
                                                            planEquivalenceTestResult.SuccessfullyCompletedVariants++;

                                                            OnMessage(message);
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            queryVariantResult.ErrorMessage = ex.Message;

                                                            ExecutorMessage message = new ExecutorMessage();
                                                            message.Message = ex.Message;
                                                            message.MessageType = ExecutorMessageType.Error;
                                                            message.Statement = queryVariantResult.Query;

                                                            OnMessage(message);
                                                        }
                                                        queryVariantResult.Completed = true;
                                                    }

                                                    planEquivalenceTestResult.DistinctQueryPlans = distinctPlans.Count;
                                                    planEquivalenceTestResult.Completed = true;

                                                    ExecutorMessage messageCompleted = new ExecutorMessage();
                                                    messageCompleted.Message = string.Format("Test {0} completed.", planEquivalenceTestResult.TestName);
                                                    messageCompleted.MessageType = ExecutorMessageType.Info;
                                                    messageCompleted.Statement = string.Empty;
                                                    OnMessage(messageCompleted);
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        ExecutorMessage message = new ExecutorMessage();
                                        message.Message = ex.Message;
                                        message.MessageType = ExecutorMessageType.Error;
                                        message.Statement = string.Empty;
                                        OnMessage(message);
                                    }

                                    // Clean up script.
                                    currentConfigurationResult.CleanUpScriptStarted = true;

                                    Benchmark.StatementList configurationCleanUpScriptStatements = configuration.CleanUpScript.GetStatementList(db.Name);
                                    foreach (Benchmark.Statement statement in configurationCleanUpScriptStatements.Statements)
                                    {
                                        if (interruptTesting)
                                        {
                                            testingThread = null;
                                            OnTestingEnded();
                                            return;
                                        }

                                        string commandText = statement.CommandText;
                                        try
                                        {
                                            db.Execute(commandText);

                                            ExecutorMessage message = new ExecutorMessage();
                                            message.Message = "Statement completed";
                                            message.MessageType = ExecutorMessageType.Info;
                                            message.Statement = commandText;

                                            OnMessage(message);
                                        }
                                        catch (Exception ex)
                                        {
                                            currentConfigurationResult.CleanUpScriptErrorMessage = ex.Message;

                                            ExecutorMessage message = new ExecutorMessage();
                                            message.Message = ex.Message;
                                            message.MessageType = ExecutorMessageType.Error;
                                            message.Statement = commandText;

                                            OnMessage(message);
                                            testingThread = null;
                                            OnTestingEnded();
                                            return;
                                        }
                                    }
                                    currentConfigurationResult.CleanUpScriptCompleted = true;
                                }
                                catch (Exception ex)
                                {
                                    ExecutorMessage message = new ExecutorMessage();
                                    message.Message = ex.Message;
                                    message.MessageType = ExecutorMessageType.Error;
                                    message.Statement = string.Empty;
                                    OnMessage(message);
                                }

                                //// TODO - remove.
                                //break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExecutorMessage message = new ExecutorMessage();
                    message.Message = ex.Message;
                    message.MessageType = ExecutorMessageType.Error;
                    message.Statement = string.Empty;
                    OnMessage(message);
                }

                // Clean up script.
                if (runCleanUpScript)
                {
                    Benchmark.StatementList cleanUpScriptStatements = benchmark.CleanUpScript.GetStatementList(db.Name);
                    foreach (Benchmark.Statement statement in cleanUpScriptStatements.Statements)
                    {
                        if (interruptTesting)
                        {
                            testingThread = null;
                            OnTestingEnded();
                            return;
                        }

                        string commandText = statement.CommandText;
                        try
                        {
                            db.Execute(commandText);

                            ExecutorMessage message = new ExecutorMessage();
                            message.Message = "Statement completed";
                            message.MessageType = ExecutorMessageType.Info;
                            message.Statement = commandText;

                            OnMessage(message);
                        }
                        catch (Exception ex)
                        {
                            ExecutorMessage message = new ExecutorMessage();
                            message.Message = ex.Message;
                            message.MessageType = ExecutorMessageType.Error;
                            message.Statement = commandText;

                            OnMessage(message);
                            testingThread = null;
                            OnTestingEnded();
                            return;
                        }
                    }
                }

                db.Close();
            }
            catch (Exception ex)
            {
                ExecutorMessage message = new ExecutorMessage();
                message.Message = ex.Message;
                message.MessageType = ExecutorMessageType.Error;
                message.Statement = string.Empty;
                OnMessage(message);
            }

            testingThread = null;
            OnTestingEnded();
        }

        public void StartTesting()
        {
            testingThread = new Thread(Execute);
            testingThread.Start();
            OnTestingStarted();
            stopTesting = false;
        }

        public void StopTesting()
        {
            ExecutorMessage message = new ExecutorMessage();
            message.Message = "User cancelled testing";
            message.MessageType = ExecutorMessageType.Warning;
            message.Statement = string.Empty;
            OnMessage(message);

            stopTesting = true;
        }

        public void InterruptTesting()
        {
            ExecutorMessage message = new ExecutorMessage();
            message.Message = "User interrupt testing";
            message.MessageType = ExecutorMessageType.Warning;
            message.Statement = string.Empty;
            OnMessage(message);

            interruptTesting = true;
        }

        public void LaunchTest(Benchmark.Benchmark benchmark)
        {
            this.benchmark = benchmark;

            if (benchmark.ConnectionSettings.DbProvider == null)
            {
                MessageBox.Show("Database connection is not set.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime now = DateTime.Now;

            Controls.NewTestRunDialog dialog = new Controls.NewTestRunDialog();
            dialog.TestRunName = now.ToString("yyyy-MM-dd HH:mm:ss");
            dialog.RunInitScript = runInitScript;
            dialog.RunCleanUpScript = runCleanUpScript;
            dialog.CheckResultSizes = checkResultSizes;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Prepare(dialog.TestRunName);
                runInitScript = dialog.RunInitScript;
                runCleanUpScript = dialog.RunCleanUpScript;
                checkResultSizes = dialog.CheckResultSizes;

                StartTesting();
            }

        }
    }
}
