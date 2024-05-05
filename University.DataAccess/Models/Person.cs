using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.DataAccess.Models
{
    public abstract class Person
    {
        public virtual long Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("first_name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column("last_name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(16)]
        [Column("fiscal_code")]
        public string FiscalCode { get; set; } = string.Empty;

        [MaxLength(50)]
        [Column("address")]
        public string? Address {  get; set; }

        [MaxLength(20)]
        [Column("telephone_no")]
        public string? TelephoneNo {  get; set; }

        [Required]
        [Column("active")]
        public bool Active { get; set; }


        public override string ToString()
            => $"Id: {Id} | Name: {FirstName} {LastName} | Fiscal Code: {FiscalCode} | Address: {Address} | Telephone number: {TelephoneNo} | Still Active: {Active}";
    }
}
