using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrateOS
{
    class User : IDisposable
    {
        
        public User(string email, string encrypted_password)
        {
            Email = email;
            Encrypted_Password = encrypted_password;
        }
        public void Dispose()
        {
            
        }
        public string Email { get; set;}
        public string Encrypted_Password { get; set; }
    }
}
