using Engine.Base;
using Engine.Components.Cameras;
using Engine.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GameObjects
{
    class SimplePlayerObject : GameObject
    {
        public SimplePlayerObject(Vector3 location) : base(location)
        {

        }

        public override void Initialize()
        {
            AddComponent(new FixedCamera("playerCamera", new Vector3(0,0,-1)));
            AddComponent(new PlayerMovementController(10));

            base.Initialize();
        }
    }
}
