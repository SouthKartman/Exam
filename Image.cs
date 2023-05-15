using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlazkiProgram
{
    public partial class Agent
    {
        public string img
        {
            get
            {
                if (Logo == "нет") return "/agents/picture.png";
                return Logo;
            }
             
        }
    }
}
