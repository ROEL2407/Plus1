using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseUpdater.Updaters.Classes
{
    class SubCategory
    {
        public string Name { get; set; }
        public SubSubCategory SubSubCategory { get; set; }
        public Category Parent{ get; set; }
    }
}
