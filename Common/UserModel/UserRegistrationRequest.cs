namespace Common.UserModel
{
    public class UserRegistrationRequest
    {
        public string firstName { get; set; }   
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int status { get; set; }
        public int role { get; set; }
        public int pincode { get; set; }
        public int otp { get; set; }
        public int gender { get; set; }
        public DateTime registerdate { get; set; }
        public string emergencycontact { get; set; }
        public int device { get; set; }
        public bool istermsandcondition { get; set; }
        public string updatedby { get; set; }
        public int clubid { get; set; }
        public bool isactive { get; set; }
        public DateTime updateddate { get; set; }
        public int company { get; set; }
    }

    public class ImageUploadRequest
    {
        public string imageurl { get; set; }
        public string imagename { get; set; }
    }

}