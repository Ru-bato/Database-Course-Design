namespace DB_Backend.DB_BackendModel
{
    public class User
    {
        public string User_ID { get; set; } // 账户，可以是手机号
        public string Username { get; set; } // 用户名一般是姓名
        public string Password { get; set; }
        public bool Is_Student {  get; set; }
        public bool Status {  get; set; } // 表示用户的状态（如正常、封禁），false代表被封禁，true代表正常
        public string ID_Number {  get; set; } // 身份证号
        public string Phone_Number {  get; set; }
        public string Riding_Interval {  get; set; } // 车次的起终点，格式：起始车站id_终点车站id
    }
}
