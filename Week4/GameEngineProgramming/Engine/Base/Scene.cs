using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Base
{
    public class Scene
    {
        private List<GameObject> gameObjects = new List<GameObject>();
        public List<GameObject> GameObjects { get { return gameObjects; } }

        private List<string> awaitingRemoval = new List<string>();

        protected bool isInitialized = false;

        public Scene() { }

        public void AddObject(GameObject newObject)
        {
            if (isInitialized)
            {
                newObject.Initialize();
                newObject.Initialized();
            }

            newObject.OnDestroy += NewObject_OnDestroy;
            newObject.Scene = this;

            gameObjects.Add(newObject);
        }

        private void NewObject_OnDestroy(string id)
        {
            awaitingRemoval.Add(id);
        }

        public List<GameObject> GetGameObjects<T>() where T : GameObject
        {
             return gameObjects.FindAll(go => go.GetType() == typeof(T));
        }

        public int GetObjectIndex(string id)
        {
            return gameObjects.FindIndex(go => go.ID == id);
        }

        public GameObject GetObject(string id)
        {
            return gameObjects.Find(go => go.ID == id);
        }

        public GameObject GetObject<T>()
        {
            return gameObjects.Find(go => gameObjects.GetType() == typeof(T));
        }

        public void RemoveObject(string id)
        {
            int index = GetObjectIndex(id);

            if (index != -1)
                gameObjects.RemoveAt(index);
        }

        public T GetComponentInGameObject<T>(string objectID) where T : Component
        {
            return GetObject(objectID)?.GetComponent<T>();
        }

        public bool HasObject(string id)
        {
            return gameObjects.Any(go => go.ID == id);
        }

        public bool HasObject<T>()
        {
            return gameObjects.Any(go => gameObjects.GetType() == typeof(T));
        }

        public virtual void Initialize()
        {
            gameObjects.ForEach(go => go.Initialize());
            isInitialized = true;
            gameObjects.ForEach(go => go.Initialized());
        }

        public virtual void Update()
        {
            for (int i = 0; i < gameObjects.Count; i++)
                gameObjects[i].Update();

            foreach (var id in awaitingRemoval)
                RemoveObject(id);

            awaitingRemoval.Clear();
        }

        public void Draw(CameraComponent camera)
        {
            gameObjects.ForEach(go => go.Draw(camera));
        }

        public virtual void DrawUI()
        {
            GameUtilities.SetGraphicsDeviceFor3D();
        }
    }
}
