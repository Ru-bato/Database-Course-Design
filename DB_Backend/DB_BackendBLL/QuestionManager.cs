using DB_Backend.DB_BackendDAL;
using DB_Backend.DB_BackendModel;
using System.Data;

namespace DB_Backend.DB_BackendBLL
{
    public class QuestionManager
    {
        public static List<QuestionModel> ReturnList()
        {
            var dt = QuestionServer.ReturnList();
            List<QuestionModel> questionList = new List<QuestionModel>();

            // 将 DataTable 转换为 List<QuestionModel>
            foreach (DataRow row in dt.Rows)
            {
                QuestionModel question = new QuestionModel
                {
                    QuestionID = Convert.ToInt32(row["QUESTION_ID"]),
                    QuestionAnswer = row["QUESTION_ANSWER"].ToString(),
                    QuestionText = row["QUESTION_TEXT"].ToString(),
                    QuestionType = Convert.ToInt32(row["QUESTION_TYPE"])
                };
                questionList.Add(question);
            }

            return questionList;

        }

        public static Tuple<List<string>, List<string>> SearchRelatedQuestions(string questionSearch)
        {
            // 创建两个列表来存储结果
            List<string> questions = new List<string>();
            List<string> answers = new List<string>();

            // 调用 SearchInSQL 方法获取 DataTable
            var dt = QuestionServer.SearchInSQL(questionSearch);

            // 遍历 DataTable 的行，并将结果添加到列表中
            foreach (DataRow row in dt.Rows)
            {
                questions.Add(row["QUESTION_TEXT"].ToString());
                answers.Add(row["QUESTION_ANSWER"].ToString());
            }

            // 使用 Tuple 返回两个列表
            return Tuple.Create(questions, answers);
        }
    }
}
