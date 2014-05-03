using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likol.CodeNotes.Data
{
    public class CodeNoteCategoryDataEntity
    {
        public int CodeNoteCategoryID { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public DateTime Created { get; set; }
        public DateTime LatestUpdate { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public class CodeNoteCategoryDataEntityCollection : List<CodeNoteCategoryDataEntity>
    {
    }
}
