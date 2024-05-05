namespace Journey.Model
{
    public class EditProfileRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; }
    }

}
