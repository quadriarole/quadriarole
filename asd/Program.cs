
using System.Text.Json;
using asd;

User user = new User
{
    Name = "ade",
    Email = "ade@gmail.com",
    Password = "1234",
    Role = "Student",
};

string a = JsonSerializer.Serialize(user);
System.Console.WriteLine(a);

User b = JsonSerializer.Deserialize<User>(a);
System.Console.WriteLine(b.Name);
