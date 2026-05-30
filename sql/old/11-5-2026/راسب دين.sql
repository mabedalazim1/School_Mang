select studentName , dain_B ,dain_A, Grade_Id from totals
where dain_A <> dain_B 
and Year_Id = 5 
and dain_B <
(
    CASE 
        WHEN Grade_Id IN (1,2) THEN 100 * 0.70
        ELSE 200 * 0.70
    END
)
order by Grade_Id