using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Managers;
using Engine.Base;

namespace Engine.Components.Cameras
{
    public class FixedCamera : CameraComponent
    {
        public FixedCamera(string id, Vector3 direction) : base()
        {
            NearPlane = 1.0f;
            FarPlane = 10000.0f;
            UpVector = Vector3.Up;

            Direction = direction;
            Direction.Normalize();
        }

        public override void Initialize()
        {
            Update();

            Projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.AspectRatio,
                NearPlane,
                FarPlane);

            //add to camera manager

            base.Initialize();
        }

        public override void Update()
        {
            Target = Owner.World.Translation + Direction;

            View = Matrix.CreateLookAt(
               Owner.World.Translation,
                Target,
                UpVector);

            base.Update();
        }
    }
}
