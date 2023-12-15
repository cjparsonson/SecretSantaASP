using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecretSanta.EntityModels;
using System.Runtime.CompilerServices;

namespace SecretSanta.Web.Pages
{
    public class MatchingModel : PageModel
    {
        private SecretSantaContext _db;
        public MatchingModel(SecretSantaContext db)
        {
            _db = db;
        }
        public IEnumerable<Participant>? Participants { get; set; }
        // Create a string list of participants
        private List<string>? _participants;
        public List<string>? matchedParticipants = new List<string>();
        public void OnGet()
        {
            ViewData["Title"] = "Matching";
            Participants = _db.Participants;
            _participants = Participants.Select(p => p.ParticipantName).ToList();
            MatchParticipants();
        }
        public IActionResult OnPost()
        {
            return Page();
        }
        public void MatchParticipants()
        {
            // randomize the list
            Random rnd = new Random();
            if (_participants is not null)
            {
                _participants = _participants.OrderBy(p => rnd.Next()).ToList();
                foreach (var participant in _participants)
                {
                    // if the participant is the last one in the list, match them with the first one
                    if (participant == _participants.Last())
                    {
                        matchedParticipants!.Add($"{participant} is matched with {_participants.First()}");
                    }
                    else
                    {
                        // otherwise, match them with the next participant in the list
                        matchedParticipants!.Add($"{participant} is matched with {_participants[_participants.IndexOf(participant) + 1]}");
                    }
                }
            }

        }


    }
}
