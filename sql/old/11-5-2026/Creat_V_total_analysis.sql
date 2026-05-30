CREATE VIEW V_total_analysis AS
SELECT 
    t.std_code,
	t.studentName,
    t.Grade_Id,
	t.Year_Id,
	t.Religion_Id,
    x.SubjectName,
    x.SubjectDegree,
	 x.SortOrder
FROM dbo.totals t 
CROSS APPLY
(
    VALUES
    (1,N'ÚÑÈí',   CASE WHEN t.Grade_Id > 2 THEN ar_B / 2.0 ELSE ar_B END),
    (3,N'ÑíÇÖíÇÊ',     CASE WHEN t.Grade_Id > 2 THEN math_B / 2.0 ELSE math_B END),
    (4,N'Úáæã',   CASE WHEN t.Grade_Id > 2 THEN scince_B / 2.0 ELSE scince_B END),
    (5,N'ÏÑÇÓÇÊ',   CASE WHEN t.Grade_Id > 2 THEN social_B / 2.0 ELSE social_B END),
    (6,N'ÇäÌáíÒì',  CASE WHEN t.Grade_Id > 2 THEN english_B / 2.0 ELSE english_B END),
    (2,N'Ïíä',     CASE WHEN t.Grade_Id > 2 THEN dain_B / 2.0 ELSE dain_B END),
    (7,N'ÊßäæáæÌíÇ',CASE WHEN t.Grade_Id > 2 THEN tocnolegy_B / 2.0 ELSE tocnolegy_B END),
    (8,N'ÝäíÉ_ãåÇÑÇÊ',  CASE WHEN t.Grade_Id > 2 THEN maharat_B / 2.0 ELSE maharat_B END)
) x (SortOrder,SubjectName, SubjectDegree)
where t.Grade_Id <10 and t.Year_Id > 4