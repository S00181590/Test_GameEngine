using BEPUphysics.Entities;
using Engine.Components.Graphics;
using Engine.Managers;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Base
{
    public abstract class PhysicsComponent : Component
    {
        public float Mass { get; set; }
        public Entity Entity { get; set; }

        public PhysicsComponent(float mass) : base()
        {
            Mass = mass;
        }

        public override void Update()
        {
            if(Entity != null)
            {
                Owner.World = MathConverter.Convert(Entity.WorldTransform);
            }

            base.Update();
        }

        public override void Initialized()
        {
            if(Entity != null)
            {
                GameObjectInfo Info = new GameObjectInfo()
                {
                    ID = Owner.ID,
                    GameObjectType = Owner.GetType()

                };
                Entity.Tag = Info;

                PhysicsManager.AddEntity(Entity);
            }
            base.Initialized();
        }

        protected Model TryAndGetModelFromOwner()
        {
            if(Owner.HasComponent<BasicEffectModel>())
            {
                return Owner.GetComponent<BasicEffectModel>().Model;
            }

            return null;
        }

        public class GameObjectInfo
        {
            public string ID { get; set; }

            public Type GameObjectType { get; set; }
        }
    }
}
