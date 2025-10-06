using System;
using System.Collections.Generic;
using System.Linq;

namespace AppProduct.Module_2
{
    class User
    {
        public string Name { get; set; }
        public string Email { get; }
        public string Role { get; set; }

        public User(string name, string email, string role)
        {
            Name = name;
            Email = email;
            Role = role;
        }

        public override string ToString() => $"{Name} <{Email}> ({Role})";
    }

    class UserManager
    {
        private readonly List<User> users = new List<User>();

        public bool AddUser(User user)
        {
            if (user == null) return false;
            if (FindIndex(user.Email) >= 0) return false;
            users.Add(user);
            return true;
        }

        public bool RemoveUser(string email)
        {
            var idx = FindIndex(email);
            if (idx < 0) return false;
            users.RemoveAt(idx);
            return true;
        }

        public bool UpdateUser(string email, string newName, string newRole)
        {
            var idx = FindIndex(email);
            if (idx < 0) return false;
            var u = users[idx];
            u.Name = newName ?? u.Name;
            u.Role = newRole ?? u.Role;
            return true;
        }

        public IReadOnlyCollection<User> GetAll() => users.AsReadOnly();

        private int FindIndex(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return -1;
            return users.FindIndex(u => string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase));
        }
    }

    class Program
    {
        static void Main()
        {
            var mgr = new UserManager();

            var u1 = new User("Alice Johnson", "alice@example.com", "Admin");
            var u2 = new User("Bob Ivanov", "bob@example.com", "User");
            var u3 = new User("Carol Smith", "carol@example.com", "User");

            Console.WriteLine(mgr.AddUser(u1) ? "Added АЛиса" : "Failed to add alice");
            Console.WriteLine(mgr.AddUser(u2) ? "Добавлен бобик" : "Failed to add bob");
            Console.WriteLine(mgr.AddUser(u3) ? "+ Карл" : "Failed to add carol");
            Console.WriteLine(mgr.AddUser(new User("Alice Dup", "alice@example.com", "User")) ? "Added duplicate" : "Rejected duplicate");

            PrintAll(mgr);

            Console.WriteLine(mgr.UpdateUser("bob@example.com", "Boris Ivanov", "Admin") ? "Updated bob" : "Failed to update bob");
            Console.WriteLine(mgr.RemoveUser("carol@example.com") ? "Removed carol" : "Failed to remove carol");

            PrintAll(mgr);
        }

        static void PrintAll(UserManager mgr)
        {
            Console.WriteLine("\nUsers:");
            foreach (var u in mgr.GetAll()) Console.WriteLine($" - {u}");
            Console.WriteLine();
        }
    }
}
