using System;
using System.IO;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public class TempDirectory : ITempDirectory, IDisposable
    {
        private readonly ITempPath _tempPath = null;
        private bool _disposed;
        private DirectoryInfo _directoryInfo = null;

        public TempDirectory(
            ITempPath tempPath
        )
        {
            _tempPath = tempPath;
        }

        public string FullPath
        {
            get
            {
                var info = GetDirectoryInfo();

                return info.FullName;
            }
        }

        private DirectoryInfo GetDirectoryInfo()
        {
            if (null == _directoryInfo)
            {
                _directoryInfo = new DirectoryInfo(
                    Path.Combine(_tempPath.Path, Path.GetRandomFileName())
                );

                if (!_directoryInfo.Exists)
                {
                    _directoryInfo.Create();
                }
            }
            else
            {
                _directoryInfo.Refresh();
            }

            return _directoryInfo;
        }

        private void Cleanup()
        {
            _directoryInfo.Refresh();

            if (_directoryInfo.Exists)
            {
                _directoryInfo.Delete(true);
                _directoryInfo = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Cleanup();
                }

                _disposed = true;
            }
        }
    }
}
