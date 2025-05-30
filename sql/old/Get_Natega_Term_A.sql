select val.Golos,
	val.arabic_A_Val,
	val.dain_A_Val,
	val.math_A_Val,
	val.motadad_scince_A_Val, 
	val.english_A_Val,
	val.maharat_A_Val,
	val.social_A_Val,
	val.tocnolegy_A_Val,

	val.term_A_1_2_3_Val,
	term_A_4_5_6_Val,
	t.total_A_1_2_3,
	t.total_A_4_5_6,
	t.arbic_test_A,
	t.dain_test_A,
	t.math_test_A,
	t.english_test_A,
	t.scince_test_A,
	t.social_test_A,
	t.maharat_test_A,
	t.tocnolegy_test_A
	from V_Final_Degree_Valuation_A val join totals t
	on  val.Year_Id = t.Year_Id and val.Grade_Id = t.Grade_Id and val.Golos = t.Golos

where val.Year_Id = 4 and val.Grade_Id = 3
order by val.Golos