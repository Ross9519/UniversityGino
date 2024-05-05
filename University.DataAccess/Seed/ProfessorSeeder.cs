using University.DataAccess.Models;

namespace University.DataAccess.Seed
{
    internal static class ProfessorSeeder
    {
        public static Professor JohnDoe = new()
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            SubjectId = 1,
            FiscalCode = "ABC123",
            Address = "123 Main St",
            TelephoneNo = "555-1234",
            Active = true
        };

        public static Professor JaneSmith = new()
        {
            Id = 2,
            FirstName = "Jane",
            LastName = "Smith",
            SubjectId = 2,
            FiscalCode = "DEF456",
            Address = "456 Oak St",
            TelephoneNo = "555-5678",
            Active = true
        };

        public static Professor MichaelJohnson = new()
        {
            Id = 3,
            FirstName = "Michael",
            LastName = "Johnson",
            SubjectId = 3,
            FiscalCode = "GHI789",
            Address = "789 Elm St",
            TelephoneNo = "555-9012",
            Active = true
        };

        public static Professor EmilyBrown = new()
        {
            Id = 4,
            FirstName = "Emily",
            LastName = "Brown",
            SubjectId = 4,
            FiscalCode = "JKL012",
            Address = "012 Pine St",
            TelephoneNo = null,
            Active = false
        };

        public static Professor DanielWilson = new()
        {
            Id = 5,
            FirstName = "Daniel",
            LastName = "Wilson",
            SubjectId = 5,
            FiscalCode = "MNO345",
            Address = "345 Cedar St",
            TelephoneNo = "555-3456",
            Active = true
        };

        public static ICollection<Professor> Professors =
        [
            JohnDoe,
            JaneSmith,
            MichaelJohnson,
            EmilyBrown,
            DanielWilson
        ];
    }
}
