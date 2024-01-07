namespace E_commerceAPI.Application.ResponseTypes
{
    public interface ICustomApiResponse<T>
    {
        public T Data { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }

    }
}
