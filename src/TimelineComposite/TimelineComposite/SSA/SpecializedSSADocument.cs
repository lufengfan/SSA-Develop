using SSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimelineComposite.SSA
{
    internal class SpecializedSSADocument : SSADocument
    {
        protected override SSASection CreateNamedSection(string name)
        {
            if (name == "Events")
                return new SpecializedSSAEventsSection();
            else
                return base.CreateNamedSection(name);
        }
    }
}
