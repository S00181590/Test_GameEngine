using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine.Base;

namespace Client.Scripts
{
    public class testScript : ScriptComponent
    {
        public override void Update()
        {
            System.Diagnostics.Trace.Write("Test!");
            
            base.Update();
        }
    }
}
