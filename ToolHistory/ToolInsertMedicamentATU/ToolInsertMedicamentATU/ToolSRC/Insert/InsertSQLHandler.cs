using System;
using System.Collections.Generic;
using System.IO;
using ToolInsertMedicamentATU.ToolSRC.Entities;

namespace ToolInsertMedicamentATU.ToolSRC.Insert
{
    public class InsertSQLHandler
    {
        public string tableATUDonnees = "TableDonneesATU_INSERT.sql";
        public string tableATUListeMedicament = "TableListeMedicamentsATU_INSERT.sql";
        public string tablePostATUListeMedicament = "TableListeMedicamentsPostATU_INSERT.sql";
        public string tablePostATUTermineListeMedicament = "TableListeMedicamentsPostATUTermine_INSERT.sql";

        /// <summary>
        /// Récupère la liste d'objets pour la table DonneesMedicamentsATU générée lors de la lecture du CSV dans Program.cs
        /// et génère le fichier Insert.sql correspondant à ces données sur le bureau de l'utilisateur
        /// </summary>
        /// <param name="tableATUListObject"></param>
        public void CreateInsertSQLFileTableATU(List<InsertModel_TableATU> tableATUListObject)
        {
            try
            {
                // Set a variable to the Documents path.
                string docPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Write the string array to a new file named "tableATUDonnees + '.sql'".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, tableATUDonnees)))
                {
                    foreach (InsertModel_TableATU line in tableATUListObject)
                    {
                        string insertLine = ComposeLineDonneesMedsATUObj(line);
                        outputFile.WriteLine(insertLine);
                    }
                    outputFile.Close();
                }
            } catch(System.Exception ex)
            {
                Console.WriteLine("Erreur lors de la création du fichier d'insertion Données ATU : " + ex);
            }
            
        }

        public void CreateInsertSQLFileTableListMedATU(List<InsertModel_TableListMedATU> tableATUMedListObject)
        {
            try
            {
                // Set a variable to the Documents path.
                string docPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Write the string array to a new file named "tableATUListeMedicament + '.sql'".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, tableATUListeMedicament)))
                {
                    foreach (InsertModel_TableListMedATU line in tableATUMedListObject)
                    {
                        string insertLine = ComposeLineMedicamentsATUObj(line);
                        outputFile.WriteLine(insertLine);
                    }
                    outputFile.Close();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Erreur lors de la création du fichier d'insertion : " + ex);
            }
        }


        public void CreateInsertSQLFileTablePostATU(List<InsertModel_TableListMedATUPost> tablePostATUListObject)
        {
            try
            {
                // Set a variable to the Documents path.
                string docPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Write the string array to a new file named "tablePostATUListeMedicament + '.sql'".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, tablePostATUListeMedicament)))
                {
                    foreach (InsertModel_TableListMedATUPost line in tablePostATUListObject)
                    {
                        string insertLine = ComposeLineDonneesMedsPostATUObj(line);
                        outputFile.WriteLine(insertLine);
                    }
                    outputFile.Close();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Erreur lors de la création du fichier d'insertion Données Post ATU : " + ex);
            }

        }

        public void CreateInsertSQLFileTablePostATUTermine(List<InsertModel_TableListMedATUPost> tablePostATUListObject)
        {
            try
            {
                // Set a variable to the Documents path.
                string docPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Write the string array to a new file named "tablePostATUTermineListeMedicament + '.sql'".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, tablePostATUTermineListeMedicament)))
                {
                    foreach (InsertModel_TableListMedATUPost line in tablePostATUListObject)
                    {
                        string insertLine = ComposeLineDonneesMedsPostATUObj(line);
                        outputFile.WriteLine(insertLine);
                    }
                    outputFile.Close();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Erreur lors de la création du fichier d'insertion Données Post ATU : " + ex);
            }

        }


        /// <summary>
        /// Génération du string de la ligne d'Insert pour la table DonneesMedicamentsATU
        /// </summary>
        /// <param name="line">Objet généré lors de la lecture du fichier csv depuis Program.cs</param>
        /// <returns></returns>
        public string ComposeLineDonneesMedsATUObj(InsertModel_TableATU line){
            try
            {
                string insertInto = "INSERT INTO DonneesMedicamentsATU (PostATU, ReserveHospitaliere, UCD7, LibelleCodeUCD, CodeIndication, IndicationATUCohorte, Laboratoire, Medicament, DateDerniereMaj) "
                    + "VALUES ('"
                    + line.PostATU + "', '"
                    + line.ReserveHospitaliere + "', '"
                    + line.UCD7 + "', '"
                    + line.LibelleCodeUCD + "', '"
                    + line.CodeIndication + "', '"
                    + line.IndicationATUCohorte + "', '"
                    + line.Laboratoire + "', '"
                    + line.Medicament + "', '"
                    + line.DateDerniereMaj + "')";

                return insertInto;
            }
            catch(System.Exception ex)
            {
                Console.WriteLine("Erreur lors de la création de la ligne dans le fichier d'insertion DonneesMedicamentsATU : " + ex);
                return null;
            }            
        }


        /// <summary>
        /// Génération du string de la ligne d'Insert pour la table ListeMedicamentsATU
        /// </summary>
        /// <param name="line">Objet généré lors de la lecture du fichier csv depuis Program.cs</param>
        /// <returns></returns>
        public string ComposeLineMedicamentsATUObj(InsertModel_TableListMedATU line)
        {
            try
            {
                string insertInto = "INSERT INTO ListeMedicamentsATU (IdMedicamentATU, UCD13, SubstanceActive, StatutATU, DateDebutATU, DateFinATU) "
                    + "VALUES ('"
                    + line.IdMedicamentATU + "', '"
                    + line.UCD13 + "', '"
                    + line.SubstanceActive + "', '"
                    + line.StatutATU + "', '"
                    + line.DateDebutATU + "', '"
                    + line.DateFinATU 
                    + "')";

                return insertInto;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Erreur lors de la création de la ligne dans le fichier d'insertion ListeMedicamentsATU : " + ex);
                return null;
            }
        }

        /// <summary>
        /// Génération du string de la ligne d'Insert pour la table ListeMedicamentsPostATU
        /// </summary>
        /// <param name="line">Objet généré lors de la lecture du fichier csv depuis Program.cs</param>
        /// <returns></returns>
        public string ComposeLineDonneesMedsPostATUObj(InsertModel_TableListMedATUPost line)
        {
            try
            {
                string insertInto = "INSERT INTO ListeMedicamentsPostATU (";
                insertInto += "IdMedicamentATU,";
                insertInto += " PostATUTermine,";
                insertInto += " UCD7ATUN,";
                insertInto += " UCD7ATUC,";
                insertInto += " DenominationCommune,";
                insertInto += " StatutAnterieur,";
                insertInto += " PriseEnChargePostATU,";
                insertInto += " InitierNouveauxTraitements,";
                insertInto += " Observations,";
                insertInto += " InscriptionRemboursement,";
                insertInto += " IndicationEvaluationDefavorable,";
                insertInto += " ExtensionIndicationEnCours,";
                insertInto += " ConclusionAvisHAS,";
                insertInto += " DateOctroiAMM,";
                insertInto += " DateDebutPostATU,";
                insertInto += " DateFinPostATU) ";
                insertInto += "VALUES ('"
                    + line.IdMedicamentATU + "', '"
                    + line.PostATUTermine + "', '"
                    + line.UCD7ATUN + "', '"
                    + line.UCD7ATUC + "', '"
                    + line.DenominationCommune + "', '"
                    + line.StatutAnterieur + "', '"
                    + line.PriseEnChargePostATU + "', '"
                    + line.InitierNouveauxTraitements + "', '"                 
                    + line.Observations + "', '"
                    + line.InscriptionRemboursement + "', '"
                    + line.IndicationEvaluationDefavorable + "', '"
                    + line.ExtensionIndicationEnCours + "', '"
                    + line.ConclusionAvisHAS + "', '"
                    + line.DateOctroiAMM + "', '"
                    + line.DateDebutPostATU + "', '"
                    + line.DateFinPostATU
                    + "')";

                return insertInto;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Erreur lors de la création de la ligne dans le fichier d'insertion ListeMedicamentsPostATU : " + ex);
                return null;
            }
        }
    }
}
