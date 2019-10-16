using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ToolInsertMedicamentATU.ToolSRC;
using ToolInsertMedicamentATU.ToolSRC.Entities;
using ToolInsertMedicamentATU.ToolSRC.Model;
using ToolInsertMedicamentATU.ToolSRC.Insert;

namespace ToolInsertMedicamentATU
{
    class Program
    {
        public static char separator = ';';

        public static string csvFileATU = "C:\\Users\\mpt\\Desktop\\SQLQueries\\medicamentsATU\\TOOL\\dgos_tableau_codes-atu_280219Exemple.csv";
        public static string csvFilePostATU = "C:\\Users\\mpt\\Desktop\\SQLQueries\\medicamentsATU\\TOOL\\tableau_codage_par_indication_post-atu_1er_avril_2019corr1V5.csv";
        public static string csvFilePostATUTermine = "C:\\Users\\mpt\\Desktop\\SQLQueries\\medicamentsATU\\TOOL\\tableau_codage_par_indication_post-atu_1er_avril_2019corr1Termine.csv";

        public static List<InsertModel_TableATU> tableATUList;
        public static List<InsertModel_TableListMedATU> tableMedATUList;
        public static List<InsertModel_TableListMedATUPost> tableMedATUPost;
        public static List<InsertModel_TableListMedATUPost> tableMedATUPostTermine;

        public static void Main(string[] args)
        {
            Console.WriteLine("Traitement du fichier");
            tableATUList = new List<InsertModel_TableATU>();
            tableMedATUList = new List<InsertModel_TableListMedATU>();
            tableMedATUPost = new List<InsertModel_TableListMedATUPost>();
            tableMedATUPostTermine = new List<InsertModel_TableListMedATUPost>();

            InsertSQLHandler handlerSQL = new InsertSQLHandler();
            string generateMedATU = "";
            string generateMedPostATU = "";
            string generateMedPostATUTermine = "";
            // utiliser ce compteur pour la clé étrangère qui correspond à l'ID dans la table de données
            int cptID = 0;

            Console.WriteLine("Générer le script INSERT sql pour les médicaments ATU ? (taper 'O' / 'OUI' ou 'N' / 'NON'):  ");
            generateMedATU = Console.ReadLine();
            generateMedATU = generateMedATU.ToLower();
            switch (generateMedATU)
            {
                case "o":
                case "oui":
                    var lines = ExtractReport(@csvFileATU, separator);

                    if (lines != null)
                    {
                        foreach (var line in lines)
                        {
                            // force le bool à "NON" car ce fichier ne contient que des ATU et aucun POST ATU
                            // Création de l'objet pour la génération de ligne d'Insert
                            cptID++;
                            InsertModel_TableATU tabATULine = new InsertModel_TableATU("Non", line.ReserveHospi, line.UCD7, line.LibelleUCD, line.CodeIndication, line.IndicationATUCohorte, line.Labo, line.Medicament, line.DateMaJ);
                            InsertModel_TableListMedATU tabMedATULine = new InsertModel_TableListMedATU(cptID, line.UCD13, line.SubstanceActive, line.StatutATU, line.DateDebutATU, line.DateFinATU);

                            tableATUList.Add(tabATULine);
                            tableMedATUList.Add(tabMedATULine);
                        }
                    }

                    Console.WriteLine("Création script SQL Insert DonneesATU en cours");
                    // Crée les fichiers d'Insert SQL sur le bureau de l'utilisateur
                    handlerSQL.CreateInsertSQLFileTableATU(tableATUList);
                    handlerSQL.CreateInsertSQLFileTableListMedATU(tableMedATUList);
                    break;

                default: break;
            }

            Console.WriteLine("Générer le script INSERT sql pour les médicaments POST ATU ? (taper 'O' / 'OUI' ou 'N' / 'NON'):  ");
            generateMedPostATU = Console.ReadLine();
            generateMedPostATU = generateMedPostATU.ToLower();

            switch (generateMedATU)
            {
                case "o":
                case "oui":

                    var lines = ExtractReportPost(@csvFilePostATU, separator);

                    if (lines != null)
                    {
                        foreach (var line in lines)
                        {
                            // force le bool à "NON" car ce fichier ne contient que des ATU et aucun POST ATU
                            // Création de l'objet pour la génération de ligne d'Insert
                            cptID++;
                            string resHospi = string.IsNullOrWhiteSpace(line.ClassementReserveHospitaliere) ? "NON" : line.ClassementReserveHospitaliere;
                            InsertModel_TableATU tabATULine = new InsertModel_TableATU("Oui", resHospi, line.UCD7, line.LibelleUCD7, line.CodeIndication, line.IndicationsMedicament, line.LaboTitu, line.Medicament, line.DateDerniereMAJ);
                            MedicamentPostATUObject medicament = new MedicamentPostATUObject();

                            /*** generation objet à passer en paramètre pour création de la ligne ***/

                            medicament.IdMedicamentATU = cptID;
                            medicament.PostATUTermine = "NON";
                            medicament.UCD7ATUN = "";
                            medicament.UCD7ATUN = "";
                            medicament.DenominationCommune = line.DenominationCommuneInter;
                            medicament.StatutAnterieur = line.StatutAnterieurMedicament;
                            medicament.PriseEnChargePostATU = line.PriseEnChargePostATU;
                            medicament.InitierNouveauxTraitements = line.InitierNouveauxTraitements;
                            medicament.Observations = line.Observations;
                            medicament.InscriptionRemboursement = line.InscriptionRemboursement;
                            medicament.IndicationEvaluationDefavorable = "";
                            medicament.ExtensionIndicationEnCours = "";
                            medicament.ConclusionAvisHAS = "";
                            medicament.DateOctroiAMM = line.DateOctroiAMM;
                            medicament.DateDebutPostATU = line.DateDebutPriseEnChargePostATU;
                            medicament.DateFinPostATU = line.DateFinpriseEnChargePostATU;

                            InsertModel_TableListMedATUPost tabMedPostATULine = new InsertModel_TableListMedATUPost(medicament);

                            tableATUList.Add(tabATULine);
                            tableMedATUPost.Add(tabMedPostATULine);
                        }
                    }

                    Console.WriteLine("Création script SQL Insert MedicamentPOST_ATU en cours");
                    // Crée les fichiers d'Insert SQL sur le bureau de l'utilisateur
                    handlerSQL.CreateInsertSQLFileTableATU(tableATUList);
                    handlerSQL.CreateInsertSQLFileTablePostATU(tableMedATUPost);


                    break;

                default: break;
            }

            Console.WriteLine("Générer le script INSERT sql pour les médicaments POST ATU TERMINE ? (taper 'O' / 'OUI' ou 'N' / 'NON'):  ");
            generateMedPostATUTermine = Console.ReadLine();
            generateMedPostATUTermine = generateMedPostATUTermine.ToLower();

            switch (generateMedATU)
            {
                case "o":
                case "oui":
                    var linesTermine = ExtractReportPostTermine(@csvFilePostATUTermine, separator);

                    if (linesTermine != null)
                    {
                        foreach (var line in linesTermine)
                        {
                            // force le bool à "NON" car ce fichier ne contient que des ATU et aucun POST ATU
                            // Création de l'objet pour la génération de ligne d'Insert
                            cptID++;
                            string resHospi = string.IsNullOrWhiteSpace(line.ClassementReserveHospitaliere) ? "NON" : line.ClassementReserveHospitaliere;
                            InsertModel_TableATU tabATUPostTermineLine = new InsertModel_TableATU("Oui", resHospi, line.UCD7, line.LibelleUCD7, line.CodeIndication, line.IndicationsMedicament, line.LaboTitu, line.Medicament, line.DateDerniereMAJ);
                            MedicamentPostATUObject medicament = new MedicamentPostATUObject();

                            /*** generation objet à passer en paramètre pour création de la ligne ***/

                            medicament.IdMedicamentATU = cptID;
                            medicament.PostATUTermine = "OUI";
                            medicament.UCD7ATUN = line.UCD7ATUN;
                            medicament.UCD7ATUC = line.UCD7ATUC;
                            medicament.DenominationCommune = line.DenominationCommuneInter;
                            medicament.StatutAnterieur = line.StatutAnterieurMedicament;
                            medicament.PriseEnChargePostATU = line.PriseEnChargePostATU;
                            medicament.InitierNouveauxTraitements = line.InitierNouveauxTraitements;
                            medicament.Observations = line.Observations;
                            medicament.InscriptionRemboursement = line.InscriptionRemboursement;
                            medicament.IndicationEvaluationDefavorable = line.IndicationATUEvalDefavorable;
                            medicament.ExtensionIndicationEnCours = line.ExtensionIndicationEval;
                            medicament.ConclusionAvisHAS = line.ConclusionAvisHAS;
                            medicament.DateOctroiAMM = line.DateOctroiAMM;
                            medicament.DateDebutPostATU = line.DateDebutPriseEnChargePostATU;
                            medicament.DateFinPostATU = line.DateFinpriseEnChargePostATU;

                            InsertModel_TableListMedATUPost tabMedPostATUTermineLine = new InsertModel_TableListMedATUPost(medicament);

                            tableATUList.Add(tabATUPostTermineLine);
                            tableMedATUPostTermine.Add(tabMedPostATUTermineLine);
                        }
                    }

                    Console.WriteLine("Création script SQL Insert MedicamentPOST_ATU_Termine en cours");
                    // Crée les fichiers d'Insert SQL sur le bureau de l'utilisateur
                    handlerSQL.CreateInsertSQLFileTableATU(tableATUList);
                    handlerSQL.CreateInsertSQLFileTablePostATUTermine(tableMedATUPostTermine);

                    break;

                default: break;
            }
            
            Console.WriteLine("Fin du traitement, appuyez sur une touche pour quitter.");
            Console.Read();
        }


        private static List<CSVModel_TableATU> ExtractReport(string path, char separator)
        {
            // Instanciation du Parser
            var csvSerializer = new FileParser<CSVModel_TableATU>(separator);
            IList<CSVModel_TableATU> reportLines = null;

            if (!File.Exists(path))
            {
                Console.WriteLine($"PathFile not exist:{path}");
                return null;
            }

            try
            {
                // Deserialize File
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    reportLines = csvSerializer.Deserialize(fs);
                    fs.Close();
                }

                if (reportLines == null)
                    Console.WriteLine($"Path File:{path} file is null");
                else
                    Console.WriteLine($"Path File:{path} Total Lines:{reportLines.Count}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message error: {ex.Message}");
            }

            return reportLines?.ToList();
        }


        private static List<CSVModel_TablePostATU> ExtractReportPost(string path, char separator)
        {
            // Instanciation du Parser
            var csvSerializer = new FileParser<CSVModel_TablePostATU>(separator);
            IList<CSVModel_TablePostATU> reportLines = null;

            if (!File.Exists(path))
            {
                Console.WriteLine($"PathFile not exist:{path}");
                return null;
            }

            try
            {
                // Deserialize File
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    reportLines = csvSerializer.Deserialize(fs);
                    fs.Close();
                }

                if (reportLines == null)
                    Console.WriteLine($"Path File:{path} file is null");
                else
                    Console.WriteLine($"Path File:{path} Total Lines:{reportLines.Count}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message error: {ex.Message}");
            }
            
            return reportLines?.ToList();
        }

        private static List<CSVModel_TablePostATUTermine> ExtractReportPostTermine(string path, char separator)
        {
            // Instanciation du Parser
            var csvSerializer = new FileParser<CSVModel_TablePostATUTermine>(separator);
            IList<CSVModel_TablePostATUTermine> reportLines = null;

            if (!File.Exists(path))
            {
                Console.WriteLine($"PathFile not exist:{path}");
                return null;
            }

            try
            {
                // Deserialize File
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    reportLines = csvSerializer.Deserialize(fs);
                    fs.Close();
                }

                if (reportLines == null)
                    Console.WriteLine($"Path File:{path} file is null");
                else
                    Console.WriteLine($"Path File:{path} Total Lines:{reportLines.Count}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message error: {ex.Message}");
            }

            return reportLines?.ToList();
        }
    }
}
