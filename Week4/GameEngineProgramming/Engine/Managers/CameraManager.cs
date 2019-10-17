using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Engine.Base;

namespace Engine.Managers
{
    class CameraManager : GameComponent
    {
        public static CameraComponent ActiveCamera;
        static string activeCameraID;

        static Dictionary<string, CameraComponent> cameras = new Dictionary<string, CameraComponent>();

        public CameraManager(Game game) : base(game)
        {
            game.Components.Add(this);
        }

        public static void SetActiveCamera(string id)
        {
            if(ActiveCamera != null)
            {
                if(ActiveCamera.ID != id)
                {
                    if(cameras.ContainsKey(id))
                    {
                        ActiveCamera = cameras[id];
                    }
                }
            }
            else
            {
                if(cameras.ContainsKey(id))
                {
                    ActiveCamera = cameras[id];
                }

            }

            //if(id != activeCameraID)
            //{
            //    if(cameras.ContainsKey(id))
            //    {
            //        ActiveCamera = cameras[id];
            //    }
            //}
        }

        public static void AddCameraq(CameraComponent camera)
        {
            if(!cameras.ContainsKey(camera.ID))
            {
                cameras.Add(camera.ID, camera);

                if(cameras.Count == 1)
                {
                    SetActiveCamera(camera.ID);
                }

            }
        }

        public static void Clear()
        {
            cameras.Clear();
            activeCameraID = string.Empty;
            ActiveCamera = null;

        }

        public static void RemoveCamera(string id)
        {
            if(cameras.ContainsKey(id))
            {
                cameras.Remove(id);

                if(activeCameraID == id)
                {
                    ActiveCamera = null;
                }
            }
        }

        public List<string> GetAllCameraIDs()
        {
            return cameras.Keys.ToList();
        }
    }
}
