namespace BlazorAppShared
{
    public  class ResponsePayload
    {
        public int? Status { get; set; }
        public string Message { get; set; }
    }
    public class ResponsePayload<T>: ResponsePayload
    {
        public T? Value { get; set; }
    }
}
