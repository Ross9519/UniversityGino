using University.DataAccess.Models;

namespace University.DataAccess.Seed
{
    internal static class StudentSeeder
    {
        public static Student AliceSmith = new()
        {
            Id = 1,
            FirstName = "Alice",
            LastName = "Smith",
            StudentNo = "STU001",
            FiscalCode = "ABC123",
            Address = "123 Main St",
            TelephoneNo = "555-1234",
            Active = true
        };

        public static Student BobJohnson = new()
        {
            Id = 2,
            FirstName = "Bob",
            LastName = "Johnson",
            StudentNo = "STU002",
            FiscalCode = "DEF456",
            Address = "456 Oak St",
            TelephoneNo = "555-5678",
            Active = true
        };

        public static Student CharlieBrown = new()
        {
            Id = 3,
            FirstName = "Charlie",
            LastName = "Brown",
            StudentNo = "STU003",
            FiscalCode = "GHI789",
            Address = "789 Elm St",
            TelephoneNo = "555-9012",
            Active = true
        };

        public static Student DianaWilson = new()
        {
            Id = 4,
            FirstName = "Diana",
            LastName = "Wilson",
            StudentNo = "STU004",
            FiscalCode = "JKL012",
            Address = "012 Pine St",
            TelephoneNo = null,
            Active = false
        };

        public static Student EvaGarcia = new()
        {
            Id = 5,
            FirstName = "Eva",
            LastName = "Garcia",
            StudentNo = "STU005",
            FiscalCode = "MNO345",
            Address = "345 Cedar St",
            TelephoneNo = "555-3456",
            Active = true
        };

        public static ICollection<Student> Students =
        [
            AliceSmith,
            BobJohnson,
            CharlieBrown,
            DianaWilson,
            EvaGarcia
        ];
    }
}
