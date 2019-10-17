using Engine.Managers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Base
{
    public abstract class CameraComponent : Component
    {
        public Matrix View { get; set; }
        public Matrix Projection { get; set; }

        public BoundingFrustum Frustum { get { return new BoundingFrustum(View * Projection); } }

        public float NearPlane { get; set; }
        public float FarPlane { get; set; }
        public Vector3 Target { get; set; }
        public Vector3 Direction { get; set; }
        public Vector3 UpVector { get; set; }

        //public CameraComponent(string Id) : base(Id) { }
        public CameraComponent() : base() { }

        public override void Initialize()
        {
            CameraManager.AddCameraq(this);

            base.Initialize();
        }

        public override void Destroy()
        {
            CameraManager.RemoveCamera(ID);

            base.Destroy();
        }


    }
}
