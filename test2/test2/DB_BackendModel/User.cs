namespace DB_BackendModel
{
    public class User
    {
        public string User_id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Id_number { get; set; } = string.Empty;
        public bool Is_student { get; set; }
        public bool Status { get; set; }
        public string Phone_number { get; set; } = string.Empty;
        public string Riding_interval { get; set; } = string.Empty;
    }
}

