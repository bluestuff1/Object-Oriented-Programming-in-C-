using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using System.IO;

namespace MyGame
{
    public abstract class Shape
    {
        private static Dictionary<String, Type> _ShapeClassRegistry = new Dictionary<string, Type>();

        public static void RegisterShape(string name, Type t)
        {
            _ShapeClassRegistry[name] = t;
        }

        public static Shape CreateShape(string name)
        {
            return (Shape)Activator.CreateInstance(_ShapeClassRegistry[name]);
        }

        private Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected;

        public static string GetKey(Type kind)
        {
            foreach (string key in _ShapeClassRegistry.Keys)
            {
                if (_ShapeClassRegistry[key] == kind)
                {
                    return key;
                }
            }
            return null;
        }

        public Shape(int x, int y, Color clr)
        {
            _color = clr;
            _x = x;
            _y = y;
            _width = 100;
            _height = 100;
        }

        public Shape() : this(0, 0, Color.Yellow)
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

        public abstract void Draw();

        public abstract bool isAt(Point2D pt);

        public abstract void DrawOutline();


        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(GetKey(this.GetType()));
            writer.WriteLine(_color.ToArgb());
            writer.WriteLine(_x);
            writer.WriteLine(_y);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            Color = Color.FromArgb(reader.ReadInteger());
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }

    }
}