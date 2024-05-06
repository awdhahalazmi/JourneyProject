namespace Journy.Model.features
{
    public class Pin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserAccount Users { get; set; }
       
        public List<Post> Posts { get; set; }
    }
}
