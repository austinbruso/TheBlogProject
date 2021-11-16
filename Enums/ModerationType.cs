using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogProject.Enums
{
    public enum ModerationType
    {
       [Description("Political Propaganda")]
       Political,
       [Description("Offensive language")]
       Language,
       [Description("Drug References")]
       Drug,
       [Description("Threatening")]
       Threatening,
       [Description("Sexual")]
       Sexual,
       [Description("Hate Speech")]
       HateSpeech,
       [Description("Targeted Shaming")]
       Shaming

    }
}
