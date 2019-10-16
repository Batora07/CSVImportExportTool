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

        public static string csvFileListeComplete_1 = "C:\\Users\\mpt\\Desktop\\Documents\\SQLQueries\\PATEXTERNALID_UPDATER\\TOOL\\ListeCompletesPatients\\listeComplete_1.txt"; // 1 -> 50000
        public static string csvFileListeComplete_2 = "C:\\Users\\mpt\\Desktop\\Documents\\SQLQueries\\PATEXTERNALID_UPDATER\\TOOL\\ListeCompletesPatients\\listeComplete_2.txt"; // 50000 -> 100000
        public static string csvFileListeComplete_3 = "C:\\Users\\mpt\\Desktop\\Documents\\SQLQueries\\PATEXTERNALID_UPDATER\\TOOL\\ListeCompletesPatients\\listeComplete_3.txt"; // 100000 -> 150000
        public static string csvFileListeComplete_4 = "C:\\Users\\mpt\\Desktop\\Documents\\SQLQueries\\PATEXTERNALID_UPDATER\\TOOL\\ListeCompletesPatients\\listeComplete_4.txt"; // 150000 -> 200000
        public static string csvFileListeComplete_5 = "C:\\Users\\mpt\\Desktop\\Documents\\SQLQueries\\PATEXTERNALID_UPDATER\\TOOL\\ListeCompletesPatients\\listeComplete_5.txt"; // 200000 -> 250000
        public static string csvFileListeComplete_6 = "C:\\Users\\mpt\\Desktop\\Documents\\SQLQueries\\PATEXTERNALID_UPDATER\\TOOL\\ListeCompletesPatients\\listeComplete_6.txt"; // 250000 -> 300000
        public static string csvFileListeComplete_7 = "C:\\Users\\mpt\\Desktop\\Documents\\SQLQueries\\PATEXTERNALID_UPDATER\\TOOL\\ListeCompletesPatients\\listeComplete_7.txt"; // 300000 -> 350000

        public static string csvFileToCheck = "C:\\Users\\mpt\\Desktop\\Documents\\SQLQueries\\PATEXTERNALID_UPDATER\\TOOL\\LISTEPATBDD.csv"; // ~500 lignes

        public static List<UpdateModel_Patient> tableUpdateModelPat_1;
        public static List<UpdateModel_Patient> tableUpdateModelPat_2;
        public static List<UpdateModel_Patient> tableUpdateModelPat_3;
        public static List<UpdateModel_Patient> tableUpdateModelPat_4;
        public static List<UpdateModel_Patient> tableUpdateModelPat_5;
        public static List<UpdateModel_Patient> tableUpdateModelPat_6;
        public static List<UpdateModel_Patient> tableUpdateModelPat_7;

        public static List<UpdateModel_Patient> finalizedListUpdate;

        public static void Main(string[] args)
        {
            Console.WriteLine("Traitement du fichier");
            tableUpdateModelPat_1 = new List<UpdateModel_Patient>();

            UpdateSQLHandler handlerSQL = new UpdateSQLHandler();
            string generateUpdatePatient = "";
            // utiliser ce compteur pour la clé étrangère qui correspond à l'ID dans la table de données
            int cptID = 0;

            Console.WriteLine("Générer le script Update sql pour mettre à jour les données patients ? => GENERATION LISTE 1 (taper 'O' / 'OUI' ou 'N' / 'NON'):  ");
            generateUpdatePatient = Console.ReadLine();
            generateUpdatePatient = generateUpdatePatient.ToLower();

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~   LISTE 1 - 1 -> 50000 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            switch (generateUpdatePatient)
            {
                case "o":
                case "oui":
                    var lines = ExtractReport(csvFileListeComplete_1, separator);

                    if (lines != null)
                    {
                        foreach (var line in lines)
                        {
                            // force le bool à "NON" car ce fichier ne contient que des ATU et aucun POST ATU
                            // Création de l'objet pour la génération de ligne d'Insert
                            cptID++;
                            UpdateModel_Patient patLine = new UpdateModel_Patient(line.FirstId, line.PatIdEnText, line.DateDeNaissance, line.Sexe, line.PATJEUNEFILLE, line.PATNOM, line.PATPRENOM);

                            tableUpdateModelPat_1.Add(patLine);                            
                        }
                    }

                    Console.WriteLine("Création script SQL Update patients en cours");
                    // Crée les fichiers d'Insert SQL sur le bureau de l'utilisateur
                    handlerSQL.CreateUpdateSQLFileTablePatient(tableUpdateModelPat_1, 1);
                    break;

                default: break;
            }

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~   LISTE ~2 - 50001 -> 100000 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            tableUpdateModelPat_2 = new List<UpdateModel_Patient>();
            Console.WriteLine("Générer le script Update sql pour mettre à jour les données patients ? => GENERATION LISTE 2 (taper 'O' / 'OUI' ou 'N' / 'NON'):  ");
            generateUpdatePatient = Console.ReadLine();
            generateUpdatePatient = generateUpdatePatient.ToLower();
            switch (generateUpdatePatient)
            {
                case "o":
                case "oui":
                    var lines = ExtractReport(csvFileListeComplete_2, separator);

                    if (lines != null)
                    {
                        foreach (var line in lines)
                        {
                            // force le bool à "NON" car ce fichier ne contient que des ATU et aucun POST ATU
                            // Création de l'objet pour la génération de ligne d'Insert
                            cptID++;
                            UpdateModel_Patient patLine = new UpdateModel_Patient(line.FirstId, line.PatIdEnText, line.DateDeNaissance, line.Sexe, line.PATJEUNEFILLE, line.PATNOM, line.PATPRENOM);

                            tableUpdateModelPat_2.Add(patLine);
                        }
                    }

                    Console.WriteLine("Création script SQL Update patients en cours");
                    // Crée les fichiers d'Insert SQL sur le bureau de l'utilisateur
                    handlerSQL.CreateUpdateSQLFileTablePatient(tableUpdateModelPat_2, 2);
                    break;

                default: break;
            }

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~   LISTE ~3 - 100001 -> 150000 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            tableUpdateModelPat_3 = new List<UpdateModel_Patient>();
            Console.WriteLine("Générer le script Update sql pour mettre à jour les données patients ? => GENERATION LISTE 3 (taper 'O' / 'OUI' ou 'N' / 'NON'):  ");
            generateUpdatePatient = Console.ReadLine();
            generateUpdatePatient = generateUpdatePatient.ToLower();
            switch (generateUpdatePatient)
            {
                case "o":
                case "oui":
                    var lines = ExtractReport(csvFileListeComplete_3, separator);

                    if (lines != null)
                    {
                        foreach (var line in lines)
                        {
                            // force le bool à "NON" car ce fichier ne contient que des ATU et aucun POST ATU
                            // Création de l'objet pour la génération de ligne d'Insert
                            cptID++;
                            UpdateModel_Patient patLine = new UpdateModel_Patient(line.FirstId, line.PatIdEnText, line.DateDeNaissance, line.Sexe, line.PATJEUNEFILLE, line.PATNOM, line.PATPRENOM);

                            tableUpdateModelPat_3.Add(patLine);
                        }
                    }

                    Console.WriteLine("Création script SQL Update patients en cours");
                    // Crée les fichiers d'Insert SQL sur le bureau de l'utilisateur
                    handlerSQL.CreateUpdateSQLFileTablePatient(tableUpdateModelPat_3, 3);
                    break;

                default: break;
            }

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~   LISTE ~4 - 150001 -> 200000 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            tableUpdateModelPat_4 = new List<UpdateModel_Patient>();
            Console.WriteLine("Générer le script Update sql pour mettre à jour les données patients ? => GENERATION LISTE 4 (taper 'O' / 'OUI' ou 'N' / 'NON'):  ");
            generateUpdatePatient = Console.ReadLine();
            generateUpdatePatient = generateUpdatePatient.ToLower();
            switch (generateUpdatePatient)
            {
                case "o":
                case "oui":
                    var lines = ExtractReport(csvFileListeComplete_4, separator);

                    if (lines != null)
                    {
                        foreach (var line in lines)
                        {
                            // force le bool à "NON" car ce fichier ne contient que des ATU et aucun POST ATU
                            // Création de l'objet pour la génération de ligne d'Insert
                            cptID++;
                            UpdateModel_Patient patLine = new UpdateModel_Patient(line.FirstId, line.PatIdEnText, line.DateDeNaissance, line.Sexe, line.PATJEUNEFILLE, line.PATNOM, line.PATPRENOM);

                            tableUpdateModelPat_4.Add(patLine);
                        }
                    }

                    Console.WriteLine("Création script SQL Update patients en cours");
                    // Crée les fichiers d'Insert SQL sur le bureau de l'utilisateur
                    handlerSQL.CreateUpdateSQLFileTablePatient(tableUpdateModelPat_4, 4);
                    break;

                default: break;
            }

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~   LISTE ~5 - 200001 -> 250000 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            tableUpdateModelPat_5 = new List<UpdateModel_Patient>();
            Console.WriteLine("Générer le script Update sql pour mettre à jour les données patients ? => GENERATION LISTE 5 (taper 'O' / 'OUI' ou 'N' / 'NON'):  ");
            generateUpdatePatient = Console.ReadLine();
            generateUpdatePatient = generateUpdatePatient.ToLower();
            switch (generateUpdatePatient)
            {
                case "o":
                case "oui":
                    var lines = ExtractReport(csvFileListeComplete_5, separator);

                    if (lines != null)
                    {
                        foreach (var line in lines)
                        {
                            // force le bool à "NON" car ce fichier ne contient que des ATU et aucun POST ATU
                            // Création de l'objet pour la génération de ligne d'Insert
                            cptID++;
                            UpdateModel_Patient patLine = new UpdateModel_Patient(line.FirstId, line.PatIdEnText, line.DateDeNaissance, line.Sexe, line.PATJEUNEFILLE, line.PATNOM, line.PATPRENOM);

                            tableUpdateModelPat_5.Add(patLine);
                        }
                    }

                    Console.WriteLine("Création script SQL Update patients en cours");
                    // Crée les fichiers d'Insert SQL sur le bureau de l'utilisateur
                    handlerSQL.CreateUpdateSQLFileTablePatient(tableUpdateModelPat_5, 5);
                    break;

                default: break;
            }

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~   LISTE ~6 - 250001 -> 300000 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            tableUpdateModelPat_6 = new List<UpdateModel_Patient>();
            Console.WriteLine("Générer le script Update sql pour mettre à jour les données patients ? => GENERATION LISTE 6 (taper 'O' / 'OUI' ou 'N' / 'NON'):  ");
            generateUpdatePatient = Console.ReadLine();
            generateUpdatePatient = generateUpdatePatient.ToLower();
            switch (generateUpdatePatient)
            {
                case "o":
                case "oui":
                    var lines = ExtractReport(csvFileListeComplete_6, separator);

                    if (lines != null)
                    {
                        foreach (var line in lines)
                        {
                            // force le bool à "NON" car ce fichier ne contient que des ATU et aucun POST ATU
                            // Création de l'objet pour la génération de ligne d'Insert
                            cptID++;
                            UpdateModel_Patient patLine = new UpdateModel_Patient(line.FirstId, line.PatIdEnText, line.DateDeNaissance, line.Sexe, line.PATJEUNEFILLE, line.PATNOM, line.PATPRENOM);

                            tableUpdateModelPat_6.Add(patLine);
                        }
                    }

                    Console.WriteLine("Création script SQL Update patients en cours");
                    // Crée les fichiers d'Insert SQL sur le bureau de l'utilisateur
                    handlerSQL.CreateUpdateSQLFileTablePatient(tableUpdateModelPat_6, 6);
                    break;

                default: break;
            }

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~   LISTE ~7 - 300001 -> 350000 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            tableUpdateModelPat_7 = new List<UpdateModel_Patient>();
            Console.WriteLine("Générer le script Update sql pour mettre à jour les données patients ? => GENERATION LISTE 7 (taper 'O' / 'OUI' ou 'N' / 'NON'):  ");
            generateUpdatePatient = Console.ReadLine();
            generateUpdatePatient = generateUpdatePatient.ToLower();
            switch (generateUpdatePatient)
            {
                case "o":
                case "oui":
                    var lines = ExtractReport(csvFileListeComplete_7, separator);

                    if (lines != null)
                    {
                        foreach (var line in lines)
                        {
                            // force le bool à "NON" car ce fichier ne contient que des ATU et aucun POST ATU
                            // Création de l'objet pour la génération de ligne d'Insert
                            cptID++;
                            UpdateModel_Patient patLine = new UpdateModel_Patient(line.FirstId, line.PatIdEnText, line.DateDeNaissance, line.Sexe, line.PATJEUNEFILLE, line.PATNOM, line.PATPRENOM);

                            tableUpdateModelPat_7.Add(patLine);
                        }
                    }

                    Console.WriteLine("Création script SQL Update patients en cours");
                    // Crée les fichiers d'Insert SQL sur le bureau de l'utilisateur
                    handlerSQL.CreateUpdateSQLFileTablePatient(tableUpdateModelPat_7, 7);
                    break;

                default: break;
            }


            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~   GENERER CSV BDD PATIENT FILE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            finalizedListUpdate = new List<UpdateModel_Patient>();
            Console.WriteLine("Générer le script Update sql pour mettre à jour les données patients ? => GENERATION LISTE 7 (taper 'O' / 'OUI' ou 'N' / 'NON'):  ");
            generateUpdatePatient = Console.ReadLine();
            generateUpdatePatient = generateUpdatePatient.ToLower();
            switch (generateUpdatePatient)
            {
                case "o":
                case "oui":
                    var lines = ExtractReport(csvFileToCheck, separator);

                    if (lines != null)
                    {
                        foreach (var line in lines)
                        {
                            // force le bool à "NON" car ce fichier ne contient que des ATU et aucun POST ATU
                            // Création de l'objet pour la génération de ligne d'Insert
                            cptID++;
                            UpdateModel_Patient patLine = new UpdateModel_Patient(line.FirstId, line.PatIdEnText, line.DateDeNaissance, line.Sexe, line.PATJEUNEFILLE, line.PATNOM, line.PATPRENOM);

                            finalizedListUpdate.Add(patLine);
                        }
                    }

                    Console.WriteLine("Création script SQL Update patients en cours");
                    // Crée les fichiers d'Insert SQL sur le bureau de l'utilisateur
                    handlerSQL.CreateUpdateSQLFileTablePatient(finalizedListUpdate, 8, tableUpdateModelPat_1, tableUpdateModelPat_2, tableUpdateModelPat_3, tableUpdateModelPat_4, tableUpdateModelPat_5, tableUpdateModelPat_6, tableUpdateModelPat_7);
                    break;

                default: break;
            }


            Console.WriteLine("Fin du traitement, appuyez sur une touche pour quitter.");
            Console.Read();
        }


        private static List<CSVModel_Patient> ExtractReport(string path, char separator)
        {
            // Instanciation du Parser
            var csvSerializer = new FileParser<CSVModel_Patient>(separator);
            IList<CSVModel_Patient> reportLines = null;

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
                Console.WriteLine($"Message error: {ex.Message : ex}");
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
