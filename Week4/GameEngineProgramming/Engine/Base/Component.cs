using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine;

namespace Engine.Base
{
    public class Component
    {
        public string ID { get; set; }
        public bool Enabled { get; set; }

        public GameObject Owner { get; set; }
        public event ObjectIDHandler OnDestroy;

        public Component()
        {
            ID = this.GetType().Name + Guid.NewGuid();
            Enabled = true;
        }

        public virtual void Initialize() { }
        public virtual void Initialized() { }

        public virtual void Update() { }

        public virtual void Destroy()
        {
            OnDestroy?.Invoke(ID);
        }
    }
}
