using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likol.CodeNotes.Data
{
    public class CodeNoteDataEntity
    {
        public int CodeNoteID { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public string Context { get; set; }
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }

    public class CodeNoteDataEntityCollection : List<CodeNoteDataEntity>
    {
    }
}
