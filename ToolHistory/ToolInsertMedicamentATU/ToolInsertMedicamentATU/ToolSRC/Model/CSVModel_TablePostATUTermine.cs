using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolInsertMedicamentATU.ToolSRC.Model
{
    /// <summary>
    /// Penser à faire un clean du csv et vérifier le bon nommage des colonnes et du mapping
    /// Cette classe permet de binder/mapper les données selon les noms des colonnes du fichier CSV
    /// </summary>
    public class CSVModel_TablePostATUTermine
    {

        [MappingCol("Code indication")]
        public string CodeIndication
        {
            get; set;
        }

        [MappingCol("Laboratoire titulaire de l'AMM")]
        public string LaboTitu
        {
            get; set;
        }

        [MappingCol("Dénomination Commune Internationale")]
        public string DenominationCommuneInter
        {
            get; set;
        }

        [MappingCol("Nom, dosage, forme pharmaceutique de la spécialité")]
        public string Medicament
        {
            get; set;
        }

        [MappingCol("Statut antérieur du médicament")]
        public string StatutAnterieurMedicament
        {
            get; set;
        }

        [MappingCol("Indications dont a bénéficié le médicament au titre de son ATU de cohorte (ATUC) ou de ses ATU nominatives (ATUn)")]
        public string IndicationsMedicament
        {
            get; set;
        }

        [MappingCol("Prise en charge au titre du post-ATU")]
        public string PriseEnChargePostATU
        {
            get; set;
        }

        [MappingCol("Date d'octroi de l'AMM")]
        public string DateOctroiAMM
        {
            get; set;
        }

        [MappingCol("Date de début de prise en charge au titre du Post-ATU")]
        public string DateDebutPriseEnChargePostATU
        {
            get; set;
        }

        [MappingCol("Date de fin de prise en charge au titre du Post-ATU")]
        public string DateFinpriseEnChargePostATU
        {
            get; set;
        }

        [MappingCol("Inscription au remboursement")]
        public string InscriptionRemboursement
        {
            get; set;
        }

        [MappingCol("Indication de l'ATU ayant fait l'objet d'une évaluation défavorable au titre de l'AMM")]
        public string IndicationATUEvalDefavorable
        {
            get; set;
        }

        [MappingCol("Extension d'indication en cours d'évaluation au titre de l'AMM ayant fait l'objet d'ATU")]
        public string ExtensionIndicationEval
        {
            get; set;
        }

        [MappingCol("Possibilité d'initier de nouveaux traitements")]
        public string InitierNouveauxTraitements
        {
            get; set;
        }

        [MappingCol("Conclusion de l'avis de la HAS sur l'identification d'alternatives thérapeutiques prises en charge")]
        public string ConclusionAvisHAS
        {
            get; set;
        }


        [MappingCol("Classement en réserve hospitalière au titre de l'AMM")]
        public string ClassementReserveHospitaliere
        {
            get; set;
        }


        [MappingCol("UCD 7au titre de l'ATUn")]
        public string UCD7ATUN
        {
            get; set;
        }

        [MappingCol("UCD 7au titre de l'ATUC")]
        public string UCD7ATUC
        {
            get; set;
        }

        [MappingCol("UCD 7au titre de l'AMM")]
        public string UCD7
        {
            get; set;
        }

        [MappingCol("Libellé du code UCD 7au titre de l'AMM")]
        public string LibelleUCD7
        {
            get; set;
        }

        [MappingCol("Observations")]
        public string Observations
        {
            get; set;
        }

        [MappingCol("Date de dernière mise à jour")]
        public string DateDerniereMAJ
        {
            get; set;
        }
    }
}

