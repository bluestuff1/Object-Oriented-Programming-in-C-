using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    class Shape
    {
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected;

        public Shape(int x, int y)
        {
            _color = Color.Green;
            _x = x;
            _y = y;
            _width = 100;
            _height = 100;
        }

        public Shape() : this(0, 0)
        {

        }



        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public bool Selected { get => _selected; set => _selected = value; }

        public void Draw()
        {
            SwinGame.FillRectangle(_color,
                                    _x, _y,
                                    _width, _height);
            if(Selected)
            {
                DrawOutline();
            }
        }

        public bool isAt(Point2D pt)
        {
            return SwinGame.PointInRect(pt, _x, _y, _width, _height);
        }

        public void DrawOutline()
        {
            SwinGame.DrawRectangle(Color.Black,
                                   _x - 2, _y - 2,
                                   _width + 4, _height + 4);
        }

    }
}