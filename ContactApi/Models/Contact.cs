using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.Models
{
    public class Contact : BaseModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public void CopyAtributesFrom(Contact contact)
        {
            Name = contact.Name;
            PhoneNumber = contact.PhoneNumber;
            Email = contact.Email;
        }
    }
}
