using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P02AplikacjaZawodnicy.Tools
{
    class DragObject
    {
        public ListBox source;
        public object item;
        public DragObject(ListBox box, object data) { source = box; item = data; }
    }
}
