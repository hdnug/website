using System.Linq;
using System.Net;
using System.Web.Mvc;
using Hdnug.Domain.Data.Models;
using Highway.Data;

namespace Hdnug.Web.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly IRepository _repo;

        public MeetingsController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: Meetings
        public ActionResult Index()
        {
            return View(_repo.Find(new FindAll<Meeting>()).ToList());
        }

        // GET: Meetings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = _repo.Find(new GetById<int, Meeting>((int)id));
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // GET: Meetings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,MeetingStartDateTime,MeetingEndDateTime,Location")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _repo.Context.Add(meeting);
                _repo.Context.Commit();
                return RedirectToAction("Index");
            }

            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = _repo.Find(new GetById<int, Meeting>((int)id));
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,MeetingDate,MeetingStartDateTime,MeetingEndDateTime,Location")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _repo.Context.Commit();
                return RedirectToAction("Index");
            }
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = _repo.Find(new GetById<int, Meeting>((int)id));
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meeting meeting = _repo.Find(new GetById<int, Meeting>((int)id));
            _repo.Context.Remove(meeting);
            _repo.Context.Commit();
            return RedirectToAction("Index");
        }
    }
}
