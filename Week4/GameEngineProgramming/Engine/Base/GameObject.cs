using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

namespace Engine.Base
{
    public class GameObject
    {
        public string ID { get; set; }
        public bool Enabled { get; set; }
        public Scene Scene { get; set; }

        public event ObjectIDHandler OnDestroy;

        public Matrix World { get; set; }

        public GameObject Parent { get; set; }
        public List<GameObject> Children { get; set; }

        List<Component> components = new List<Component>();
        public List<Component> Components { get { return components; } }

        List<string> awaitingRemoval = new List<string>();

        private bool isInitialized = false;
        public bool IsInitialized { get { return isInitialized; } }

        public GameObject()
        {
            ID = this.GetType().Name + Guid.NewGuid();
            Enabled = true;
            Children = new List<GameObject>();
            World = Matrix.Identity;
        }

        public GameObject(Vector3 position)
        {
            ID = this.GetType().Name + Guid.NewGuid();
            Enabled = true;
            Children = new List<GameObject>();
            World = Matrix.Identity * Matrix.CreateTranslation(position);
        }

        public void AddComponent(Component newComponent)
        {
            //Set the Owner property of the component to the current game object
            newComponent.Owner = this;

            //If the game object has  already been initialized, call initialize on the new component immediately
            if (isInitialized)
                newComponent.Initialize();

            //Assign an event handler to the OnDestroy event of the component(+= TAB TAB)
            newComponent.OnDestroy += NewComponent_OnDestroy;

            //Add the component to the component collection
            components.Add(newComponent);
        }

        private void NewComponent_OnDestroy(string ID)
        {
            //add the ID of the component to the list of components awaiting removal
            awaitingRemoval.Add(ID);
        }

        public virtual void Initialize()
        {
            //initialize each component
            for(int i = 0; i < components.Count;i++)
            {
                components[i].Initialize();
            }
            //set isInitialized to true
            isInitialized = true;
        }
        public virtual void Initialized()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Initialized();
            }
        }

        public virtual void Update()
        {
            //Call the update method for every component that is enabled in the components collection
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].Enabled)
                    components[i].Update();
            }

            //For every string the awaiting removal list
            for(int i = 0; i < awaitingRemoval.Count;i++)
            {
                //Call the remove component method, passing the string ID of the component
                RemoveComponent(awaitingRemoval[i]);
            }
            //clear out the list of IDs
            awaitingRemoval.Clear();
        }

        public void RemoveComponent(string id)
        {
            //get the index of the component in the list of components
            int index = components.FindIndex(i => i.ID == id);
            //use RemoveAt to remove a component at a specific index....
            RemoveComponent(index);//call the other RemoveComponent that uses the index
        }

        public void RemoveComponent(int index)
        {
            components.RemoveAt(index);
        }

        public void RemoveComponent(Component component)
        {
            components.Remove(component);
        }

        public bool HasComponent<T>()
        {
            //for(int i = 0; i < components.Count;i++)
            //{
            //    if (components[i].GetType() == typeof(T) || components.GetType().IsSubclassOf(typeof(T)))
            //    {
            //        return true;
            //    }
            //}
            //return false;

            return components.Any( c => c.GetType() == typeof(T) || c.GetType().IsSubclassOf(typeof(T)));
        }

        public void Draw(CameraComponent camera)
        {
            //For every Render Component in the components list
            //OfType returns a collection of only RenderComponents
            //again can be done with a for loop using GetType().IsSubclassOf(typeof(RenderComponent));
            foreach (RenderComponent renderComp in components.OfType<RenderComponent>())
            {
                //If the component is enabled, call Draw on the component
                if (renderComp.Enabled)
                    renderComp.Draw(camera);
            }
        }

        public float GetDistanceTo(GameObject otherObject)
        {
            //return the distance between the current game object and the game object argument
            return Vector3.Distance(World.Translation, otherObject.World.Translation);
        }

        public void Destroy()
        {
            components.Clear();

            if (OnDestroy != null)
                OnDestroy(ID);
        }

        public Component GetComponent(string id)
        {
            return components.Find(comp => comp.ID == id);
        }

        public Component GetComponent(Type type)
        {
            return components.Find(comp => comp.GetType() == type || comp.GetType().IsSubclassOf(type)) ;
        }

        public List<Component> GetComponents(Type type)
        {
            return components.FindAll(comp => comp.GetType() == type || comp.GetType().IsSubclassOf(type));
        }

        public T GetComponent<T>() where T : Component
        {
            return (T)components.Find(comp => comp.GetType() == typeof(T) || comp.GetType().IsSubclassOf(typeof(T)));
        }

        public List<T> GetComponents<T>() where T : Component
        {
            return components.FindAll(comp => comp.GetType() == typeof(T) || comp.GetType().IsSubclassOf(typeof(T))) as List<T>;
        }
    }
}
