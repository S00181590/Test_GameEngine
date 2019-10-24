using BEPUphysics;
using BEPUphysics.BroadPhaseEntries;
using BEPUphysics.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Managers
{
    public class PhysicsManager : GameComponent
    {
        static Space WorldSpace;

        public PhysicsManager(Game game) : base(game)
        {
            WorldSpace = new Space();
            WorldSpace.ForceUpdater.Gravity = new BEPUutilities.Vector3(0, -9.8f, 0);

            game.Components.Add(this);
        }

        public override void Update(GameTime gameTime)
        {
            WorldSpace.Update(GameUtilities.DeltaTime);

            base.Update(gameTime);
        }

        public static void AddEntity(Entity entity)
        {
            if(!WorldSpace.Entities.Contains(entity))
            {
                WorldSpace.Add(entity);
            }
        }

        public static void RemoveEntity(Entity entity)
        {
            if(WorldSpace.Entities.Contains(entity))
            {
                WorldSpace.Remove(entity);
            }
        }

        public static void AddStaticMesh(StaticMesh mesh)
        {
            WorldSpace.Add(mesh);
        }

        public static void RemoveStaticMesh(StaticMesh mesh)
        {
            WorldSpace.Remove(mesh);
        }
    }
}
