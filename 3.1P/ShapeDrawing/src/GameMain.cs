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

            //Shape myShape = new Shape();
            Drawing myDrawing = new Drawing();


            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                // If the user clicks the LeftButton on their mouse, set the shapes x, y to be at the mouse's position
                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    myDrawing.AddShape(new Shape((int)SwinGame.MousePosition().X, (int)SwinGame.MousePosition().Y));
                }

                if (SwinGame.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapeAt(SwinGame.MousePosition());
                }

                if (SwinGame.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SwinGame.RandomRGBColor(255);
                }

                if ((SwinGame.KeyTyped(KeyCode.DeleteKey)) | (SwinGame.KeyTyped(KeyCode.BackspaceKey)))
                {
                    myDrawing.DeleteShapes();
                }

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                myDrawing.Draw();
                SwinGame.DrawFramerate(0,0);
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}