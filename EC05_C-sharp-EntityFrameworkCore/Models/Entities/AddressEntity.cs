using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_EntityFrameworkCore.Models.Entities
{

    internal class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;
        public string ProductName { get; set; } = null!;
    }


    internal class AddressEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string StreetName { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(6)")]
        public string PostalCode { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = null!;

        public ICollection<CustomerEntity> Customers = new HashSet<CustomerEntity>();
    }

    internal class CustomerEntity
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Column(TypeName = "char(13)")]
        public string? PhoneNumber { get; set; }

        public int AddressId { get; set; }
        public AddressEntity Address { get; set; } = null!;
    }
}
