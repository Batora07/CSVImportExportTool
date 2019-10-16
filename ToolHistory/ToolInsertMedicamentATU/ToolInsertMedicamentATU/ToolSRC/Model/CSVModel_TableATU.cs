using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolInsertMedicamentATU.ToolSRC.Model
{
    /// <summary>
    /// Penser à faire une copie du csv source + supprimer les "(source DGOS / source ANSM)" dans les en-têtes de colonne (via notepad ++)
    /// Cette classe permet de binder/mapper les données selon les noms des colonnes du fichier CSV
    /// </summary>
    public class CSVModel_TableATU
    {
        [MappingCol("Date de dernière mise à jour")]
        public string DateMaJ
        {
            get; set;
        }

        [MappingCol("Médicaments sous ATU (nom, dosage, forme pharmaceutique)")]
        public string Medicament
        {
            get; set;
        }

        [MappingCol("Substance active")]
        public string SubstanceActive
        {
            get; set;
        }

        [MappingCol("Laboratoire")]
        public string Labo
        {
            get; set;
        }

        [MappingCol("Statut de l'ATU octroyée (nominative/cohorte)")]
        public string StatutATU
        {
            get; set;
        }

        [MappingCol("Date de début de l'ATU")]
        public string DateDebutATU
        {
            get; set;
        }

        [MappingCol("Date de fin de l'ATU")]
        public string DateFinATU
        {
            get; set;
        }

        [MappingCol("Indication de l'ATU de cohorte")]
        public string IndicationATUCohorte
        {
            get; set;
        }

        [MappingCol("Code indication")]
        public string CodeIndication
        {
            get; set;
        }

        [MappingCol("Libellé du code UCD")]
        public string LibelleUCD
        {
            get; set;
        }

        [MappingCol("UCD 7")]
        public string UCD7
        {
            get; set;
        }

        [MappingCol("UCD 13")]
        public string UCD13
        {
            get; set;
        }

        [MappingCol("Réserve hospitalière (oui/non)")]
        public string ReserveHospi
        {
            get; set;
        }
    }
}

