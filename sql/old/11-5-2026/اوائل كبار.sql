select  studentName , round( total_B_For_2026_Others /12,2) from totals 
where Year_Id = 5 and Grade_Id = 8

order by total_B_For_2026_Others desc