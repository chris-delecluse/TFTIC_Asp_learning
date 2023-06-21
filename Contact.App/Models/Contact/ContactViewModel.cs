using System.ComponentModel.DataAnnotations;
using Contact.BLL.Entities;

namespace Contact.App.Models.Contact;

#nullable  disable
public class ContactViewModel
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public DateTime BirthDate { get; set; } = DateTime.Today;

    [Required]
    public string PhoneNumber { get; set; } 
#nullable enable
    public IEnumerable<ContactEntity>? Contacts { get; set; }
}
