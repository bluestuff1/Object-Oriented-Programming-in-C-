using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure.Core
{
    public interface IHaveInventory
    {
        GameObject Locate(string id);
        GameObject Take(string id);
        void Put(Item itm);

        string Name { get; }
    }
}
