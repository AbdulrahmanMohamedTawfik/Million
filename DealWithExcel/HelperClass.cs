using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionLE
{
    public class HelperClass
    {
        //program language
        public string Language { get; set; } = "arabic";
        //program language
        public string Difficulty { get; set; } = "Easy";
        //answer of call friend puzzle question
        public bool IsCorrect { get; set; } = false;
        //sound state of the game
        public bool IsSoundOn { get; set; } = true;
        //indicates if help 50:50 is used because it affects people help and call friend help
        public bool IsHelp50Used { get; set; } = false;
    }
}
