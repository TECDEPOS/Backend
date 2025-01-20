namespace DEP.Repository.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty; // Optional, for user-friendly messages
        public T? Data { get; set; } // Optional, for additional data
    }
}
