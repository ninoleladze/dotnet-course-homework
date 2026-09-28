namespace WebApplication4.Common
{
    public class ApiResponse<T>
    {
        public int Status { get; set; }
        public T? Value { get; set; }
        public string? Message { get; set; }
    }
}
