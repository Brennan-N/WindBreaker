using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindBreaker_Brennan
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 

        Texture2D bg;

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

            bg = this.Content.Load<Texture2D>("background");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

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

            spriteBatch.Begin();
            spriteBatch.Draw(bg, new Rectangle(100,100,100,100), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void LoadLevel()
        {
            List<string> lines = ReadFileAsStrings(@"Content/level1.txt");
            sprites[] currentlevel[];
            Vector2 count = new Vector2(0,0);

            foreach (string line in lines)
            {
                
                foreach(char c in line)
                {
                    switch(c)
                    {
                        case 'v': // spikes facing VVVV
                            currentlevel[count.X, count.Y] = null;
                            break;

                        case '^': // spikes facing ^^^^
                            currentlevel[count.X, count.Y] = null;
                            break;

                        case '<': // spikes facing <<<<
                            currentlevel[count.X, count.Y] = null;
                            break;

                        case '>': // spikes facing >>>>
                            currentlevel[count.X, count.Y] = null;
                            break;


                        case 'O': // blocks
                            currentlevel[count.X, count.Y] = null;
                            break;

                        case '.' // AIR
                            currentlevel[count.X, count.Y] = null;
                            break;
                    }
                    count.Y++;
                }
                count.X++;
            }

        }
        private List<string> ReadFileAsStrings(string path)
        {
            List<string> lines = new List<string>();

            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        lines.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write("The file could not be read: \n" + e.Message);
            }

            return lines;
        }
    }
}
