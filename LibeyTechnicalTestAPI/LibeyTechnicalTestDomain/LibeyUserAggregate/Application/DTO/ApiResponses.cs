namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public ApiResponse(T data, string message, bool success)
        {
            Data = data;
            Message = message;
            Success = success;
        }
    }
}