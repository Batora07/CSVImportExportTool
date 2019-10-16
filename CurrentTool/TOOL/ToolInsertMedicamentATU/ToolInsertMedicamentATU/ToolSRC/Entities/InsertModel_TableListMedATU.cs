using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolInsertMedicamentATU.ToolSRC.Insert;

namespace ToolInsertMedicamentATU.ToolSRC.Entities
{
    public class InsertModel_TableListMedATU
    {
        public int IdMedicamentATU
        {
            get; set;
        }

        /// <summary>
        /// string car > maxValue int32 
        /// </summary>
        public string UCD13
        {
            get; set;
        }

        public string SubstanceActive
        {
            get; set;
        }
        
        public string StatutATU
        {
            get; set;
        }

        public string DateDebutATU
        {
            get; set;
        }

        public string DateFinATU
        {
            get; set;
        }

        public InsertModel_TableListMedATU(int _idMedicament, string _ucd13, string _substanceActive, string _statutATU, string _dateDebutATU, string _dateFinATU)
        {
            IdMedicamentATU = _idMedicament;
            UCD13 = InsertTools.RemoveSpaceString(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_ucd13)));
            SubstanceActive = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_substanceActive));
            StatutATU = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_statutATU));

            if (InsertTools.IsValidDate(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_dateDebutATU))))
            {
                DateDebutATU = InsertTools.ConvertDateTimeFromString(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_dateDebutATU))).ToString();
            }
            else
            {
                DateDebutATU = null;
            }

            if (InsertTools.IsValidDate(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_dateFinATU))))
            {
                DateFinATU = InsertTools.ConvertDateTimeFromString(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_dateDebutATU))).ToString();
            }
            else
            {
                DateFinATU = null;
            }
        }
    }
}
