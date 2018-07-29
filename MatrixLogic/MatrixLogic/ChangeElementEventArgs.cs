namespace MatrixLogic
{
    public class ChangeElementEventArgs
    {
        public string Message { get;private set; }

        public ChangeElementEventArgs(string message)
        {
            Message = message;
        }
    }
}