
namespace Products.API.Common
{
    public class ErrorResponse
    {
        public ErrorResponse(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }

        internal static ErrorResponse InvalidParameterValue(string parameterName)
        {
            return new ErrorResponse($"Invalid value of parameter: '{parameterName}'");
        }

        internal static ErrorResponse ItemWithIdNotFound(string parameterName, int id)
        {
            return new ErrorResponse($"Item '{parameterName}' with id: '{id}' not found");
        }
    }
}
