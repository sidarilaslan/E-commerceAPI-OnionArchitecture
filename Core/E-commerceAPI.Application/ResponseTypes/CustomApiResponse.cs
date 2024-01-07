using Newtonsoft.Json;

namespace E_commerceAPI.Application.ResponseTypes
{
    public class CustomApiResponse<T> : ICustomApiResponse<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int Status { get; set; }
        public string Message { get; set; }

        public static CustomApiResponse<T> Success(T data, int statusCode, string message)
            => new()
            { Data = data, Status = statusCode, Message = message };
        public static CustomApiResponse<T> Success(T data, int statusCode)
            => new()
            { Data = data, Status = statusCode };
        public static CustomApiResponse<T> Success(int statusCode, string message)
            => new()
            { Status = statusCode, Message = message };
        public static CustomApiResponse<T> Success(int statusCode = 200)
           => new()
           { Status = statusCode };
    }
}
