using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Exceptions
{
    public class ProjectCancelledException : Exception
    {
        public ProjectCancelledException() : base("Project is in cancelled status")
        {
            
        }
    }
}
