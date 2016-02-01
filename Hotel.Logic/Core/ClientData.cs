using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Logic
{
    public class ClientData : ValueObject<ClientData>
    {
        public string Login { get; }
        public string EMailAdress { get; }
        public string Name { get; }
        public string Surname { get; }

        private ClientData()
        {
        }

        public ClientData(string login, string email, string name, string surname)
        {
            Login = login;
            EMailAdress = email;
            Name = name;
            Surname = surname;
        }

        protected override bool EqualsCore(ClientData other)
        {
            return other.EMailAdress == EMailAdress
                   && other.Login == Login
                   && other.Name == Name
                   && other.Surname == Surname;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hashCode = Name.GetHashCode();
                hashCode = (hashCode * 397) ^ Surname.GetHashCode();
                hashCode = (hashCode * 397) ^ Login.GetHashCode();
                hashCode = (hashCode * 397) ^ EMailAdress.GetHashCode();
                return hashCode;
            }
        }
    }
}
