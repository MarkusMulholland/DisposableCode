using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.DisposePattern
{
    class DisposePatternDemo : IDisposable
    {
        private bool disposed;
        MemoryStream stream = new MemoryStream(); 
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                stream.Dispose();
            }

            disposed = true;
        }
    }
}
