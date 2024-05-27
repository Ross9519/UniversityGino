namespace University.Api.Dtos
{
    public class PersonDto
    {
        protected PersonDto() { }

        public virtual long Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FiscalCode { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? TelephoneNo { get; set; }

        public bool Active { get; set; }
    }
}
