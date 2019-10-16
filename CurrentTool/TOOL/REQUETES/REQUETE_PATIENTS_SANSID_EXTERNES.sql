-- SELECT PATIENTS QUI ONT SEULEMENT LA VALEUR NULL RENTREE DANS LA COLONNE PATIDENTEXT
SELECT PATDATENAIS AS DateDeNaissance, 
SEXEID AS SEXE, 
PATNOM AS NOM_PATIENT, 
PATJEUNEFILLE AS NOM_JEUNEFILLE,
PATPRENOM AS PRENOM_PATIENT 
FROM PATIENTS 
WHERE PATIDENTEXT IS NULL


-- SELECT PATIENTS QUI N'ONT PAS D'IDS EXTERNES EN GENERAL :
select PATIDENTEXT, PATDATENAIS AS DateDeNaissance, SEXEID AS SEXE, PATNOM AS NOM_PATIENT, PATJEUNEFILLE AS NOM_JEUNEFILLE,PATPRENOM AS PRENOM_PATIENT 
FROM PATIENTS
WHERE isnumeric(PATIDENTEXT) != 1