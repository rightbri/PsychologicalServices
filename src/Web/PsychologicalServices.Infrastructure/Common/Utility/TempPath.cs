using System;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public class TempPath : ITempPath
    {
        public string Path
        {
            get
            {
                //return System.Environment.CurrentDirectory;
                return System.IO.Path.GetTempPath();
            }
        }
    }
}
