using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Timers;


namespace FileManager
{
    public partial class FileManager : ServiceBase
    {
        private Timer timer = null;
        public FileManager()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            FMHelper.WriteErrorLog("a inceput");
            FileWatcher.FileWatcherInitialisation();

        }

        
        protected override void OnStop()
        {
            FMHelper.WriteErrorLog("finish");
        }


    }
}
