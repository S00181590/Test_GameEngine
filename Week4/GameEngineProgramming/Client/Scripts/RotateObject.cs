using Client.GameObjects;
using Engine;
using Engine.Base;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Scripts
{
    class RotateObject : ScriptComponent
    {
        public Vector3 RotationToBeApplied { get; set; }

        public RotateObject(Vector3 rotation) : base()
        {
            RotationToBeApplied = rotation;
        }

        public override void Update()
        {
            Vector3 position = Owner.World.Translation;

            if(RotationToBeApplied.X > 0 || RotationToBeApplied.X < 0)
            {
                Owner.World *= Matrix.CreateTranslation(-position);
                Owner.World *= Matrix.CreateRotationX(RotationToBeApplied.X * GameUtilities.DeltaTime);
                Owner.World *= Matrix.CreateTranslation(position);
            }
            
            if(RotationToBeApplied.Y > 0 || RotationToBeApplied.Y < 0)
            {
                Owner.World *= Matrix.CreateTranslation(-position);
                Owner.World *= Matrix.CreateRotationY(RotationToBeApplied.Y * GameUtilities.DeltaTime);
                Owner.World *= Matrix.CreateTranslation(position);
            }

            if (RotationToBeApplied.Z > 0 || RotationToBeApplied.Z < 0)
            {
                Owner.World *= Matrix.CreateTranslation(-position);
                Owner.World *= Matrix.CreateRotationZ(RotationToBeApplied.Z * GameUtilities.DeltaTime);
                Owner.World *= Matrix.CreateTranslation(position);
            }


            base.Update();
        }
    }
}
