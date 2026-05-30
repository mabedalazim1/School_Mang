USE [KPS_DATA_2023]
GO

/****** Object:  View [dbo].[Get_School_year_Data]    Script Date: 5/13/2026 11:13:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






ALTER VIEW [dbo].[Get_School_year_Data]
AS
SELECT        sd.std_code, gr.Grade_Id, st.std_name + ' ' + os.father_name AS [«”„ «·ÿ«·»],
              gr.GradeDesc AS «·’›, 
			  cl.Class_No AS «·›’·, 
		      rg.ReligionDesc AS «·œÌ«‰…, 
			  gn.GenderDesc AS «·‰Ê⁄,
			  ss.StatusDesc AS «·Õ«·…, 
			  rg.Religion_Id, 
			  gn.Gender_Id, 
              ss.Std_Status_Id,
			  st.Osraa_Id, 
			  sd.Year_Id, 
			  cl.Class_No, 
			  cl.Class_Id, 
			  os.father_name,
			  os.address AS [«·⁄‰Ê«‰],
			  st.std_name, 
			  st.std_nat,
			  os.father_mobil_1 as [Â« › «·√»],
			  os.mother_mobil_1 as [Â« › «·√„],
			  st.Year_Id as 'year',
			  y.YearDesc as 'year_desc',
			  gr.GradeDesc as 'old_grade',
			  sd.Updated_At,
			  sd.Updated_by
FROM dbo.School_Std_Data AS sd INNER JOIN
                         dbo.StdData AS st ON st.std_code = sd.std_code INNER JOIN
						 dbo.MyYears As y ON st.Year_Id = y.Year_Id INNER JOIN
                         dbo.OsraData AS os ON st.Osraa_Id = os.Osraa_Id INNER JOIN
                         dbo.Grades AS gr ON sd.Grade_Id = gr.Grade_Id INNER JOIN
                         dbo.Classes AS cl ON cl.Class_Id = sd.Class_Id INNER JOIN
                         dbo.Religions AS rg ON rg.Religion_Id = st.Religion_Id INNER JOIN
                         dbo.Genders AS gn ON gn.Gender_Id = st.Gender_Id INNER JOIN
                         dbo.StudentStatuses AS ss ON ss.Std_Status_Id = sd.Std_Status_Id
						 where sd.Std_Status_Id <> 7
GO


