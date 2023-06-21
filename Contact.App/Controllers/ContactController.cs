using Contact.App.Mappers;
using Contact.App.Models.Contact;
using Contact.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Contact.App.Controllers;

public class ContactController : Controller
{
    private readonly IContactRepository _contactRepository;

    public ContactController(IContactRepository contactRepository) => _contactRepository = contactRepository;

    public IActionResult Index() => View(new ContactViewModel { Contacts = _contactRepository.Find() });

    [HttpPost]
    public IActionResult Index(ContactViewModel model)
    {
        if (!ModelState.IsValid) return View(new ContactViewModel { Contacts = _contactRepository.Find() });
        
        try
        {
            _contactRepository.Insert(model.ToBll());
            return View(new ContactViewModel { Contacts = _contactRepository.Find() });
        }
        catch (SqlException e)
        {
            ModelState.AddModelError("", "Email address has to be unique (already used)");
            Console.WriteLine(e.Message);
            return View(new ContactViewModel { Contacts = _contactRepository.Find() });
        }
    }

    [HttpPost]
    public IActionResult DeleteOne(int id)
    {
        _contactRepository.Remove(id);
        return RedirectToAction("Index", "Contact");
    }
}
