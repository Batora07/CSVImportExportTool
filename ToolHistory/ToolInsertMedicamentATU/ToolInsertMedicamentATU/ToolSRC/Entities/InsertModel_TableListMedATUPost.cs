using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolInsertMedicamentATU.ToolSRC.Insert;

namespace ToolInsertMedicamentATU.ToolSRC.Entities
{
    public class InsertModel_TableListMedATUPost
    {
        public int IdMedicamentATU
        {
            get; set;
        }

        public char PostATUTermine
        {
            get; set;
        }

        public int UCD7ATUN
        {
            get; set;
        }

        public string UCD7ATUC
        {
            get; set;
        }

        public string DenominationCommune
        {
            get; set;
        }

        public string StatutAnterieur
        {
            get; set;
        }

        public char PriseEnChargePostATU
        {
            get; set;
        }

        public char InitierNouveauxTraitements
        {
            get; set;
        }

        public string Observations
        {
            get; set;
        }

        public char InscriptionRemboursement
        {
            get; set;
        }

        public string IndicationEvaluationDefavorable
        {
            get; set;
        }

        public string ExtensionIndicationEnCours
        {
            get; set;
        }

        public string ConclusionAvisHAS
        {
            get; set;
        }

        public string DateOctroiAMM
        {
            get; set;
        }

        public string DateDebutPostATU
        {
            get; set;
        }

        public string DateFinPostATU
        {
            get; set;
        }

        public InsertModel_TableListMedATUPost(MedicamentPostATUObject medicament)
        {
            IdMedicamentATU = medicament.IdMedicamentATU;
            PostATUTermine = InsertTools.HandleBoolFromString(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.PostATUTermine)));

            string _ucd7 = InsertTools.RemoveSpaceString(medicament.UCD7ATUN);
            int ucd;
            if (int.TryParse(_ucd7, out ucd))
            {
                UCD7ATUN = ucd;
            }
            else
            {
                UCD7ATUN = 0;
            }

            UCD7ATUC = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.UCD7ATUC));
            DenominationCommune = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.DenominationCommune));
            StatutAnterieur = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.StatutAnterieur));
            PriseEnChargePostATU = InsertTools.HandleBoolFromString(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.PriseEnChargePostATU)));
            InitierNouveauxTraitements = InsertTools.HandleBoolFromString(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.InitierNouveauxTraitements)));
            Observations = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.Observations));
            InscriptionRemboursement = InsertTools.HandleBoolFromString(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.InscriptionRemboursement)));
            IndicationEvaluationDefavorable = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.IndicationEvaluationDefavorable));
            ExtensionIndicationEnCours = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.ExtensionIndicationEnCours));
            ConclusionAvisHAS = InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.ConclusionAvisHAS));
                        
            if (InsertTools.IsValidDate(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.DateOctroiAMM))))
            {
                DateOctroiAMM = InsertTools.ConvertDateTimeFromString(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.DateOctroiAMM))).ToString();
            }
            else
            {
                DateOctroiAMM = null;
            }

            if (InsertTools.IsValidDate(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.DateDebutPostATU))))
            {
                DateDebutPostATU = InsertTools.ConvertDateTimeFromString(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.DateDebutPostATU))).ToString();
            }
            else
            {
                DateDebutPostATU = null;
            }

            if (InsertTools.IsValidDate(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.DateFinPostATU))))
            {
                DateFinPostATU = InsertTools.ConvertDateTimeFromString(InsertTools.EscapeStringForSQLQuery(InsertTools.ConvertToUTF8String(medicament.DateFinPostATU))).ToString();
            }
            else
            {
                DateFinPostATU = null;
            }
           
         }
    }

    public struct MedicamentPostATUObject
    {
        public int IdMedicamentATU;
        public string PostATUTermine;
        public string UCD7ATUN;
        public string UCD7ATUC;
        public string DenominationCommune;
        public string StatutAnterieur;
        public string PriseEnChargePostATU;
        public string InitierNouveauxTraitements;
        public string Observations;
        public string InscriptionRemboursement;
        public string IndicationEvaluationDefavorable;
        public string ExtensionIndicationEnCours;
        public string ConclusionAvisHAS;
        public string DateOctroiAMM;
        public string DateDebutPostATU;
        public string DateFinPostATU;
    };
}
