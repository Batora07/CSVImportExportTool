using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolInsertMedicamentATU.ToolSRC.Insert;

namespace ToolInsertMedicamentATU.ToolSRC.Entities
{
    public class InsertModel_TableATU
    {
        public char PostATU
        {
            get; set;
        }

        public char ReserveHospitaliere
        {
            get; set;
        }

        public string LibelleCodeUCD
        {
            get; set;
        }

        public string CodeIndication
        {
            get; set;
        }

        public string IndicationATUCohorte
        {
            get; set;
        }

        public string UCD7
        {
            get; set;
        }

        public string Laboratoire
        {
            get; set;
        }

        public string Medicament
        {
            get; set;
        }

        public string DateDerniereMaj
        {
            get; set;
        }

        public InsertModel_TableATU(string _postATU, string _reserveHospi, string _ucd7, string _libelleUCD, string _codeIndic, string _indicATUCohort, string _labo, string _med, string _lastMaj)
        {
            PostATU = InsertTools.HandleBoolFromString(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_postATU)));
            ReserveHospitaliere = InsertTools.HandleBoolFromString(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_reserveHospi)));
            UCD7 = InsertTools.RemoveSpaceString(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_ucd7)));

            LibelleCodeUCD = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_libelleUCD));
            CodeIndication = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_codeIndic));
            IndicationATUCohorte = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_indicATUCohort));
            Laboratoire = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_labo));
            Medicament = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_med));
            if (InsertTools.IsValidDate(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_lastMaj))))
            {
                DateDerniereMaj = InsertTools.ConvertDateTimeFromString(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(_lastMaj))).ToString();
            }
            else
            {
                DateDerniereMaj = null;
            }
        }
 
    }
}
