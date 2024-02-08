namespace DevFreela.Core.Exceptions
{
    public class UserAlredyExistException : Exception
    {
        public UserAlredyExistException() : base("User alredy exist with this e-mail")
        {
            
        }
    }
}
