namespace Transversal.Common
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        public T Data { get; set; }

    }
}
