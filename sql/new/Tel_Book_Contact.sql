USE KPS_DATA_2023;
GO

DECLARE @Mobile  AS nvarchar(10) = N'Mobile';
DECLARE @Whatsup AS nvarchar(10) = N'Whatsup'; 
DECLARE @Father2 AS nvarchar(10) = N'«·√» 2'; 
DECLARE @Mother1 AS nvarchar(10) = N'«·√„ 1';
DECLARE @Mother2 AS nvarchar(10) = N'«·√„ 2';
DECLARE @Phon    AS nvarchar(10) = N'«·√—÷Ï';
DECLARE @Address AS nvarchar(10) = N'«·⁄‰Ê«‰';

SELECT 
    s.std_name + ' ' + o.father_name AS [stdunet_name],
    g.GradeDesc AS [GradeDesc],

    @Mobile AS [Mobile],
    o.father_mobil_1 AS [father_mobil_1],

    @Whatsup AS [Whatsup],
    CASE o.WhatsAppSource
        WHEN 1 THEN o.father_mobil_1
        WHEN 2 THEN o.father_mobil_2
        WHEN 3 THEN o.mother_mobil_1
        WHEN 4 THEN o.mother_mobil_2
        ELSE NULL
    END AS [WhatsAppNumber],

    @Father2 AS [father2],
    o.father_mobil_2 AS [father_mobil_2],

    @Mother1 AS [mother1],
    o.mother_mobil_1 AS [mother_mobil_1],

    @Mother2 AS [mother2],
    o.mother_mobil_2 AS [mother_mobil_2],

    @Phon AS [phon],
    o.tel AS [tel],

    @Address AS [address_title],
    o.address AS [address]

FROM StdData s 
JOIN School_Std_Data ss 
    ON s.std_code = ss.std_code
JOIN OsraData o 
    ON o.Osraa_Id = s.Osraa_Id
JOIN Grades g 
    ON g.Grade_Id = ss.Grade_Id

WHERE ss.Year_Id = 6 
and WhatsAppSource = 0
ORDER BY 
    ss.Grade_Id, 
    s.Gender_Id, 
    N'stdunet_name';