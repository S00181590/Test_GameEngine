using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine;
using Engine.Base;
using Engine.Components.Graphics;
using Engine.Managers;
using Microsoft.Xna.Framework;

namespace Client.Scripts
{
    public class BoundingVolumesTest : ScriptComponent
    {
        public BoundingBox AABB;
        public BoundingSphere AABS;

        Ray ray;
        public override void Initialized()
        {
            if(Owner.HasComponent<BasicEffectModel>())
            {
                BasicEffectModel modelComp = Owner.GetComponent<BasicEffectModel>();

                Vector3[] vertices;
                int[] indices;

                ModelDataExtractor.GetVerticesAndIndicesFromModel(modelComp.Model, out vertices, out indices);

                AABB = BoundingBox.CreateFromPoints(vertices);
                AABS = BoundingSphere.CreateFromPoints(vertices);

                AABS.Center = Vector3.Transform(AABS.Center, Owner.World);
                AABB.Max = Vector3.Transform(AABB.Max, Owner.World);
                AABB.Min = Vector3.Transform(AABB.Min, Owner.World);

                ray = new Ray(Owner.World.Translation, new Vector3(-1, 0, 0));

            }
            else
            {
                Destroy();
            }
            base.Initialized();
        }

        public override void Update()
        {
            DebugDrawer.AddBoundingBox(AABB, Color.Red, 2000);
            //DebugDrawer.AddBoundingSphere(AABS, Color.Yellow, 2000);

            DebugDrawer.AddLine(ray.Position, ray.Position + (ray.Direction * 10), Color.LawnGreen);
            base.Update();
        }

        public float? DoesRayIntersectWith(BoundingBox other)
        {
            return ray.Intersects(other);
        }
        public bool DoesIntersectWith(BoundingBox other)
        {
            if (AABB.Intersects(other))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
