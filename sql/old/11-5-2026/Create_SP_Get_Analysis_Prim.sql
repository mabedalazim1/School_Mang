create proc SP_Get_Analysis_Prim
@Year_Id int,
@Grade_Id int
As
SELECT 
     CASE 
        WHEN SubjectName = N'œÌ‰' AND Religion_Id = 1 THEN N'œÌ‰ («”·«„Ï)'
        WHEN SubjectName = N'œÌ‰' AND Religion_Id = 2 THEN N'œÌ‰ („”ÌÕÏ)'
        ELSE SubjectName
    END AS SubjectName,
	 COUNT(*) AS [≈Ã„«·Ì «·ÿ·«»],
    COUNT(CASE WHEN SubjectDegree < 50 THEN 1 END) AS [√ﬁ· „‰ «· Êﬁ⁄« ],

    COUNT(CASE WHEN SubjectDegree >= 50 AND SubjectDegree < 65 THEN 1 END) AS [Ì·»Ï «· Êﬁ⁄«  √ÕÌ«‰«],

    COUNT(CASE WHEN SubjectDegree >= 65 AND SubjectDegree < 85 THEN 1 END) AS [Ì·»Ï «· Êﬁ⁄«  œ«∆„«],

    COUNT(CASE WHEN SubjectDegree >= 90 THEN 1 END) AS [Ì›Êﬁ «· Êﬁ⁄« ],
	Grade_Id

FROM V_total_analysis
where Year_Id = @Year_Id and Grade_Id = @Grade_Id
GROUP BY 
SortOrder,
Grade_Id,
    CASE 
        WHEN SubjectName = N'œÌ‰' AND Religion_Id = 1 THEN N'œÌ‰ («”·«„Ï)'
        WHEN SubjectName = N'œÌ‰' AND Religion_Id = 2 THEN N'œÌ‰ („”ÌÕÏ)'
        ELSE SubjectName
    END

ORDER BY SortOrder