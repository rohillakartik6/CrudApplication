namespace Assesment_KartikRohilla.Model
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public dynamic Result { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
    }
}
