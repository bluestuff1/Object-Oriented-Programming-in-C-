using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();

            //Shape myShape = new Shape();
            Drawing myDrawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;


            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();


                if (SwinGame.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SwinGame.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SwinGame.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                // If the user clicks the LeftButton on their mouse, set the shapes x, y to be at the mouse's position
                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    float x = SwinGame.MouseX();
                    float y = SwinGame.MouseY();

                    if (kindToAdd == ShapeKind.Circle)
                    {
                        Circle newCircle = new Circle();
                        newShape = newCircle;
                    }
                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        Rectangle newRect = new Rectangle();
                        newShape = newRect;
                    }
                    else
                    {
                        Line newLine = new Line();
                        newShape = newLine;
                    }
                    newShape.X = x;
                    newShape.Y = y;
                    myDrawing.AddShape(newShape);
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
                SwinGame.DrawFramerate(0, 0);

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}