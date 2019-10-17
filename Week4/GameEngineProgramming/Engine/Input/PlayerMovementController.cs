using Engine.Base;
using Engine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Input
{
    public class PlayerMovementController : ScriptComponent
    {
        public float MovementSpeed { get; set; }

        public PlayerMovementController(float speed) : base()
        {
            MovementSpeed = speed;
        }

        public override void Update()
        {
            float time = GameUtilities.DeltaTime;
            float x = 0;
            float y = 0;
            float z = 0;

            if(InputManager.IsKeyHeld(Keys.A))
            {
                x = -2f * time;
            }
            else if(InputManager.IsKeyHeld(Keys.D))
            {
                x = 2f * time;
            }

            if(InputManager.IsKeyHeld(Keys.S))
            {
                z = 2f * time;
            }
            else if (InputManager.IsKeyHeld(Keys.W))
            {
                z = -2f * time;
            }

            Owner.World *= Matrix.CreateTranslation(x, y, z);


            base.Update();
        }
    }
}
