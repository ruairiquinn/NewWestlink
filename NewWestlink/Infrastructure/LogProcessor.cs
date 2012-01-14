using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NewWestlink.Infrastructure
{
    public class LogProcessor
    {
        private readonly StreamReader _reader;
        private ConcurrentDictionary<string, int> _matches = new ConcurrentDictionary<string, int>();

        public LogProcessor(string path)
        {
            if(path == null)
            {
                throw new ArgumentNullException("path");
            }

            _reader = new StreamReader(path);

            FetchNextLine();
        }
        private void FetchNextLine()
        {
            _reader.ReadLineAsync().ContinueWith(ProcessLine);
        }

        private TaskCompletionSource<IDictionary<string, int>> _countCompletionSource = new TaskCompletionSource<IDictionary<string, int>>(); 
        public Task<IDictionary<string, int>> CountTask
        {
            get { return _countCompletionSource.Task; }
        }
     
        private void ProcessLine(Task<string> t)
        {
            string line = t.Result;
            string searchText = "Test";

            if(line != null)
            {
                if(line.Contains(searchText))
                {
                    _matches.AddOrUpdate(line, 1, (x, count) => count + 1);
                }
                FetchNextLine();
            }
            else
            {
                _reader.Close();
                _countCompletionSource.SetResult(_matches);
            }
        }
    }
}