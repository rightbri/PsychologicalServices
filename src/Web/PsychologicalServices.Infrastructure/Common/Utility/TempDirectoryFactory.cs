using System;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public class TempDirectoryFactory : ITempDirectoryFactory
    {
        private readonly ITempPath _tempPath = null;

        public TempDirectoryFactory(
            ITempPath tempPath
        )
        {
            _tempPath = tempPath;
        }

        public ITempDirectory Create()
        {
            return new TempDirectory(_tempPath);
        }
    }
}
