using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Base
{
    public abstract class RenderComponent : Component
    {
        public RenderComponent() : base() { }
        //public RenderComponent(string Id) : base(Id) { }

        public virtual void Draw(CameraComponent camera) { }

    }
}
