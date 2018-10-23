
namespace EEP.BL.Classes
{
    public class OperationResult : IOperationResult
    {
        public OperationResult(bool succeeded, string message, string prop)
        {
            Succeeded = succeeded;
            Message = message;
            Property = prop;
        }

        public bool Succeeded { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }
    }
}
