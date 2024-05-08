namespace Journy.Model.features
{
    public class Pin
    {
        public int Id { get; set; }
        public UserAccount User { get; set; }
       
        public Post Posts { get; set; }
    }
}
