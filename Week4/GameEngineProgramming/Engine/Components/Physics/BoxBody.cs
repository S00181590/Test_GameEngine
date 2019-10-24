using BEPUphysics.Entities.Prefabs;
using Engine.Base;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Components.Physics
{
    public class BoxBody : PhysicsComponent
    {
        public BoxBody(float mass): base(mass)
        {
            
        }

        public override void Initialized()
        {
            var Model = TryAndGetModelFromOwner();

            if(Model != null)
            {
                Vector3[] Vertices;
                int[] indices;

                ModelDataExtractor.GetVerticesAndIndicesFromModel(Model,out Vertices, out indices);
                BoundingBox aabb = BoundingBox.CreateFromPoints(Vertices);
                Vector3 size = aabb.Max - aabb.Min;

                if (Mass <= 0)
                {
                    Entity = new Box(MathConverter.Convert(Owner.World.Translation), size.X, size.Y, size.Z);
                }
                else
                {
                    Entity = new Box(MathConverter.Convert(Owner.World.Translation), size.X, size.Y, size.Z, Mass);
                }
            }

            

            base.Initialized();
        }
    }
}
