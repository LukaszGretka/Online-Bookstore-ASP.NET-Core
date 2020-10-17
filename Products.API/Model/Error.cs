
namespace Products.API.Model
{
    //TODO: should be move to "Common" lately. But it required more project structure.
    public class Error
    {
        public Error(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}
