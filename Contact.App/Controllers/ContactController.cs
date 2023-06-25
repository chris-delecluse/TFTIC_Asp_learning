using Contact.App.Models.Contact;
using Contact.Cqs.Shared;
using Contact.Domain.Commands.Contact;
using Contact.Domain.Queries.Contact;
using Contact.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Contact.App.Controllers;

public class ContactController : Controller
{
    private readonly IContactRepository _contactRepository;

    public ContactController(IContactRepository contactRepository) => _contactRepository = contactRepository;

    public IActionResult Index() =>
        View(new ContactViewModel { Contacts = _contactRepository.Execute(new GetAllContactQuery()) });

    [HttpPost]
    public IActionResult Index(ContactViewModel model)
    {
        if (!ModelState.IsValid)
            return View(new ContactViewModel { Contacts = _contactRepository.Execute(new GetAllContactQuery()) });


        Result result = _contactRepository.Execute(new ContactCommand(model.FirstName,
                model.LastName,
                model.Email,
                model.BirthDate,
                model.PhoneNumber
            )
        );

        if (result.IsFailure)
        {
            ModelState.AddModelError("", "Email address has to be unique (already used)");
            return View(new ContactViewModel { Contacts = _contactRepository.Execute(new GetAllContactQuery()) });
        }

        return View(new ContactViewModel { Contacts = _contactRepository.Execute(new GetAllContactQuery()) });
    }

    [HttpPost]
    public IActionResult DeleteOne(int id)
    {
        _contactRepository.Execute(new RemoveContactCommand(id));
        return RedirectToAction("Index", "Contact");
    }
}
