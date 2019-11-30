using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    class Rectangle : Shape
    {
        private int _width;
        private int _height;

        public Rectangle(Color clr, float x, float y, int width, int height)
        {
            this.Color = clr;
            this.X = x;
            this.Y = y;
            _width = width;
            _height = height;
        }

        public Rectangle() : this(Color.Green, 0, 0, 100, 100)
        {

        }

        public override void Draw()
        {
            SwinGame.FillRectangle(this.Color,
                        this.X, this.Y,
                        this.Width, this.Height);
            if (Selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            SwinGame.DrawRectangle(Color.Black,
                       this.X - 2, this.Y - 2,
                       this.Width + 4, this.Height + 4);
        }

        public override bool isAt(Point2D pt)
        {
            return SwinGame.PointInRect(pt, this.X, this.Y, this.Width, this.Height);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(_width);
            writer.WriteLine(_height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _width = reader.ReadInteger();
            _height = reader.ReadInteger();
        }
    }
}
