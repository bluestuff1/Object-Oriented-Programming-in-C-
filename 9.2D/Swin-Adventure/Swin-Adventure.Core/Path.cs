using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure.Core
{
    public class Path : GameObject
    {
        private bool _isBlocked;
        private Location _destination;

        public Path(string[] idents, string name, string desc, Location destination) :
            base(idents, name, desc)
        {
            AddIdentifier("path");
            foreach(string s in name.Split(new char[] {' '}))
            {
                AddIdentifier(s);
            }
            _isBlocked = false;
            _destination = destination;
        }

        public Location Destination
        {
            get
            {
                return _destination;
            }
        }

        public bool isBlocked
        {
            get
            {
                return _isBlocked;
            }
            set
            {
                value = _isBlocked;
            }
        }
    }
}
