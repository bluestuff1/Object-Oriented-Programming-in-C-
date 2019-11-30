using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    class Circle : Shape
    {
        private int _radius;

        public Circle(Color clr, float x, float y, int radius)
        {
            this.Color = clr;
            this.X = x;
            this.Y = y;
            _radius = radius;
        }

        public Circle() : this(Color.Blue, 0, 0, 50)
        {

        }

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public override void Draw()
        {
            SwinGame.FillCircle(Color, this.X, this.Y, _radius);

            if (Selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            SwinGame.DrawCircle(Color.Black, this.X, this.Y, _radius + 2);
        }

        public override bool isAt(Point2D pt)
        {
            return SwinGame.PointInCircle(pt, this.X, this.Y, _radius);
        }
    }
}
