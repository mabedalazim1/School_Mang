USE [KPS_DATA_2023]
GO

/****** Object:  View [dbo].[V_Final_Degree_Valuation_B]    Script Date: 1/16/2025 9:51:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






ALTER view [dbo].[V_Final_Degree_Valuation_B]
as
select
std_code, Year_Id,Grade_Id, Golos,studentName,
dbo.get_Prim_Evaluation(ar_A,absent_ar_A) as 'arabic_A_Eval',
dbo.get_Prim_Evaluation_Term_B(ar_B,arbic_test_B, absent_ar_B) as 'arabic_B_Eval',
dbo.get_prim_Evaluation(math_A, absent_math_A) as 'math_A_Eval',
dbo.get_Prim_Evaluation_Term_B(math_B,math_test_B, absent_math_B) as 'math_B_Eval',
dbo.get_prim_Evaluation(scince_A, absent_scince_A) as 'scince_A_Eval',
dbo.get_Prim_Evaluation_Term_B(scince_B,scince_test_B, absent_scince_B) as 'scince_B_Eval',
dbo.get_prim_Evaluation(social_A, absent_social_A) as 'social_A_Eval',
dbo.get_Prim_Evaluation_Term_B(social_B,social_test_B, absent_social_B) as 'social_B_Eval',
dbo.get_prim_Evaluation(english_A, absent_english_A) as 'english_A_Eval',
dbo.get_Prim_Evaluation_Term_B(english_B,english_test_B, absent_english_B) as 'english_B_Eval',
dbo.get_prim_Evaluation(dain_A, absent_din_A) as 'dain_A_Eval',
dbo.get_Prim_Evaluation_Term_B(dain_B,dain_test_B, absent_din_B) as 'dain_B_Eval',
dbo.get_prim_Evaluation(tocnolegy_A, absent_tocnolegy_A) as 'tocnolegy_A_Eval',
dbo.get_Prim_Evaluation_Term_B(tocnolegy_B,tocnolegy_test_B, absent_tocnolegy_B) as 'tocnolegy_B_Eval',
dbo.get_prim_Evaluation(maharat_A, absent_maharat_A) as 'maharat_A_Eval',
dbo.get_Prim_Evaluation_Term_B(maharat_B,maharat_test_B, absent_maharat_B) as 'maharat_B_Eval',
dbo.get_Prim_Evaluation(ROUND(total_A_4_5_6/8,0),absent_term_A) as 'term_A_Eval',
dbo.get_Prim_Evaluation_Term_B(ROUND(total_B_4_5_6 /8,0),100,absent_term_B) as 'term_B_Eval',

dbo.get_Prim_Valuation(ar_A,absent_ar_A) as 'arabic_A_Val',
dbo.get_Prim_Valuation_Term_B(ar_B,arbic_test_B, absent_ar_B) as 'arabic_B_Val',
dbo.get_Prim_Valuation(math_A, absent_math_A) as 'math_A_Val',
dbo.get_Prim_Valuation_Term_B(math_B,math_test_B, absent_math_B) as 'math_B_Val',
dbo.get_Prim_Valuation(scince_A, absent_scince_A) as 'scince_A_Val',
dbo.get_Prim_Valuation_Term_B(scince_B,scince_test_B, absent_scince_B) as 'scince_B_Val',
dbo.get_Prim_Valuation(social_A, absent_social_A) as 'social_A_Val',
dbo.get_Prim_Valuation_Term_B(social_B,social_test_B, absent_social_B) as 'social_B_Val',
dbo.get_Prim_Valuation(english_A, absent_english_A) as 'english_A_Val',
dbo.get_Prim_Valuation_Term_B(english_B,english_test_B, absent_english_B) as 'english_B_Val',
dbo.get_Prim_Valuation(dain_A, absent_din_A) as 'dain_A_Val',
dbo.get_Prim_Valuation_Term_B(dain_B,dain_test_B, absent_din_B) as 'dain_B_Val',
dbo.get_Prim_Valuation(tocnolegy_A, absent_tocnolegy_A) as 'tocnolegy_A_Val',
dbo.get_Prim_Valuation_Term_B(tocnolegy_B,tocnolegy_test_B, absent_tocnolegy_B) as 'tocnolegy_B_Val',
dbo.get_Prim_Valuation(maharat_A, absent_maharat_A) as 'maharat_A_Val',
dbo.get_Prim_Valuation_Term_B(maharat_B,maharat_test_B, absent_maharat_B) as 'maharat_B_Val',
dbo.get_Prim_Valuation(ROUND(total_A_4_5_6 /8,0),absent_term_A) as 'term_A_Val',
dbo.get_Prim_Valuation_Term_B(ROUND(total_B_4_5_6 /8,0),100,absent_term_B) as 'term_B_Val',

absent_ar_A, absent_ar_B,absent_din_A, absent_din_B, absent_english_A, absent_english_B,
absent_maharat_A, absent_maharat_B, absent_math_A, absent_math_B,
absent_scince_A, absent_scince_B, absent_social_A, absent_social_B,
absent_term_A, absent_term_B, absent_tocnolegy_A, absent_tocnolegy_B,

dbo.get_Prim_Pass(ar_A,absent_ar_A) as 'pass_ar_A',
dbo.get_Prim_Pass(math_A, absent_math_A) as 'pass_math_A',
dbo.get_Prim_Pass(scince_A, absent_scince_A) as 'pass_scince_A',
dbo.get_Prim_Pass(social_A, absent_social_A) as 'pass_social_A',
dbo.get_Prim_Pass(english_A, absent_english_A) as 'pass_english_A',
dbo.get_Prim_Pass(dain_A, absent_din_A) as 'pass_dain_A',
dbo.get_Prim_Pass(tocnolegy_A, absent_tocnolegy_A) as 'pass_tocnolegy_A',
dbo.get_Prim_Pass(maharat_A, absent_maharat_A) as 'pass_maharat_A',
dbo.get_Prim_Pass(ROUND(total_A_4_5_6 /8,0),absent_term_A) as 'pass_term_A',

dbo.get_Prim_Pass_Term_B(ar_B,arbic_test_B, absent_ar_B) as 'pass_ar_B',
dbo.get_Prim_Pass_Term_B(math_B,math_test_B, absent_math_B) as 'pass_math_B',
dbo.get_Prim_Pass_Term_B(scince_B,scince_test_B, absent_scince_B) as 'pass_scince_B',
dbo.get_Prim_Pass_Term_B(social_B,social_test_B, absent_social_B) as 'pass_social_B',
dbo.get_Prim_Pass_Term_B(english_B,english_test_B, absent_english_B) as 'pass_english_B',
dbo.get_Prim_Pass_Term_B(dain_B,dain_test_B, absent_din_B) as 'pass_dain_B',
dbo.get_Prim_Pass_Term_B(tocnolegy_B,tocnolegy_test_B, absent_tocnolegy_B) as 'pass_tocnolegy_B',
dbo.get_Prim_Pass_Term_B(maharat_B,maharat_test_B, absent_maharat_B) as 'pass_maharat_B',
dbo.get_Prim_T2_Pass_Final(
dbo.get_Prim_Pass_Term_B(ar_B,arbic_test_B, absent_ar_B) ,
dbo.get_Prim_Pass_Term_B(math_B,math_test_B, absent_math_B),
dbo.get_Prim_Pass_Term_B(scince_B,scince_test_B, absent_scince_B) ,
dbo.get_Prim_Pass_Term_B(social_B,social_test_B, absent_social_B),
dbo.get_Prim_Pass_Term_B(english_B,english_test_B, absent_english_B),
dbo.get_Prim_Pass_Term_B(dain_B,dain_test_B, absent_din_B) ,
dbo.get_Prim_Pass_Term_B(tocnolegy_B,tocnolegy_test_B, absent_tocnolegy_B) ,
dbo.get_Prim_Pass_Term_B(maharat_B,maharat_test_B, absent_maharat_B),
absent_term_B) as 'pass_term_B'

 from totals ;
GO


