using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public Drawing() : this(Color.White)
        {

        }

        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void Draw()
        {
            SwinGame.ClearScreen(_background);

            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }

        }

        public Color Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
        }

        public void SelectShapeAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                s.Selected = (s.isAt(pt) | s.Selected) & !(s.isAt(pt) & s.Selected);
            }
        }

        public List<Shape> SelectedShapes()
        {
            List<Shape> _selectedShapes = new List<Shape>();
            foreach (Shape s in _shapes)
            {
                if (s.Selected)
                {
                    _selectedShapes.Add(s);

                }
            }
            return _selectedShapes;
        }

        public void DeleteShapes()
        {
            foreach (Shape s in SelectedShapes())
            {
                if (s.Selected)
                {
                    _shapes.Remove(s);
                }
            }
        }

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);

            try
            {
                writer.WriteLine(_background.ToArgb());
                writer.WriteLine(ShapeCount);

                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            finally
            {
                writer.Close();
            }
        }

        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            try
            {
                int count;
                Shape s;
                string kind;

                _background = Color.FromArgb(reader.ReadInteger());
                count = reader.ReadInteger();

                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();

                    switch (kind)
                    {
                        case "Rectangle":
                            s = new Rectangle();
                            break;
                        case "Circle":
                            s = new Circle();
                            break;
                        default:
                            throw new InvalidDataException("Unknown shape kind: " + kind);
                    }

                    s.LoadFrom(reader);
                    _shapes.Add(s);
                }

            }
            finally
            {
                reader.Close();
            }
        }

    }
}
