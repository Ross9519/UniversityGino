using University.DataAccess.Models;

namespace University.DataAccess.Seed
{
    internal static class OfficeStaffSeeder
    {
        public static OfficeStaff AliceJones = new()
        {
            Id = 1,
            FirstName = "Alice",
            LastName = "Jones",
            FiscalCode = "ABC123",
            Address = "123 Main St",
            TelephoneNo = "555-1234",
            Active = true
        };

        public static OfficeStaff BobSmith = new()
        {
            Id = 2,
            FirstName = "Bob",
            LastName = "Smith",
            FiscalCode = "DEF456",
            Address = "456 Oak St",
            TelephoneNo = "555-5678",
            Active = true
        };

        public static OfficeStaff CarolBrown = new()
        {
            Id = 3,
            FirstName = "Carol",
            LastName = "Brown",
            FiscalCode = "GHI789",
            Address = "789 Elm St",
            TelephoneNo = "555-9012",
            Active = true
        };

        public static OfficeStaff DavidWilson = new()
        {
            Id = 4,
            FirstName = "David",
            LastName = "Wilson",
            FiscalCode = "JKL012",
            Address = "012 Pine St",
            TelephoneNo = null,
            Active = false
        };

        public static OfficeStaff EvaMarquez = new()
        {
            Id = 5,
            FirstName = "Eva",
            LastName = "Marquez",
            FiscalCode = "MNO345",
            Address = "345 Cedar St",
            TelephoneNo = "555-3456",
            Active = true
        };

        public static ICollection<OfficeStaff> OfficeStaff =
        [
            AliceJones,
            BobSmith,
            CarolBrown,
            DavidWilson,
            EvaMarquez
        ];
    }
}
