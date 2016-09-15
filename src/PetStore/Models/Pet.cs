namespace PetStore.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }

        public int TypeId { get; set; }
        public virtual PetType Type { get; set; }

        public int UserAccountId { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
