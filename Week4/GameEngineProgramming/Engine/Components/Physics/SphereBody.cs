using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Engine.Base;
using BEPUphysics.Entities.Prefabs;

namespace Engine.Components.Physics
{
    public class SphereBody : PhysicsComponent
    {
        public SphereBody(float mass)
            : base( mass)
        {
        }

        public override void Initialize()
        {
            var model = TryAndGetModelFromOwner();

            if (model != null)
            {
                Vector3[] vertices;
                int[] indices;

                ModelDataExtractor.GetVerticesAndIndicesFromModel(model, out vertices, out indices);

                BoundingSphere _aabb = BoundingSphere.CreateFromPoints(vertices);

                if (Mass <= 0)
                {
                    //kinematic
                    Entity = new Sphere(MathConverter.Convert(Owner.World.Translation),
                        _aabb.Radius);
                }
                else
                {
                    //dynamic
                    Entity = new Sphere(MathConverter.Convert(Owner.World.Translation),
                        _aabb.Radius, Mass);
                }
            }

            base.Initialize();
        }
    }
}
