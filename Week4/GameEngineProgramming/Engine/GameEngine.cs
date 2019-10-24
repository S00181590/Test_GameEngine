using Engine.Base;
using Engine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class GameEngine : DrawableGameComponent
    {
        InputManager Input;
        CameraManager camera;
        FrameRateCounter counter;
        DebugDrawer debug;
        PhysicsManager physics;

        private Scene activeScene;
        public Scene ActiveScene { get { return activeScene; } }

        public GameEngine(Game game) : base(game)
        {
            game.Components.Add(this);

            Input = new InputManager(game);
            camera = new CameraManager(game);
            debug = new DebugDrawer();
            counter = new FrameRateCounter(game);
            physics = new PhysicsManager(game);

        }

        public override void Initialize()
        {
            

            GameUtilities.Content = Game.Content;

            GameUtilities.SceneContent = new ContentManager(
                Game.Content.ServiceProvider, Game.Content.RootDirectory);

            GameUtilities.GraphicsDevice = Game.GraphicsDevice;
            GameUtilities.Random = new Random();

            debug.Initialize();

            base.Initialize();
        }

        public void LoadScene(Scene scene)
        {
            if(scene != null)
            {
                if (ActiveScene != null)
                {
                    UnloadScene();
                }
                    activeScene = scene;
                    activeScene.Initialize();
                
            }
        }

        public void UnloadScene()
        {
            GameUtilities.SceneContent.Unload();
            CameraManager.Clear();
        }

        public override void Update(GameTime gameTime)
        {
            GameUtilities.Time = gameTime;

            if (ActiveScene != null)
            {
                ActiveScene.Update();
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (ActiveScene != null && CameraManager.ActiveCamera != null)
            {
                ActiveScene.Draw(CameraManager.ActiveCamera);
                ActiveScene.DrawUI();

                debug.Draw(CameraManager.ActiveCamera);
            }

            base.Draw(gameTime);
        }
    }
}
