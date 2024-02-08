namespace DevFreela.Core.Exceptions
{
    public class ProjectAlredyFinishedException : Exception
    {
        public ProjectAlredyFinishedException() : base("Project is in already finished status")
        {
            
        }
    }
}
