using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SecretSanta.EntityModels;

namespace SecretSanta.Web.Pages
{
    public class ParticipantDetailModel : PageModel
    {
        public Participant? Participant { get; set; }
        private SecretSantaContext _db;
        public ParticipantDetailModel(SecretSantaContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            ViewData["Title"] = "Secret Santa - Participant Detail";
            string? id = HttpContext.Request.Query["id"];
            Participant = _db.Participants
                .SingleOrDefault(p => p.ParticipantId == int.Parse(id!));                 
        }
    }
}
