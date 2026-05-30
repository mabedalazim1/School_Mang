USE [KPS_DATA_2023]
GO

/****** Object:  View [dbo].[V_Final_Degree_Valuation_C]    Script Date: 5/30/2025 7:25:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




alter view [dbo].[V_Final_Degree_Valuation_C]
as
select
std_code, Year_Id,Grade_Id, Golos,studentName,
dbo.get_Prep_Evaluation(ar_A,absent_ar_A) as 'arabic_A_Eval',
dbo.get_Prep_Evaluation_Term_B(ar_B,arbic_test_B, absent_ar_B) as 'arabic_B_Eval',
dbo.get_Prep_Evaluation(math_A, absent_math_A) as 'math_A_Eval',
dbo.get_Prep_Evaluation_Term_B(math_B,math_test_B, absent_math_B) as 'math_B_Eval',
dbo.get_Prep_Evaluation(scince_A, absent_scince_A) as 'scince_A_Eval',
dbo.get_Prep_Evaluation_Term_B(scince_B,scince_test_B, absent_scince_B) as 'scince_B_Eval',
dbo.get_Prep_Evaluation(social_A, absent_social_A) as 'social_A_Eval',
dbo.get_Prep_Evaluation_Term_B(social_B,social_test_B, absent_social_B) as 'social_B_Eval',
dbo.get_Prep_Evaluation(english_A, absent_english_A) as 'english_A_Eval',
dbo.get_Prep_Evaluation_Term_B(english_B,english_test_B, absent_english_B) as 'english_B_Eval',
dbo.get_Prep_Evaluation(dain_A, absent_din_A) as 'dain_A_Eval',
dbo.get_Prep_Evaluation_Term_B(dain_B,dain_test_B, absent_din_B) as 'dain_B_Eval',
dbo.get_Prep_Evaluation(tocnolegy_A, absent_tocnolegy_A) as 'tocnolegy_A_Eval',
dbo.get_Prep_Evaluation_Term_B(tocnolegy_B,tocnolegy_test_B, absent_tocnolegy_B) as 'tocnolegy_B_Eval',
dbo.get_Prep_Evaluation(maharat_A, absent_maharat_A) as 'maharat_A_Eval',
dbo.get_Prep_Evaluation_Term_B(maharat_B,maharat_test_B, absent_maharat_B) as 'maharat_B_Eval',
dbo.get_Prep_Evaluation(Round(total_B_7_8_9/5,0),absent_term_A) as 'term_A_Eval',
dbo.get_Prep_Evaluation_Term_B(Round(total_B_7_8_9/5,0),100,absent_term_B) as 'term_B_Eval',
dbo.get_Prep_Evaluation(nashat1,absent_term_B) as 'nashat1_Eval',
dbo.get_Prep_Evaluation(nashat2,absent_term_B) as 'nashat2_Eval',

dbo.get_Prep_Valuation(ar_A,absent_ar_A) as 'arabic_A_Val',
dbo.get_Prep_Valuation_Term_B(ar_B,arbic_test_B, absent_ar_B) as 'arabic_B_Val',
dbo.get_Prep_Valuation(math_A, absent_math_A) as 'math_A_Val',
dbo.get_Prep_Valuation_Term_B(math_B,math_test_B, absent_math_B) as 'math_B_Val',
dbo.get_Prep_Valuation(scince_A, absent_scince_A) as 'scince_A_Val',
dbo.get_Prep_Valuation_Term_B(scince_B,scince_test_B, absent_scince_B) as 'scince_B_Val',
dbo.get_Prep_Valuation(social_A, absent_social_A) as 'social_A_Val',
dbo.get_Prep_Valuation_Term_B(social_B,social_test_B, absent_social_B) as 'social_B_Val',
dbo.get_Prep_Valuation(english_A, absent_english_A) as 'english_A_Val',
dbo.get_Prep_Valuation_Term_B(english_B,english_test_B, absent_english_B) as 'english_B_Val',
dbo.get_Prep_Valuation(dain_A, absent_din_A) as 'dain_A_Val',
dbo.get_Prep_Valuation_Term_B(dain_B,dain_test_B, absent_din_B) as 'dain_B_Val',
dbo.get_Prep_Valuation(tocnolegy_A, absent_tocnolegy_A) as 'tocnolegy_A_Val',
dbo.get_Prep_Valuation_Term_B(tocnolegy_B,tocnolegy_test_B, absent_tocnolegy_B) as 'tocnolegy_B_Val',
dbo.get_Prep_Valuation(maharat_A, absent_maharat_A) as 'maharat_A_Val',
dbo.get_Prep_Valuation_Term_B(maharat_B,maharat_test_B, absent_maharat_B) as 'maharat_B_Val',
dbo.get_Prep_Valuation(Round(total_B_7_8_9/5,0),absent_term_A) as 'term_A_Val',
dbo.get_Prep_Valuation_Term_B(Round(total_B_7_8_9/5,0),100,absent_term_B) as 'term_B_Val',

ROUND((ar_B/2*80/100),2) as 'final_ar',
ROUND((math_B/2*60/100),2) as 'final_math',
ROUND((scince_B/2*40/100),2) as 'final_scince',
ROUND((social_B/2*40/100),2) as 'final_social',
ROUND((english_B/2*60/100),2) as 'final_english',

(ROUND((ar_B/2*80/100),2) +ROUND((math_B/2*60/100),2)
+ ROUND((scince_B/2*40/100),2) + ROUND((social_B/2*40/100),2)
+ ROUND((english_B/2*60/100),2)) as 'final_total',

ROUND((dain_B/2*40/100),2) as 'final_dain',
ROUND((tocnolegy_B/2*20/100),2) as 'final_tocnolegy',
ROUND((maharat_B/2*20/100),2) as 'final_maharat',
ROUND((nashat1*20/100),2) as 'final_nashat1',
ROUND((nashat2*20/100),2) as 'final_nashat2',


dbo.get_Prep_Pass_Term_B(ar_B,arbic_test_B, absent_ar_B) as 'pass_ar_B',
dbo.get_Prep_Pass_Term_B(math_B,math_test_B, absent_math_B) as 'pass_math_B',
dbo.get_Prep_Pass_Term_B(scince_B,scince_test_B, absent_scince_B) as 'pass_scince_B',
dbo.get_Prep_Pass_Term_B(social_B,social_test_B, absent_social_B) as 'pass_social_B',
dbo.get_Prep_Pass_Term_B(english_B,english_test_B, absent_english_B) as 'pass_english_B',
dbo.get_Prep_Pass_Term_B(dain_B,dain_test_B, absent_din_B) as 'pass_dain_B',
dbo.get_Prep_Pass_Term_B(tocnolegy_B,tocnolegy_test_B, absent_tocnolegy_B) as 'pass_tocnolegy_B',
dbo.get_Prep_Pass_Term_B(maharat_B,maharat_test_B, absent_maharat_B) as 'pass_maharat_B'
,dbo.get_Prep_T2_Pass_Final(
dbo.get_Prep_Pass_Term_B(ar_B,arbic_test_B, absent_ar_B) ,
dbo.get_Prep_Pass_Term_B(math_B,math_test_B, absent_math_B),
dbo.get_Prep_Pass_Term_B(scince_B,scince_test_B, absent_scince_B) ,
dbo.get_Prep_Pass_Term_B(social_B,social_test_B, absent_social_B),
dbo.get_Prep_Pass_Term_B(english_B,english_test_B, absent_english_B), absent_term_B) as 'pass_term_B',

dbo.get_Prep_Pass_Term_B_2025(ar_B,arbic_test_B, absent_ar_B) as 'pass_ar_B_2025',
dbo.get_Prep_Pass_Term_B_2025(math_B,math_test_B, absent_math_B) as 'pass_math_B_2025',
dbo.get_Prep_Pass_Term_B_2025(scince_B,scince_test_B, absent_scince_B) as 'pass_scince_B_2025',
dbo.get_Prep_Pass_Term_B_2025(social_B,social_test_B, absent_social_B) as 'pass_social_B_2025',
dbo.get_Prep_Pass_Term_B_2025(english_B,english_test_B, absent_english_B) as 'pass_english_B_2025',
dbo.get_Prep_Pass_Term_B_2025(dain_B,dain_test_B, absent_din_B) as 'pass_dain_B_2025',
dbo.get_Prep_Pass_Term_B_2025(tocnolegy_B,tocnolegy_test_B, absent_tocnolegy_B) as 'pass_tocnolegy_B_2025',
dbo.get_Prep_Pass_Term_B_2025(maharat_B,maharat_test_B, absent_maharat_B) as 'pass_maharat_B_2025'
,dbo.get_Prep_T2_Pass_Final(
dbo.get_Prep_Pass_Term_B_2025(ar_B,arbic_test_B, absent_ar_B) ,
dbo.get_Prep_Pass_Term_B_2025(math_B,math_test_B, absent_math_B),
dbo.get_Prep_Pass_Term_B_2025(scince_B,scince_test_B, absent_scince_B) ,
dbo.get_Prep_Pass_Term_B_2025(social_B,social_test_B, absent_social_B),
dbo.get_Prep_Pass_Term_B_2025(english_B,english_test_B, absent_english_B), absent_term_B) as 'pass_term_B_2025'

 from totals;
GO


