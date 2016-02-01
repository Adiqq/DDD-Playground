namespace Hotel.Logic
{
    public class Guest : ValueObject<Guest>
    {
        private Guest()
        {
        }

        public Guest(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; }
        public string Surname { get; }

        protected override bool EqualsCore(Guest other)
        {
            return other.Name == Name && other.Surname == Surname;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hashCode = Name.GetHashCode();
                hashCode = (hashCode*397) ^ Surname.GetHashCode();
                return hashCode;
            }
        }
    }
}