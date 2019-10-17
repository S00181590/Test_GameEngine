using Client.GameObjects;
using Engine.Base;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Scripts
{
    class WayPointFollow : ScriptComponent
    {
        List<Vector3> WayPoints = new List<Vector3>();

        public WayPointFollow() : base()
        {

        }

        public override void Initialize()
        {
            var results = Owner.Scene.GetGameObjects<WayPoint>();
            base.Initialize();
        }
    }
}
