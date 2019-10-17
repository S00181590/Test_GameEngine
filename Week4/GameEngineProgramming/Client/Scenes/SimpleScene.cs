using Client.GameObjects;
using Engine.Base;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Scenes
{
    class SimpleScene : Scene
    {

        public SimpleScene():base()
        {
            
        }

        public override void Initialize()
        {
            AddObject(new SimplePlayerObject(new Vector3(0, 0, 10)));
            AddObject(new SimpleMeshObject("cube", new Vector3(0, 0, -10)));
            AddObject(new SimpleMeshObject("plane", new Vector3(0, -2, 0)));
            

            for(int i = 0; i < 10; i++)
            {
                AddObject(new WayPoint(i));
            }

            base.Initialize();
        }
    }
}
