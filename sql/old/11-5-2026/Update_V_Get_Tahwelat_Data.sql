USE [KPS_DATA_2023]
GO

/****** Object:  View [dbo].[V_Get_Tahwelat_Data]    Script Date: 5/14/2026 12:02:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[V_Get_Tahwelat_Data] AS
SELECT 
st.std_code,
st.std_name + ' '+ os.father_name as '«”„ «·ÿ«·»' ,
g.GradeDesc as '«·’›',
t.Transfer_School as '«·„œ—”…',
s.StatusDesc as '«·Õ«·…',
t.Year_Id,
t.New_Grade as Grade_Id,
s.Std_Status_Id,
t.adrs,
t.Kotob,
t.Resom,
t.Transfer_School,
t.Transfer_reason,
t.Guardian_name,
t.Transfer_code,
ss.Class_Id,
t.Trans_After_Year

FROM StdData st join OsraData os 
		on st.Osraa_Id = os.Osraa_Id
	join Transfers t 
		on t.std_code = st.std_code
	left join School_Std_Data ss
		on ss.std_code = st.std_code and t.Year_Id = ss.Year_Id
	join Grades g 
		on g.Grade_Id = t.New_Grade
	join StudentStatuses s 
		on t.Transfer_status = s.Std_Status_Id
;
GO


