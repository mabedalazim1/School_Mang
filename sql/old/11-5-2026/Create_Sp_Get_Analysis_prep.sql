create proc SP_Get_Analysis_Prep
@Year_Id int,
@Grade_Id int
As
SELECT 
     CASE 
        WHEN SubjectName = N'ѕнд' AND Religion_Id = 1 THEN N'ѕнд («”б«гм)'
        WHEN SubjectName = N'ѕнд' AND Religion_Id = 2 THEN N'ѕнд (г”нЌм)'
        ELSE SubjectName
    END AS SubjectName,
	 COUNT(*) AS [≈ћг«бн «бЎб«»],
    COUNT(CASE WHEN SubjectDegree < 50 THEN 1 END) AS [√ёб гд 50],

    COUNT(CASE WHEN SubjectDegree >= 50 AND SubjectDegree < 65 THEN 1 END) AS [50-65],

    COUNT(CASE WHEN SubjectDegree >= 65 AND SubjectDegree < 75 THEN 1 END) AS [65-75],

    COUNT(CASE WHEN SubjectDegree >= 75 AND SubjectDegree < 90 THEN 1 END) AS [75-90],

    COUNT(CASE WHEN SubjectDegree >= 90 THEN 1 END) AS [√яЋ— гд 90],
	Grade_Id

FROM V_total_analysis
where Year_Id = @Year_Id and Grade_Id = @Grade_Id
GROUP BY 
SortOrder,
Grade_Id,
    CASE 
        WHEN SubjectName = N'ѕнд' AND Religion_Id = 1 THEN N'ѕнд («”б«гм)'
        WHEN SubjectName = N'ѕнд' AND Religion_Id = 2 THEN N'ѕнд (г”нЌм)'
        ELSE SubjectName
    END

ORDER BY SortOrder