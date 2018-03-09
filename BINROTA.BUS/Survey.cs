using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BINROTA.DAL;
using CARETTA.COM;
using BINROTA.COM;
using System.Collections; 


namespace BINROTA.BUS
{
    public class Survey
    {
        public static DataTable GetMainSurveyQuestion()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.SurveyQuestion.GetMainSurveyQuestion();
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetSurveyChoices(int SurveyQuestionID)
        {
            SurveyChoice objSurvey = new SurveyChoice();
            objSurvey.SurveyQuestionID = SurveyQuestionID;
            return objSurvey.LoadByParams().Tables[0];
        }

        public static void AnswerInsert(int MemberID, int SurveyQuestionID, int SurveyChoiceID)
        {
            //TODO: Transection yapacaksýn haberin ola
            SurveyAnswer objSurvey = new SurveyAnswer();
            objSurvey.MemberID = MemberID;
            objSurvey.SurveyQuestionID = SurveyQuestionID;
            objSurvey.SurveyChoiceID = SurveyChoiceID;
            objSurvey.Save();

            SurveyChoice obj = new SurveyChoice();
            obj.Load(SurveyChoiceID);
            obj.SurveyVoteNumber++;
            obj.Save();
        }

        public static DataTable GetUserAnswer(int MemberID, int SurveyQuestionID)
        {
            SurveyAnswer objSurvey = new SurveyAnswer();
            objSurvey.MemberID = MemberID;
            objSurvey.SurveyQuestionID = SurveyQuestionID;
            return objSurvey.LoadByParams().Tables[0];
        }

        public static DataTable GetSurveyResult(int SurveyQuestionID)
        {
            SurveyChoice objSurvey = new SurveyChoice();
            objSurvey.SurveyQuestionID = SurveyQuestionID;
            return objSurvey.LoadByParams().Tables[0];
        }

        public static DataTable GetAllSurveys() {
            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.SurveyQuestion.LoadAll().Tables[0];
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetSurveyDetails(int SurveyID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.SurveyQuestion.GetSurveyDetails(SurveyID);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public void DeleteSurveyChoices(int SurveyQuestionID) {
            BINROTA.DAL.SurveyChoice.DeleteSurveyChoices(SurveyQuestionID);
        }

        public void Save(int SurveyID, bool isActive, bool isMain, string SurveyQuestion, DataTable dtSurveyChoices) {

            int IdentityQuestion = 0;
            BINROTA.DAL.SurveyQuestion objSurveyQuestion;
            BINROTA.DAL.SurveyChoice objSurveyChoice;

            // Soruyu Kaydet 
            objSurveyQuestion = new SurveyQuestion();
            if (SurveyID == 0) { 
                DeleteSurveyChoices(SurveyID);
                objSurveyQuestion.Load(SurveyID); 
            }
            objSurveyQuestion.isActive = isActive;
            objSurveyQuestion.isMain = isMain;
            objSurveyQuestion.SurveyQuestion = SurveyQuestion;
            IdentityQuestion = objSurveyQuestion.Save();

            //Seçenekleri Kaydet
            foreach (DataRow dr in dtSurveyChoices.Rows)
            {
                objSurveyChoice = new SurveyChoice();
                objSurveyChoice.SurveyChoice = dr["SurveyChoice"].ToString();
                objSurveyChoice.SurveyVoteNumber = Convert.ToInt32(dr["SurveyVoteNumber"]);
                objSurveyChoice.SurveyQuestionID = IdentityQuestion;
                objSurveyChoice.Save();
            }

        }

        public bool Delete(ArrayList arrQuestions) {
            BINROTA.DAL.SurveyQuestion objSurveyQuestion;
            try
            {
                for (int i = 0; i < arrQuestions.Count; i++)
                {
                    DeleteSurveyChoices(Convert.ToInt32(arrQuestions[i]));
                    objSurveyQuestion = new SurveyQuestion();
                    objSurveyQuestion.Load(Convert.ToInt32(arrQuestions[i]));
                    objSurveyQuestion.Delete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
