using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolInsertMedicamentATU.ToolSRC.Model
{
    /// <summary>    
    /// Cette classe permet de binder/mapper les données selon les noms des colonnes du fichier CSV
    /// </summary>
    public class CSVModel_Patient
    {
        [MappingCol("firstId")]
        public string FirstId
        {
            get; set;
        }

        [MappingCol("idToReplace")]
        public string PatIdEnText
        {
            get; set;
        }

        [MappingCol("ddn")]
        public string DateDeNaissance
        {
            get; set;
        }

        [MappingCol("sexe")]
        public string Sexe
        {
            get; set;
        }

        [MappingCol("patJF")]
        public string PATJEUNEFILLE
        {
            get; set;
        }

        [MappingCol("patNom")]
        public string PATNOM
        {
            get; set;
        }

        [MappingCol("patPrenom")]
        public string PATPRENOM
        {
            get; set;
        }
    }       
}

