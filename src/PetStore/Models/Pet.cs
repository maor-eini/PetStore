namespace PetStore.Models
{
    public class Pet
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }

        public string TypeId { get; set; }
        public PetType Type { get; set; }

        public string UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
