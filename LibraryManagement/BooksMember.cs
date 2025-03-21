using BooksProject.Interface;
using BooksProject.PropertySystem;

namespace BooksProject.LibraryManagement
{
    internal class BooksMember : MembersSystem, IMembers
    {
        private static int lastID = 1; 
        private static List<MembersSystem> members = new List<MembersSystem>
        {
            new MembersSystem() { Name = "user1", LastName = "kandelaki", Email = "kandelaki@gmail.com", Password = "123", RegistrationData = DateTime.Now, Id = lastID++ },
            new MembersSystem() { Name = "user2", LastName = "xubua", Email = "xubua@gmail.com", Password = "1122", RegistrationData = DateTime.Now, Id = lastID++ },
            new MembersSystem() { Name = "user3", LastName = "maisuradze", Email = "maisuradze@gmail.com", Password = "234", RegistrationData = DateTime.Now, Id = lastID++ },
        };

        public bool Login(string logName, string password)
        {
            MembersSystem loginMember = members.FirstOrDefault(m => m.Name == logName && m.Password == password);
            return loginMember != null;
        }

        public void Print()
        {
            foreach (MembersSystem item in members)
            {
                Console.WriteLine(item);
                Console.WriteLine("-------");
            }
        }

        public void RecoveryInformation(string name, MembersSystem upDateMember)
        {
            MembersSystem recoveryMember = members.FirstOrDefault(m => m.Name == name);
            if (recoveryMember != null)
            {
                recoveryMember.Password = upDateMember.Password;
                Console.WriteLine("Password Updated Successfully");
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }

        public void Registration(MembersSystem member)
        {
            if (members.Any(user => user.Name == member.Name))
            {
                Console.WriteLine("Username already exists");
            }
            else
            {
                member.Id = lastID++; 
                members.Add(member);
                Console.WriteLine("Registered Successfully");
            }
        }

        public void RemoveMember(int memberId)
        {
            MembersSystem removeMember = members.Find(mem => mem.Id == memberId);
            if (removeMember != null)
            {
                members.Remove(removeMember);
                Console.WriteLine("Member Removed Successfully");
            }
            else
            {
                Console.WriteLine("Member not found");
            }
        }

        public List<MembersSystem> Search(string memberName)
        {
            return members.Where(x => x.Name == memberName).ToList();
        }
    }
}
