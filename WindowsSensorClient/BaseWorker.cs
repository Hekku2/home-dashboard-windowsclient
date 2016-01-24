using System;
using System.Threading;

namespace WindowsSensorClient
{
    /// <summary>
    /// Common operations for workers. Handles thread things and cleanup.
    /// </summary>
    public abstract class BaseWorker : IDisposable
    {
        private readonly TimeSpan _interval;

        private bool _running;
        private Thread _thread;

        protected BaseWorker(TimeSpan interval)
        {
            _interval = interval;
        }

        protected abstract void OnWork();

        public void Start()
        {
            _running = true;
            _thread = new Thread(Work);
            _thread.Start();
        }

        private void Work()
        {
            while (_running)
            {
                OnWork();
                Thread.Sleep(_interval);
            }
        }

        public void Dispose()
        {
            _running = false;
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_thread == null) return;

                try
                {
                    _thread.Join(TimeSpan.FromSeconds(10));
                }
                catch (Exception)
                {
                    //TODO Log?
                }
            }
        }
    }
}
