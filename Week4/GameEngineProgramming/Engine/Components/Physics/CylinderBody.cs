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
    public class CylinderBody : PhysicsComponent
    {
        public CylinderBody(float mass)
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

                BoundingBox _aabb = BoundingBox.CreateFromPoints(vertices);
                Vector3 xsize = _aabb.Max - _aabb.Min;

                if (Mass <= 0)
                {
                    //kinematic
                    Entity = new Cylinder(MathConverter.Convert(Owner.World.Translation),
                        xsize.Y, xsize.X / 2);
                }
                else
                {
                    //dynamic
                    Entity = new Cylinder(MathConverter.Convert(Owner.World.Translation),
                         xsize.Y, xsize.X / 2, Mass);
                }
            }

            base.Initialize();
        }
    }
}
