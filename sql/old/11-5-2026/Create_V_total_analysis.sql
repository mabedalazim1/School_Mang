CREATE VIEW V_total_analysis AS
SELECT 
    t.std_code,
	t.studentName,
    t.Grade_Id,
	t.Year_Id,
	t.Religion_Id,
    x.SubjectName,
    x.SubjectDegree
FROM dbo.totals t
CROSS APPLY
(
    VALUES
    (N'Arabic',   CASE WHEN t.Grade_Id > 2 THEN ar_B / 2.0 ELSE ar_B END),
    (N'Math',     CASE WHEN t.Grade_Id > 2 THEN math_B / 2.0 ELSE math_B END),
    (N'Scince',   CASE WHEN t.Grade_Id > 2 THEN scince_B / 2.0 ELSE scince_B END),
    (N'Social',   CASE WHEN t.Grade_Id > 2 THEN social_B / 2.0 ELSE social_B END),
    (N'English',  CASE WHEN t.Grade_Id > 2 THEN english_B / 2.0 ELSE english_B END),
    (N'Dain',     CASE WHEN t.Grade_Id > 2 THEN dain_B / 2.0 ELSE dain_B END),
    (N'Tocnolegy',CASE WHEN t.Grade_Id > 2 THEN tocnolegy_B / 2.0 ELSE tocnolegy_B END),
    (N'Maharat',  CASE WHEN t.Grade_Id > 2 THEN maharat_B / 2.0 ELSE maharat_B END)
) x (SubjectName, SubjectDegree)