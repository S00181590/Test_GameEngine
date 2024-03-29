﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.GameObjects;
using Client.Scripts;
using Engine;
using Engine.Base;
using Engine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Client.Scenes
{
    
    class TestScene : Scene
    {
        SimpleMeshObject cube1, cube2;

        BoundingVolumesTest cube1volume;
        BoundingVolumesTest Cube2Volume;

        public override void Initialize()
        {
            AddObject(new TestObject());

            AddObject(new SimplePlayerObject(new Vector3(0, 0, 100)));
            AddObject(new StaticMeshObject("plane", new Vector3(0, -2, 0)));
            //cube1 = new SimpleMeshObject("cube", new Vector3(0, 0, -10));
            //cube2 = new SimpleMeshObject("cube", new Vector3(5, 0, -10));

            //AddObject(cube1);
            //AddObject(cube2);

            base.Initialize();

            //cube1volume = cube1.GetComponent<BoundingVolumesTest>();
            //Cube2Volume = cube2.GetComponent<BoundingVolumesTest>();
        }

        void SpawnCube()
        {
            AddObject(new SimpleMeshObject("cube", new Vector3(0, 5, -10)));
        }

        public override void Update()
        {
            //if(cube1volume.DoesIntersectWith(Cube2Volume.AABB))
            //{
            //    System.Diagnostics.Trace.WriteLine("Collision");
            //}
            //else
            //{
            //    System.Diagnostics.Trace.WriteLine("No Collision");
            //}

            //float? distance = Cube2Volume.DoesRayIntersectWith(cube1volume.AABB);

            //if(distance != null)
            //{
            //    System.Diagnostics.Trace.WriteLine("Hit! " + cube1volume.Owner.ID + ",Distance: ");
            //}

            if(InputManager.IsKeyPressed(Keys.Space))
            {
                SpawnCube();
            }

            base.Update();
        }
    }
}
