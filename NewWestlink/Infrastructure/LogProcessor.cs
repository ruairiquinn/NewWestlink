using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace NewWestlink.Infrastructure
{
    public class LogProcessor
    {
        private readonly StreamReader _reader;
        private readonly ConcurrentDictionary<string, int> _matches = new ConcurrentDictionary<string, int>();
        private readonly TaskCompletionSource<IDictionary<string, int>> _countCompletionSource = new TaskCompletionSource<IDictionary<string, int>>(); 

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

        public Task<IDictionary<string, int>> CountTask
        {
            get { return _countCompletionSource.Task; }
        }
     
        private void ProcessLine(Task<string> t)
        {
            if(t.IsFaulted)
            {
                _reader.Close();
                // t has AggregateException, SetException would wrap it in an AggregateException, therefore wrap InnerExceptions instaead
                _countCompletionSource.SetException(t.Exception.InnerExceptions);
            }

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

        public static Task<T> RunAsync<T>(Func<T> function) 
        { 
            if (function == null) throw new ArgumentNullException("function"); 
            var tcs = new TaskCompletionSource<T>();

            var test = string.Empty;
            Task.Factory.StartNew(() =>
                             {
                                 test = "RQ Test";
                             });

            ThreadPool.QueueUserWorkItem(_ => 
            { 
                try 
                {  
                    T result = function(); 
                    tcs.SetResult(result);  
                } 
                catch(Exception exc)
                {
                    tcs.SetException(exc);
                } 
            }); 
            return tcs.Task; 
        }
    }
}