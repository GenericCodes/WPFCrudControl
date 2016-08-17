using System;

namespace GenericCodes.Core.DbContext
{
    public class ApplicationDbContext : System.Data.Entity.DbContext, IDisposable
    {

        #region Private Fields
        private readonly Guid _instanceId;
        bool _isDisposed;
        #endregion Private Fields

        #region public Fields
        public bool IsDisposed { get { return _isDisposed; } }
        public Guid InstanceId { get { return _instanceId; } }
        #endregion

        #region Constructor
        public ApplicationDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            _instanceId = Guid.NewGuid();
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        } 
        #endregion
       

        protected override void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    // free other managed objects that implement
                    // IDisposable only
                }
                // release any unmanaged objects
                // set object references to null
                _isDisposed = true;
            }
            base.Dispose(disposing);
        }
    }
}
