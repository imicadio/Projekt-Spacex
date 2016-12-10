using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Spacex
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Spacex : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Screens.Screen currentScreen;

        public Spacex()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Const.CONTENT = Content;
            Const.GRAPHICSDEVICE = GraphicsDevice;

            this.graphics.PreferredBackBufferHeight = Const.GAME_HEIGHT;
            this.graphics.PreferredBackBufferWidth = Const.GAME_WIDTH;
            this.Window.Title = Const.TITLE;

            this.graphics.ApplyChanges();

            Manager.InputManager input = new Manager.InputManager();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Const.SPRITEBATCH = spriteBatch;

            currentScreen = new Screens.GameScreen();

            currentScreen.LoadContent();

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Const.GAMETIME = gameTime;
            Const.INPUT.Update();

            currentScreen.Update();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            currentScreen.Draw();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}