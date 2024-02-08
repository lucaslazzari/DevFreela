using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Exceptions
{
    public class ProjectAlredyFinishedException : Exception
    {
        public ProjectAlredyFinishedException() : base("Project is in already finished status")
        {
            
        }
    }
}
