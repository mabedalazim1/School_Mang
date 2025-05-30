USE [KPS_DATA_2023]
GO

/****** Object:  View [dbo].[V_Final_Degree_Valuation_A]    Script Date: 1/18/2025 9:47:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








ALTER view [dbo].[V_Final_Degree_Valuation_A]
as
select

std_code, Year_Id,Grade_Id, Religion_Id, Golos,studentName,
dbo.get_Prim_Term_A_Evaluation(ar_A, absent_ar_A) as 'arabic_A_Eval',
dbo.get_Prim_Term_A_Evaluation(math_A, absent_math_A) as 'math_A_Eval',
dbo.get_Prim_Term_A_Evaluation(scince_A, absent_scince_A) as 'motadad_scince_A_Eval',
dbo.get_Prim_Term_A_Evaluation(social_A, absent_social_A) as 'social_A_Eval',
dbo.get_Prim_Term_A_Evaluation(english_A, absent_english_A) as 'english_A_Eval',
dbo.get_Prim_Term_A_Evaluation(dain_A, absent_din_A) as 'dain_A_Eval',
dbo.get_Prim_Term_A_Evaluation(maharat_A, absent_maharat_A) as 'maharat_A_Eval',
dbo.get_Prim_Term_A_Evaluation(tocnolegy_A, absent_tocnolegy_A) as 'tocnolegy_A_Eval',

dbo.get_Prim_Valuation(ar_A, absent_ar_A) as 'arabic_A_Val',
dbo.get_Prim_Valuation(math_A, absent_math_A) as 'math_A_Val',
dbo.get_Prim_Valuation(scince_A, absent_scince_A) as 'motadad_scince_A_Val',
dbo.get_Prim_Valuation(social_A, absent_social_A) as 'social_A_Val',
dbo.get_Prim_Valuation(english_A, absent_english_A) as 'english_A_Val',
dbo.get_Prim_Valuation(dain_A, absent_din_A) as 'dain_A_Val',
dbo.get_Prim_Valuation(maharat_A, absent_maharat_A) as 'maharat_A_Val',
dbo.get_Prim_Valuation(tocnolegy_A, absent_tocnolegy_A) as 'tocnolegy_A_Val',



dbo.get_Prim_Term_A_Evaluation(ROUND(total_A_1_2_3/4,0)
,absent_term_A) as 'term_A_1_2_3_Eval',
dbo.get_Prim_Term_A_Evaluation(ROUND(total_A_4_5_6/7,0)
,absent_term_A) as 'term_A_4_5_6_Eval',

dbo.get_Prim_Valuation(ROUND(total_A_4_5_6/7,0)
,absent_term_A) as 'term_A_4_5_6_Val',
dbo.get_Prim_Valuation(ROUND(total_A_1_2_3/4,0)
,absent_term_A) as 'term_A_1_2_3_Val',

dbo.get_Prim_1_2_3_Evaluation(ar_B, absent_ar_B) as 'arabic_B_Eval',
dbo.get_Prim_1_2_3_Evaluation(math_B, absent_math_B) as 'math_B_Eval',
dbo.get_Prim_1_2_3_Evaluation(scince_B, absent_scince_B) as 'motadad_B_Eval',
dbo.get_Prim_1_2_3_Evaluation(english_B, absent_english_B) as 'english_B_Eval',
dbo.get_Prim_1_2_3_Evaluation(dain_B, absent_din_B) as 'dain_B_Eval',
dbo.get_Prim_1_2_3_Evaluation(maharat_B, absent_maharat_B) as 'badnia_B_Eval',
dbo.get_Prim_1_2_3_Evaluation_Final(ROUND(total_B_1_2_3/6,0)
,ar_B,math_B,scince_B,english_B, dain_B,maharat_B,absent_term_B) as 'term_B_Eval',

dbo.get_Prim_Pass_1_2_3_B(ar_B, absent_ar_B) as 'pass_ar_B',
dbo.get_Prim_Pass_1_2_3_B(math_B, absent_math_B) as 'pass_math_B',
dbo.get_Prim_Pass_1_2_3_B(scince_B, absent_scince_B) as 'pass_motadad_B',
dbo.get_Prim_Pass_1_2_3_B(english_B, absent_english_B) as 'pass_english_B',
dbo.get_Prim_Pass_1_2_3_B(dain_B, absent_din_B) as 'pass_dain_B',
dbo.get_Prim_Pass_1_2_3_B(maharat_B, absent_maharat_B) as 'pass_badnia_B',

dbo.get_Prim_T2_Pass_1_2_3_Final(
dbo.get_Prim_Pass_1_2_3_B(ar_B, absent_ar_B),
dbo.get_Prim_Pass_1_2_3_B(math_B, absent_math_B),
dbo.get_Prim_Pass_1_2_3_B(scince_B, absent_scince_B),
dbo.get_Prim_Pass_1_2_3_B(english_B, absent_english_B),
dbo.get_Prim_Pass_1_2_3_B(dain_B, absent_din_B),
dbo.get_Prim_Pass_1_2_3_B(maharat_B, absent_maharat_B),
absent_term_B)as 'pass_term_B'
 

 from totals;
GO


