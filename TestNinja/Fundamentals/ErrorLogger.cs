using System;

namespace TestNinja.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }
        private Guid _errorId;

        public event EventHandler<Guid> ErrorLogged;

        public void Log(string error)
        {
            if (string.IsNullOrWhiteSpace(error))
            {
                throw new ArgumentNullException();
            }

            LastError = error;
            _errorId = new Guid();
            OnErrorLogged(Guid.NewGuid());
        }

        //Implementation detail. It can change to one version to another.
        public virtual void OnErrorLogged(Guid errorId)
            => ErrorLogged?.Invoke(this, errorId);
    }
}