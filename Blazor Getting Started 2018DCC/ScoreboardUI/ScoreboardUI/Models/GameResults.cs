using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreboardUI.Models
{
    public class GameResults
    {
        public int ID { get; set; }
        public string Sport { get; set; }
        public string HomeTeamName { get; set; }
        public int HomeTeamScore { get; set; }
        public string VisitorTeamName { get; set; }
        public int VisitorTeamScore { get; set; }
        public string Period { get; set; }
    }
}
