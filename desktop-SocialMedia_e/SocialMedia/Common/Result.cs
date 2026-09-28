namespace SocialMedia.Common
{
    public class Result<T>
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public T? Value { get; set; }

        public Result(int status, string? message, T? value)
        {
            Status = status;  
            Message = message;
            Value = value;
        }

        public static Result<T> Ok(T value) => new(200, default, value);
        public static Result<T> BadRequest(string msg) => new(400, msg, default);
        public static Result<T> NotFound(string msg) => new(404, msg, default);
    }
}
