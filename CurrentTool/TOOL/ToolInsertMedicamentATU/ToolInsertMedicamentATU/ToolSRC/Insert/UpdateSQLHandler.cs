using System;
using System.Collections.Generic;
using System.IO;
using ToolInsertMedicamentATU.ToolSRC.Entities;

namespace ToolInsertMedicamentATU.ToolSRC.Insert
{
    public class UpdateSQLHandler
    {
        public string tableUpdatePatientID_1 = "TableDonneesUpdatePatientID_UPDATE_1.sql";
        public string tableUpdatePatientID_2 = "TableDonneesUpdatePatientID_UPDATE_2.sql";
        public string tableUpdatePatientID_3 = "TableDonneesUpdatePatientID_UPDATE_3.sql";
        public string tableUpdatePatientID_4 = "TableDonneesUpdatePatientID_UPDATE_4.sql";
        public string tableUpdatePatientID_5 = "TableDonneesUpdatePatientID_UPDATE_5.sql";
        public string tableUpdatePatientID_6 = "TableDonneesUpdatePatientID_UPDATE_6.sql";
        public string tableUpdatePatientID_7 = "TableDonneesUpdatePatientID_UPDATE_7.sql";
        public string tableUpdatePatientID_FINALISED = "TableDonneesUpdatePatientID_UPDATE_final.sql";

        /// <summary>
        /// Récupère la liste d'objets pour la table DonneesMedicamentsATU générée lors de la lecture du CSV dans Program.cs
        /// et génère le fichier Insert.sql correspondant à ces données sur le bureau de l'utilisateur
        /// </summary>
        /// <param name="tableATUListObject"></param>
        public void CreateUpdateSQLFileTablePatient(List<UpdateModel_Patient> tablePatientListObject, int numberScriptToGenerate, List<UpdateModel_Patient> listToCompare1 = null, 
            List<UpdateModel_Patient> listToCompare2 = null, List<UpdateModel_Patient> listToCompare3 = null, List<UpdateModel_Patient> listToCompare4 = null, List<UpdateModel_Patient> listToCompare5 = null,
            List<UpdateModel_Patient> listToCompare6 = null, List<UpdateModel_Patient> listToCompare7 = null)
        {
            try
            {
                // Set a variable to the Documents path.
                string docPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Write the string array to a new file named "tableATUDonnees + '.sql'".
                string pathToGenerate = "";
                switch (numberScriptToGenerate)
                {
                    case 1:
                        pathToGenerate = tableUpdatePatientID_1;
                        break;
                    case 2:
                        pathToGenerate = tableUpdatePatientID_2;
                        break;
                    case 3:
                        pathToGenerate = tableUpdatePatientID_3;
                        break;
                    case 4:
                        pathToGenerate = tableUpdatePatientID_4;
                        break;
                    case 5:
                        pathToGenerate = tableUpdatePatientID_5;
                        break;
                    case 6:
                        pathToGenerate = tableUpdatePatientID_6;
                        break;
                    case 7:
                        pathToGenerate = tableUpdatePatientID_7;
                        break;
                    case 8:
                        pathToGenerate = tableUpdatePatientID_FINALISED;
                        break;
                    default:
                        break;
                }

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, pathToGenerate)))
                {
                    if(numberScriptToGenerate != 8)
                    {
                        foreach (UpdateModel_Patient line in tablePatientListObject)
                        {
                            string insertLine = ComposeLineDonneesPatientsObj(line);
                            outputFile.WriteLine(insertLine);
                        }
                    }
                    else {
                        foreach (UpdateModel_Patient line in tablePatientListObject)
                        {
                            for(int i = 0; i < listToCompare1.Count; i++)
                            {
                                string insertLine = ComposeLineDonneesPatientsObjCompareWithOtherLine(listToCompare1[i], line);
                                if(insertLine != null && !String.IsNullOrEmpty(insertLine))
                                {
                                    outputFile.WriteLine(insertLine);
                                }
                            }                           
                        }

                        foreach (UpdateModel_Patient line in tablePatientListObject)
                        {
                            for (int i = 0; i < listToCompare2.Count; i++)
                            {
                                string insertLine = ComposeLineDonneesPatientsObjCompareWithOtherLine(listToCompare2[i], line);
                                if (insertLine != null && !String.IsNullOrEmpty(insertLine))
                                {
                                    outputFile.WriteLine(insertLine);
                                }
                            }
                        }

                        foreach (UpdateModel_Patient line in tablePatientListObject)
                        {
                            for (int i = 0; i < listToCompare3.Count; i++)
                            {
                                string insertLine = ComposeLineDonneesPatientsObjCompareWithOtherLine(listToCompare3[i], line);
                                if (insertLine != null && !String.IsNullOrEmpty(insertLine))
                                {
                                    outputFile.WriteLine(insertLine);
                                }
                            }
                        }

                        foreach (UpdateModel_Patient line in tablePatientListObject)
                        {
                            for (int i = 0; i < listToCompare4.Count; i++)
                            {
                                string insertLine = ComposeLineDonneesPatientsObjCompareWithOtherLine(listToCompare4[i], line);
                                if (insertLine != null && !String.IsNullOrEmpty(insertLine))
                                {
                                    outputFile.WriteLine(insertLine);
                                }
                            }
                        }

                        foreach (UpdateModel_Patient line in tablePatientListObject)
                        {
                            for (int i = 0; i < listToCompare5.Count; i++)
                            {
                                string insertLine = ComposeLineDonneesPatientsObjCompareWithOtherLine(listToCompare5[i], line);
                                if (insertLine != null && !String.IsNullOrEmpty(insertLine))
                                {
                                    outputFile.WriteLine(insertLine);
                                }
                            }
                        }

                        foreach (UpdateModel_Patient line in tablePatientListObject)
                        {
                            for (int i = 0; i < listToCompare6.Count; i++)
                            {
                                string insertLine = ComposeLineDonneesPatientsObjCompareWithOtherLine(listToCompare6[i], line);
                                if (insertLine != null && !String.IsNullOrEmpty(insertLine))
                                {
                                    outputFile.WriteLine(insertLine);
                                }
                            }
                        }

                        foreach (UpdateModel_Patient line in tablePatientListObject)
                        {
                            for (int i = 0; i < listToCompare7.Count; i++)
                            {
                                string insertLine = ComposeLineDonneesPatientsObjCompareWithOtherLine(listToCompare7[i], line);
                                if (insertLine != null && !String.IsNullOrEmpty(insertLine))
                                {
                                    outputFile.WriteLine(insertLine);
                                }
                            }
                        }                  
                    }
                    outputFile.Close();
                }
            } catch(System.Exception ex)
            {
                Console.WriteLine("Erreur lors de la création du fichier d'update des Données des patients : " + ex);
            }
            
        }

        /// <summary>
        /// Génération du string de la ligne d'update pour la table Patients
        /// </summary>
        /// <param name="line">Objet généré lors de la lecture du fichier csv depuis Program.cs</param>
        /// <returns></returns>
        public string ComposeLineDonneesPatientsObj(UpdateModel_Patient line)
        {
            try
            {
                string updateLine = "UPDATE PATIENTS SET PATIDENTEXT = '" + line.PatIdEnText + "' WHERE PATIDENTEXT = '" + line.PatFirstId + "'";
               
                return updateLine;
            }
            catch (System.Exception ex)
            {
                // TODO : créer le log à cet endroit + parse les différentes lignes qui ne passent pas
                Console.WriteLine("Erreur lors de la création de la ligne dans le fichier d'update des Données des patients : " + ex);
                return null;
            }
        }


        /// <summary>
        /// Génération du string de la ligne d'update pour la table Patients
        /// </summary>
        /// <param name="line">Objet généré lors de la lecture du fichier csv depuis Program.cs</param>
        /// <returns></returns>
        public string ComposeLineDonneesPatientsObjCompareWithOtherLine(UpdateModel_Patient lineToCompare, UpdateModel_Patient lineToWrite)
        {
            try
            {
                if(lineToCompare.PatFirstId == lineToWrite.PatFirstId)
                {
                    string updateLine = "UPDATE PATIENTS SET PATIDENTEXT = '" + lineToCompare.PatIdEnText + "' WHERE PATIDENTEXT = '" + lineToWrite.PatFirstId + "'";

                    return updateLine;
                }
                return null;
            }
            catch (System.Exception ex)
            {
                // TODO : créer le log à cet endroit + parse les différentes lignes qui ne passent pas
                Console.WriteLine("Erreur lors de la création de la ligne dans le fichier d'update des Données des patients : " + ex);
                return null;
            }
        }
    }
}
