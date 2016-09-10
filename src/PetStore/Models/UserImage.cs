namespace PetStore.Models
{
    public class UserImage
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }
        public byte[] Image { get; set; }
    }
}