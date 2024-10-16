namespace Med_341A.viewmodels
{

    public class VMResponse
    {
        public VMResponse()
        {
            Success = true;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Entity { get; set; }
    }
}
