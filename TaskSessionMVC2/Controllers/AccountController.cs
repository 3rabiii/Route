using Microsoft.AspNetCore.Mvc;

namespace Session2.Controllers;

public class AccountController:  Controller
{
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }
    
}