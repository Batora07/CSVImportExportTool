using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolInsertMedicamentATU.ToolSRC.Insert;

namespace ToolInsertMedicamentATU.ToolSRC.Entities
{
    public class UpdateModel_Patient
    {
        public string PatNom
        {
            get; set;
        }

        public string PatPrenom
        {
            get; set;
        }

        public string PatIdEnText
        {
            get; set;
        }

        public string PatSexe
        {
            get; set;
        }

        public string PatDatNaiss
        {
            get; set;
        }

        public string PatFirstId
        {
            get; set;
        }

        public string PatJeuneFille
        {
            get; set;
        }

        public UpdateModel_Patient(string _patFirstId, string _patIdEnText, string _patDatNaiss, string _patSexe, string _patJeuneFille, string _patNom, string _patPrenom)
        {
            PatFirstId = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_patFirstId));
            PatIdEnText = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_patIdEnText));
            PatDatNaiss = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_patDatNaiss));
            PatSexe = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_patSexe));
            PatJeuneFille = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_patJeuneFille));
            PatNom = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_patNom));
            PatPrenom = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_patPrenom));
        }
 
    }
}
