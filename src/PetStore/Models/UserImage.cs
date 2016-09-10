namespace PetStore.Models
{
    public class UserImage
    {
        public string Id { get; set; }
        public string UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }
        public byte[] Image { get; set; }
    }
}