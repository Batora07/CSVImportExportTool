using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolInsertMedicamentATU.ToolSRC
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MappingColAttribute : Attribute
    {
        public string ColName { get; set; }
        public MappingColAttribute(string colName)
        {
            ColName = colName;
        }
    }
}
