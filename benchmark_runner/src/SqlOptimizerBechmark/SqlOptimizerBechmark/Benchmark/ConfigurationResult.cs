﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class ConfigurationResult : BenchmarkObject
    {
        private TestRun testRun;

        private int configurationId = 0;
        private string configurationName = string.Empty;
        private bool initScriptStarted = false;
        private bool initScriptCompleted = false;
        private string initScriptErrorMessage = string.Empty;
        private bool cleanUpScriptStarted = false;
        private bool cleanUpScriptCompleted = false;
        private string cleanUpScriptErrorMessage = string.Empty;


        public override IBenchmarkObject ParentObject => testRun;

        public int ConfigurationId
        {
            get => configurationId;
            set
            {
                if (configurationId != value)
                {
                    configurationId = value;
                    OnPropertyChanged("ConfigurationId");
                }
            }
        }

        public string ConfigurationName
        {
            get => configurationName;
            set
            {
                if (configurationName != value)
                {
                    configurationName = value;
                    OnPropertyChanged("ConfigurationName");
                }
            }
        }

        public bool InitScriptStarted
        {
            get => initScriptStarted;
            set
            {
                if (initScriptStarted != value)
                {
                    initScriptStarted = value;
                    OnPropertyChanged("InitScriptStarted");
                }
            }
        }

        public bool InitScriptCompleted
        {
            get => initScriptCompleted;
            set
            {
                if (initScriptCompleted != value)
                {
                    initScriptCompleted = value;
                    OnPropertyChanged("InitScriptCompleted");
                }
            }
        }

        public string InitScriptErrorMessage
        {
            get => initScriptErrorMessage;
            set
            {
                if (initScriptErrorMessage != value)
                {
                    initScriptErrorMessage = value;
                    OnPropertyChanged("InitScriptErrorMessage");
                }
            }
        }

        public bool CleanUpScriptStarted
        {
            get => cleanUpScriptStarted;
            set
            {
                if (cleanUpScriptStarted != value)
                {
                    cleanUpScriptStarted = value;
                    OnPropertyChanged("CleanUpScriptStarted");
                }
            }
        }

        public bool CleanUpScriptCompleted
        {
            get => cleanUpScriptCompleted;
            set
            {
                if (cleanUpScriptCompleted != value)
                {
                    cleanUpScriptCompleted = value;
                    OnPropertyChanged("CleanUpScriptCompleted");
                }
            }
        }

        public string CleanUpScriptErrorMessage
        {
            get => cleanUpScriptErrorMessage;
            set
            {
                if (cleanUpScriptErrorMessage != value)
                {
                    cleanUpScriptErrorMessage = value;
                    OnPropertyChanged("CleanUpScriptErrorMessage");
                }
            }
        }

        public ConfigurationResult(TestRun testRun)
        {
            this.testRun = testRun;
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadInt("configuration_id", ref configurationId);
            serializer.ReadString("configuration_name", ref configurationName);

            serializer.ReadBool("init_script_started", ref initScriptStarted);
            serializer.ReadBool("init_script_completed", ref initScriptCompleted);
            serializer.ReadString("init_error_message", ref initScriptErrorMessage);
            serializer.ReadBool("clean_up_script_started", ref cleanUpScriptStarted);
            serializer.ReadBool("clean_up_script_completed", ref cleanUpScriptCompleted);
            serializer.ReadString("clean_up_error_message", ref cleanUpScriptErrorMessage);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("configuration_id", configurationId);
            serializer.WriteString("configuration_name", configurationName);

            serializer.WriteBool("init_script_started", initScriptStarted);
            serializer.WriteBool("init_script_completed", initScriptCompleted);
            serializer.WriteString("init_error_message", initScriptErrorMessage);
            serializer.WriteBool("clean_up_script_started", cleanUpScriptStarted);
            serializer.WriteBool("clean_up_script_completed", cleanUpScriptCompleted);
            serializer.WriteString("clean_up_error_message", cleanUpScriptErrorMessage);
        }
    }
}
