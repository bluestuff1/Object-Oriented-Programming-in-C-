using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using System.IO;

namespace MyGame
{
    class Line : Shape
    {
        private int _length;

        public Line(Color clr, int x, int y, int length)
        {
            this.Color = clr;
            this.X = x;
            this.Y = y;
            _length = length;
        }

        public Line() : this(Color.DarkMagenta, 0, 0, 200)
        {

        }

        public int length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }

        public override void Draw()
        {
            SwinGame.DrawLine(Color, this.X, this.Y, this.X + _length, this.Y);

            if (Selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            SwinGame.DrawCircle(Color.Black, this.X, this.Y, 2);
            SwinGame.DrawCircle(Color.Black, this.X + _length, this.Y, 2);
        }

        public override bool isAt(Point2D pt)
        {
            return SwinGame.PointOnLine(pt, this.X, this.Y, this.X + _length, this.Y);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(_length);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _length = reader.ReadInteger();
        }
    }
}
