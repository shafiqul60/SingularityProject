using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.Entities
{

    [Table("Users")]
    public class User
    {
        public User()
        {
            CreatedDate = DateTime.Now;
            Roles = new HashSet<Role>();
        }

        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string UserName { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Password { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string FullName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
