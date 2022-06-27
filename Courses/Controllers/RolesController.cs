using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Courses.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public ActionResult Index() => View(roleManager.Roles.ToList());
        

        public async Task<ActionResult> Details(string id) => 
                            View(await roleManager.FindByIdAsync(id));
        

        [HttpGet]
        public ActionResult Create() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(new IdentityRole(role.Name));
            return RedirectToAction(nameof(Index));
        }
    }
}
