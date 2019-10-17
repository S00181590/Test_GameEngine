using Client.Scripts;
using Engine.Base;
using Engine.Components.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GameObjects
{
    class SimpleMeshObject : GameObject
    {
        private string asset;

        public SimpleMeshObject(string Asset, Vector3 location) : base(location)
        {
            asset = Asset;
        }

        public override void Initialize()
        {
            AddComponent(new BasicEffectModel(asset));
            AddComponent(new BoundingVolumesTest());
            //AddComponent(new RotateObject(asset, new Vector3(0, 1, 0)));
            //AddComponent(new BobbingObject(asset, 2f));
            base.Initialize();
        }
    }
}
