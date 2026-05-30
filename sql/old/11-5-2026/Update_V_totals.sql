USE [KPS_DATA_2023]
GO

/****** Object:  View [dbo].[totals]    Script Date: 5/22/2026 12:32:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER view [dbo].[totals] as 
select 
Final_Degrees.Golos,
st.std_code,
st.Religion_Id,
st.std_name + ' ' + os.father_name as 'studentName',
arabic_A_1 + arabic_A_2 as 'ar_A',
math_A_1 + math_A_2 as 'math_A',
scince_A_1 + scince_A_practical + scince_A_Test as 'scince_A',
social_A_1 + social_A_2 as 'social_A',
english_A_1 + english_A_2 as 'english_A',
dain_A_1 + dain_A_2 as 'dain_A',
tocnolegy_A_1 + tocnolegy_A_practical + tocnolegy_A_Test as 'tocnolegy_A',
maharat_A_1 + maharat_A_2 as 'maharat_A',
nashat_1_A,
nashat_2_A,
arabic_A_2 as 'arbic_test_A',
math_A_2 as 'math_test_A',
scince_A_Test as 'scince_test_A',
social_A_2 as 'social_test_A',
english_A_2 as 'english_test_A',
dain_A_2 as 'dain_test_A',
tocnolegy_A_Test as 'tocnolegy_test_A',
maharat_A_2 as 'maharat_test_A',

arabic_A_1 + arabic_A_2 + math_A_1 + math_A_2 + scince_A_1  + scince_A_Test +
english_A_1 + english_A_2 
as 'total_A_1_2_3',

arabic_A_1 + arabic_A_2 + math_A_1 + math_A_2 +
scince_A_1 + scince_A_practical + scince_A_Test +
social_A_1 + social_A_2 + english_A_1 + english_A_2 as 'total_A_7_8_9',

arabic_A_1 + arabic_A_2 + 
math_A_1 + math_A_2 +
scince_A_1 + scince_A_practical + scince_A_Test +
social_A_1 + social_A_2 +
english_A_1 + english_A_2 +
tocnolegy_A_1 + tocnolegy_A_practical + tocnolegy_A_Test +
maharat_A_1 + maharat_A_2 as 'total_A_4_5_6',

arabic_A_1 + arabic_A_2 + arabic_B_1 + arabic_B_2 as 'ar_B',
math_A_1 + math_A_2 + math_B_1 + math_B_2 as 'math_B',
scince_A_1 + scince_A_practical + scince_A_Test + 
scince_B_1 + scince_B_practical + scince_B_Test as 'scince_B',
social_A_1 + social_A_2 + social_B_1 + social_B_2 as 'social_B',
english_A_1 + english_A_2 + english_B_1 + english_B_2 as 'english_B',
dain_A_1 + dain_A_2 + dain_B_1 + dain_B_2 as 'dain_B',
tocnolegy_A_1 + tocnolegy_A_practical + tocnolegy_A_Test + 
tocnolegy_B_1 + tocnolegy_B_practical + tocnolegy_B_Test as 'tocnolegy_B',
maharat_A_1 + maharat_A_2 + maharat_B_1 + maharat_B_2 as 'maharat_B',

arabic_A_1 + arabic_A_2 + math_A_1 + math_A_2 +
scince_A_1 + scince_A_practical + scince_A_Test +
social_A_1 + social_A_2 + english_A_1 + english_A_2 +
arabic_B_1 + arabic_B_2 + math_B_1 + math_B_2 +
scince_B_1 + scince_B_practical + scince_B_Test +
social_B_1 + social_B_2 + english_B_1 + english_B_2 as 'total_B_7_8_9',


arabic_A_1 + arabic_A_2 + math_A_1 + math_A_2 +
scince_A_1 + scince_A_practical + scince_A_Test +
social_A_1 + social_A_2 + english_A_1 + english_A_2 +
tocnolegy_A_1 + tocnolegy_A_practical + tocnolegy_A_Test +
maharat_A_1 + maharat_A_2 +

arabic_B_1 + arabic_B_2 + math_B_1 + math_B_2 +
scince_B_1 + scince_B_practical + scince_B_Test +
social_B_1 + social_B_2 + english_B_1 + english_B_2 +
tocnolegy_B_1 + tocnolegy_B_practical + tocnolegy_B_Test +
maharat_B_1 + maharat_B_2 as 'total_B_4_5_6',

arabic_B_1  + math_B_1 + 
scince_B_1 + english_B_1 + maharat_B_1
as 'total_B_1_2_3',

arabic_A_1 + arabic_A_2 + math_A_1 + math_A_2 +
scince_A_1  + scince_A_Test + english_A_1 + english_A_2 +

arabic_B_1 + arabic_B_2 + math_B_1 + math_B_2 +
scince_B_1  + scince_B_Test + english_B_1 + english_B_2 
as 'total_B_Grade_3',

arabic_A_1 + arabic_A_2 + math_A_1 + math_A_2 +
english_A_1 + english_A_2 +
arabic_B_1 + arabic_B_2 + math_B_1 + math_B_2 +
english_B_1 + english_B_2 
as 'total_B_For_2026_1_2_3',

arabic_A_1 + arabic_A_2 + math_A_1 + math_A_2 +
scince_A_1 + scince_A_practical + scince_A_Test +
social_A_1 + social_A_2 + english_A_1 + english_A_2 +
tocnolegy_A_1 + tocnolegy_A_practical + tocnolegy_A_Test +

arabic_B_1 + arabic_B_2 + math_B_1 + math_B_2 +
scince_B_1 + scince_B_practical + scince_B_Test +
social_B_1 + social_B_2 + english_B_1 + english_B_2 +
tocnolegy_B_1 + tocnolegy_B_practical + tocnolegy_B_Test 
as 'total_B_For_2026_Others',

arabic_B_2 as 'arbic_test_B',
math_B_2 as 'math_test_B',
scince_B_Test + scince_B_practical as 'scince_test_B',
social_B_2 as 'social_test_B',
english_B_2 as 'english_test_B',
dain_B_2 as 'dain_test_B',
maharat_B_2 as 'maharat_test_B',
tocnolegy_B_Test +tocnolegy_B_practical as 'tocnolegy_test_B',
nashat_1_A + nashat_1_B as 'nashat_1_T2',
nashat_2_A + nashat_2_B as 'nashat_2_T2',
nashat_1_B as 'nashat1',
nashat_2_B as 'nashat2',

absent_ar_A,
absent_ar_B,
absent_math_A,
absent_math_B,
absent_scince_A,
absent_scince_B,
absent_social_A,
absent_social_B,
absent_english_A,
absent_english_B,
absent_din_A,
absent_din_B,
absent_maharat_A,
absent_maharat_B,
absent_tocnolegy_A,
absent_tocnolegy_B,
absent_term_A,
absent_term_B,
Final_Degrees.Year_Id,
s.Grade_Id

from Final_Degrees join School_Std_Data s on Final_Degrees.Golos = s.Golos
and Final_Degrees.Year_Id = s.Year_Id
join StdData st on s.std_code = st.std_code
join OsraData os on st.Osraa_Id = os.Osraa_Id
;
GO


