namespace PetStore.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }

        public int TypeId { get; set; }
        public PetType Type { get; set; }

        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
