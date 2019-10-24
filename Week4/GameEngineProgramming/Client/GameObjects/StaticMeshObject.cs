using Engine.Base;
using Engine.Components.Graphics;
using Engine.Components.Physics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GameObjects
{
    class StaticMeshObject : GameObject
    {
        private string asset;

        public StaticMeshObject(string asset, Vector3 position) : base(position)
        {
            this.asset = asset;
        }

        public override void Initialize()
        {
            AddComponent(new BasicEffectModel(asset));
            AddComponent(new StaticMeshBody());

            base.Initialize();
        }
    }
}
