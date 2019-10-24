using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Engine.Managers;
using Engine.Base;
using BEPUphysics.Entities;
using BEPUphysics.DataStructures;
using BEPUphysics.BroadPhaseEntries;

namespace Engine.Components.Physics
{
    public class StaticMeshBody : PhysicsComponent
    {
        public StaticMeshBody()
            : base(0)
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

                var mesh = new StaticMesh(MathConverter.Convert(vertices), indices, 
                    new BEPUutilities.AffineTransform(MathConverter.Convert(Owner.World.Translation)));

                mesh.Tag = Owner.ID;

                //static mesh is the only exception when working with physics entities
                PhysicsManager.AddStaticMesh(mesh);
            }

            base.Initialize();
        }
    }
}
