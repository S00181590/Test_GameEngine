using Client.Scripts;
using Engine.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GameObjects
{
    class TestObject : GameObject
    {
        public override void Initialize()
        {
            AddComponent(new testScript());

            base.Initialize();
        }
    }
}
