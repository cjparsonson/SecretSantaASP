using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecretSanta.EntityModels;

namespace SecretSanta.Web.Pages
{
    public class ParticipantsModel : PageModel
    {
        private SecretSantaContext _db;
        public ParticipantsModel(SecretSantaContext db)
        {
            _db = db;
        }
        public IEnumerable<Participant>? Participants { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Secret Santa - Participants";
            Participants = _db.Participants
                .OrderBy(p => p.ParticipantName);
        }
        [BindProperty]
        public Participant? Participant { get; set; }
        public IActionResult OnPost()
        {
            if (Participant is not null && ModelState.IsValid)
            {
                _db.Participants.Add(Participant);
                _db.SaveChanges();
                return RedirectToPage("/Participants");
            }
            else
            {
                return Page();
            }
        }
    }
}
