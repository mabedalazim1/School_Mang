SELECT DISTINCT 
 SUBSTRING(os.father_name, 1, CHARINDEX(' ', os.father_name + ' ') - 1) AS FirstName,
  os.father_name,
  os.father_nat,
  os.Osraa_Id
FROM School_Std_Data sd
JOIN StdData ss ON sd.std_code = ss.std_code
JOIN OsraData os ON ss.Osraa_Id = os.Osraa_Id
WHERE sd.Year_Id = 5;


