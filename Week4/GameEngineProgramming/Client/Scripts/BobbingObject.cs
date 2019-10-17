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
    class BobbingObject : ScriptComponent
    {
        public float BobbingAmount { get; set; }

        public Vector3 StartLocation { get; set; }

        private float MaxY, MinY;

        private bool IsMovingUp = true;

        public BobbingObject( float bobbing) : base()
        {
            BobbingAmount = bobbing;
        }

        public override void Initialize()
        {

            base.Initialize();
        }

        public override void Update()
        {
            if(IsMovingUp)
            {
                if(Owner.World.Translation.Y < MaxY)
                {
                    Owner.World *= Matrix.CreateTranslation(0, 1 * GameUtilities.DeltaTime, 0);
                }
                else
                {
                    IsMovingUp = false;
                }
            }
            else
            {
                if(Owner.World.Translation.Y > MinY)
                {
                    Owner.World *= Matrix.CreateTranslation(0, -1 * GameUtilities.DeltaTime, 0);
                }
                else
                {
                    IsMovingUp = true;
                }
            }

            base.Update();
        }
    }
}
