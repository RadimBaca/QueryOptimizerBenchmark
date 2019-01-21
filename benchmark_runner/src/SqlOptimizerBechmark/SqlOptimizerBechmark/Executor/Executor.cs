﻿using System;
using System.Collections.Generic;
using System.Data;
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
        private bool compareResults = true;
        private int queryRuns = 1;

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

        /// <summary>
        /// Test whether the test should be ignored due to some annotation.
        /// </summary>
        /// <param name="planEquivalenceTest"></param>
        /// <returns></returns>
        private bool IgnoreTest(Benchmark.PlanEquivalenceTest planEquivalenceTest)
        {
            foreach (Benchmark.SelectedAnnotation selectedAnnotation in planEquivalenceTest.SelectedAnnotations)
            {
                foreach (Benchmark.SelectedAnnotation ignoreAnnotation in Benchmark.TestRunSettings.IgnoreAnnotations)
                {
                    if (selectedAnnotation.AnnotationId == ignoreAnnotation.AnnotationId)
                    {
                        return true;
                    }
                }
            }
            return false;
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
                            if (IgnoreTest(planEquivalenceTest))
                            {
                                continue;
                            }

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

                            foreach (Benchmark.SelectedAnnotation selectedAnnotation in planEquivalenceTest.SelectedAnnotations)
                            {
                                Benchmark.SelectedAnnotationResult selectedAnnotationResult = new Benchmark.SelectedAnnotationResult(planEquivalenceTestResult);
                                selectedAnnotationResult.AnnotationId = selectedAnnotation.AnnotationId;
                                planEquivalenceTestResult.SelectedAnnotationResults.Add(selectedAnnotationResult);
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

            foreach (Benchmark.Annotation annotation in benchmark.Annotations)
            {
                Benchmark.AnnotationResult annotationResult = new Benchmark.AnnotationResult(testRun);
                annotationResult.AnnotationId = annotation.Id;
                annotationResult.AnnotationNumber = annotation.Number;
                annotationResult.AnnotationName = annotation.Name;
                testRun.AnnotationResults.Add(annotationResult);
            }

            benchmark.TestRuns.Add(testRun);
        }

        private bool CheckResultsEquality(IEnumerable<DataTable> results)
        {
            // First, make sure that the tables have the same number of rows and columns.
            int rowCount = -1;
            int columnCount = -1;
            foreach (DataTable result in results)
            {
                if (rowCount == -1)
                {
                    rowCount = result.Rows.Count;
                }
                else if (rowCount != result.Rows.Count)
                {
                    return false;
                }
                if (columnCount == -1)
                {
                    columnCount = result.Columns.Count;
                }
                else if (columnCount != result.Columns.Count)
                {
                    return false;
                }
            }

            // Rename columns to col_0, col_1, ..., since some of the columns might be unnamed.
            string sortExpr = string.Empty;
            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                string columnName = string.Format("col_{0}", columnIndex);
                if (!string.IsNullOrEmpty(sortExpr))
                {
                    sortExpr += ", ";
                }
                sortExpr += columnName + " ASC";

                foreach (DataTable result in results)
                {
                    result.Columns[columnIndex].ColumnName = columnName;
                }
            }

            // Prepare sorted views.
            List<DataView> dataViews = new List<DataView>();
            foreach (DataTable result in results)
            {
                DataView dataView = new DataView(result);
                dataView.Sort = sortExpr;
                dataViews.Add(dataView);
            }

            // Compare the content of the tables.
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    object val1 = null;

                    foreach (DataView dataView in dataViews)
                    {
                        object val2 = dataView[rowIndex][columnIndex];

                        if (val1 == null)
                        {
                            val1 = val2;
                        }
                        else
                        {
                            // The comparison of the values.
                            if (!object.Equals(val1, val2))
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Computes the average time span.
        /// If there are more than 2 timespans in the list, the best and the worst case are ignored.
        /// </summary>
        /// <param name="timeSpans"></param>
        /// <returns></returns>
        private TimeSpan ComputeAvgTimeSpan(IList<TimeSpan> timeSpans)
        {
            List<TimeSpan> copy = new List<TimeSpan>(timeSpans);
            copy.Sort();

            long sumOfTicks = 0;
            TimeSpan ret;

            if (copy.Count > 2)
            {
                for (int i = 1; i < copy.Count - 1; i++)
                {
                    sumOfTicks += copy[i].Ticks;
                }
                ret = new TimeSpan(sumOfTicks / (copy.Count - 2));
            }
            else
            {
                for (int i = 0; i < copy.Count; i++)
                {
                    sumOfTicks += copy[i].Ticks;
                }
                ret = new TimeSpan(sumOfTicks / copy.Count);
            }

            return ret;
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

                                    foreach (Benchmark.Test test in testGroup.Tests)
                                    {
                                        try
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
                                                    try
                                                    {

                                                        planEquivalenceTestResult.Started = true;
                                                        HashSet<DbProviders.QueryPlan> distinctPlans = new HashSet<DbProviders.QueryPlan>();
                                                        planEquivalenceTestResult.SuccessfullyCompletedVariants = 0;

                                                        Benchmark.PlanEquivalenceTest planEquivalenceTest = (Benchmark.PlanEquivalenceTest)test;

                                                        List<DataTable> results = new List<DataTable>();

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

                                                                List<TimeSpan> timeSpans = new List<TimeSpan>();
                                                                DbProviders.QueryStatistics lastStats = null;
                                                                for (int i = 0; i < queryRuns; i++)
                                                                {
                                                                    DbProviders.QueryStatistics stats = db.GetQueryStatistics(queryVariantResult.Query, compareResults);

                                                                    if (checkResultSizes && stats.ResultSize != planEquivalenceTest.ExpectedResultSize)
                                                                    {
                                                                        throw new Exception(string.Format("Unexpected result size ({0} instead of {1}).", stats.ResultSize, planEquivalenceTest.ExpectedResultSize));
                                                                    }

                                                                    timeSpans.Add(stats.QueryProcessingTime);
                                                                    lastStats = stats;
                                                                }
                                                                
                                                                queryVariantResult.QueryProcessingTime = ComputeAvgTimeSpan(timeSpans);
                                                                queryVariantResult.ResultSize = lastStats.ResultSize;

                                                                DbProviders.QueryPlan plan = db.GetQueryPlan(queryVariantResult.Query);
                                                                queryVariantResult.QueryPlan = plan;

                                                                if (compareResults)
                                                                {
                                                                    results.Add(lastStats.Result);
                                                                }

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

                                                        if (compareResults)
                                                        {
                                                            if (!CheckResultsEquality(results))
                                                            {
                                                                throw new Exception(string.Format("The query variants returned different results."));
                                                            }
                                                        }

                                                        ExecutorMessage messageCompleted = new ExecutorMessage();
                                                        messageCompleted.Message = string.Format("Test {0} completed.", planEquivalenceTestResult.TestName);
                                                        messageCompleted.MessageType = ExecutorMessageType.Info;
                                                        messageCompleted.Statement = string.Empty;
                                                        OnMessage(messageCompleted);

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        planEquivalenceTestResult.ErrorMessage = ex.Message;

                                                        ExecutorMessage message = new ExecutorMessage();
                                                        message.Message = ex.Message;
                                                        message.MessageType = ExecutorMessageType.Error;
                                                        message.Statement = string.Empty;
                                                        OnMessage(message);
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
            stopTesting = false;
            interruptTesting = false;
            testingThread = new Thread(Execute);
            testingThread.Start();
            OnTestingStarted();
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
            dialog.TestRunSettings = benchmark.TestRunSettings;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Prepare(dialog.TestRunName);
                runInitScript = benchmark.TestRunSettings.RunInitScript;
                runCleanUpScript = benchmark.TestRunSettings.RunCleanUpScript;
                checkResultSizes = benchmark.TestRunSettings.CheckResultSizes;
                compareResults = benchmark.TestRunSettings.CompareResults;
                queryRuns = benchmark.TestRunSettings.QueryRuns;

                StartTesting();
            }

        }
    }
}
