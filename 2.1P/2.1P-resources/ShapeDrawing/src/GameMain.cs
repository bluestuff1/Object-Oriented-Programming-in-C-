using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();

            Shape myShape = new Shape();

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                // If the user clicks the LeftButton on their mouse, set the shapes x, y to be at the mouse's position
                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = SwinGame.MouseX();
                    myShape.Y = SwinGame.MouseY();
                }

                // If the mouse is over the shape and the user presses the spacebar, then change the color of the shape to a random color
                if(myShape.isAt(SwinGame.MousePosition()))
                {
                    if(SwinGame.KeyTyped(KeyCode.SpaceKey)) {
                        myShape.Color = SwinGame.RandomRGBColor(255);
                    }
                }

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                myShape.Draw();
                SwinGame.DrawFramerate(0,0);
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}