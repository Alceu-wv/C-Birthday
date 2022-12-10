using BirthdayAT.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayAT.Controllers
{
    public class FriendController : Controller
    {

        private readonly ModelContext _db;

        public FriendController(
            ModelContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Friend/Delete/5
        public ActionResult Delete(string LastName)
        {
            var friends = _db.Friends;
            var frientToDelete = friends.Where(f => f.LastName == LastName).First();
            friends.Remove(frientToDelete);
            _db.SaveChanges();
           
            return View("~/Views/Home/Index.cshtml", friends.ToList());
        }

        // GET: Friend/Edit/5
        public ActionResult Edit(Friend friend)
        {
            return View((Friend)friend);
        }

        // POST: Friend/EditFriend/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFriend(IFormCollection friendData)
        {
            var friends = _db.Friends;
            var birthday = Convert.ToDateTime(friendData["Birthday"]);
            var firstName = (String)friendData["FirstName"];
            var lastName = (String)friendData["LastName"];
            var oldLastName = (String)friendData["OldLastName"];

            var frientToUpdate = friends.Where(f => f.LastName == oldLastName).First();
            frientToUpdate.FirstName = firstName;
            frientToUpdate.LastName = lastName;
            frientToUpdate.Birthday = birthday;
            _db.SaveChanges();
            
            return View("~/Views/Home/Index.cshtml", friends.ToList());
        }

    }
}
