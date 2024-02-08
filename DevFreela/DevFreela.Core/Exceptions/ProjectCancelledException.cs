namespace DevFreela.Core.Exceptions
{
    public class ProjectCancelledException : Exception
    {
        public ProjectCancelledException() : base("Project is in cancelled status")
        {
            
        }
    }
}
