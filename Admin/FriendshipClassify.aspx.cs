using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using edu.stanford.nlp.tagger.maxent;
using java.io;
using java.util;
using edu.stanford.nlp.ling;

namespace FilterUnwantedMSG_OSN.Admin
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        public static DataTable dtContent;
        String posstring;
        string newString;
        private static int Ns = 1, Pc, Nx;
        public List<string> Emoticon = new List<string>();
        public List<string> Stopword = new List<string>();
        public string Model = HttpContext.Current.Server.MapPath(@"~\Bin\english-caseless-left3words-distsim.tagger");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillddlUser();
            }
        }
        protected void GetStopword()
        {
            SqlDataAdapter da = new SqlDataAdapter(new SqlCommand("select Word from StopWord", DBConnection.conn));
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                Stopword.Add((string)row[0]);
            }
        }

        protected void GetEmoticon()
        {
            SqlDataAdapter daGetEmo = new SqlDataAdapter(new SqlCommand("select Emoticon from Emoticons", DBConnection.conn));
            DataTable dt = new DataTable();
            daGetEmo.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                Emoticon.Add((string)row[0]);
            }
        }

        private void TagReader(Reader reader)
        {
            var tagger = new MaxentTagger(Model);
            //List obj = (List)MaxentTagger.tokenizeText(reader);
            foreach (ArrayList sentence in MaxentTagger.tokenizeText(reader).toArray())
            {
                var tSentence = tagger.tagSentence(sentence);
                System.Console.WriteLine(Sentence.listToString(tSentence, false));
                posstring = (Sentence.listToString(tSentence, false));
                newString = newString + posstring;
                System.Console.WriteLine();
            }

        }

        protected void fillddlUser()
        {
            SqlDataAdapter da = new SqlDataAdapter(new SqlCommand("select User_id,(Fname +' '+Mname+' '+Lname)as Name from Users", DBConnection.conn));
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlUsers.DataSource = dt;
            ddlUsers.DataBind();
            ddlUsers.Items.Insert(0, new ListItem("<-Select User->", "0"));
        }

        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data();
            //SqlDataAdapter da = new SqlDataAdapter(new SqlCommand("select cm.cmtId, cm.PostId, cm.User_id, cm.Comment,(u.Fname+' '+u.Lname)as Name,cm.Polarity,cm.freindtype from CommentMaster cm,Users u where cm.User_id=u.User_id and cm.PostId in(Select PostId from PostData where FromUser=@FromUser)", DBConnection.conn));
            //da.SelectCommand.Parameters.AddWithValue("@FromUser", ddlUsers.SelectedValue);
            //dtContent = new DataTable();
            //da.Fill(dtContent);
            //GridView1.DataSource = dtContent;
            //GridView1.DataBind();
        }

        protected void btnClassify_Click(object sender, EventArgs e)
        {
            //    SqlDataAdapter daGetComment = new SqlDataAdapter("select cm.cmtId, cm.PostId, cm.User_id, cm.Comment,(u.Fname+' '+u.Lname)as Name,cm.Polarity from CommentMaster cm,Users u where cm.User_id=u.User_id and cm.polarity is null and  cm.PostId in(Select PostId from PostData where FromUser=@FromUser)", DBConnection.conn);
            //    daGetComment.SelectCommand.Parameters.AddWithValue("@FromUser", ddlUsers.SelectedValue);
            //    DataTable dtComment = new DataTable();
            //    daGetComment.Fill(dtComment);
            //    foreach (DataRow row in dtComment.Rows)
            //    {
            //        string PostContent = row["Comment"].ToString();
            //        Pc = PostContent.Count(c => char.IsUpper(c));
            //        Nx = PostContent.Count(f => f == '!');
            //        if (Nx == 0)
            //        {
            //            Nx = 1;
            //        }

            //        string[] words = PostContent.Split(' ');
            //        truncate();
            //        var counts = words
            //         .GroupBy(w => w)
            //         .Select(g => new { Word = g.Key, Count = g.Count() })
            //         .ToList();
            //        foreach (var p in counts)
            //        {
            //            // Console.WriteLine("Word '{0}' found {1} times", p.Word, p.Count);
            //            SqlDataAdapter da = new SqlDataAdapter(new SqlCommand("insert into CountWords (Word,NoOfCount)values('" + p.Word + "','" + p.Count + "')", DBConnection.conn));
            //            DBConnection.conn.Open();
            //            da.SelectCommand.ExecuteNonQuery();
            //            DBConnection.conn.Close();
            //        }

            //        SqlDataAdapter da1 = new SqlDataAdapter(new SqlCommand("delete from CountWords where word=' '", DBConnection.conn));
            //        DBConnection.conn.Open();
            //        da1.SelectCommand.ExecuteNonQuery();
            //        DBConnection.conn.Close();

            //        // SqlDataAdapter da2 = new SqlDataAdapter(new SqlCommand("select COUNT(word)as WordCount from CountWords where NoOfCount>=2", Comman.DbConnection.conn));

            //        SqlCommand cmd = new SqlCommand("select COUNT(word)as WordCount from CountWords where NoOfCount>=2");
            //        cmd.Connection = DBConnection.conn;
            //        DBConnection.conn.Open();
            //        SqlDataReader dr = cmd.ExecuteReader();
            //        while (dr.Read())
            //        {
            //            if (dr.HasRows)
            //            {
            //                Ns = Convert.ToInt32(dr["WordCount"].ToString());
            //            }
            //            else
            //            {
            //                Ns = 1;
            //            }
            //            if (Ns == 0)
            //            {
            //                Ns = 1;
            //            }
            //        }
            //        DBConnection.conn.Close();
            //        newString = "";
            //        TagReader(new java.io.StringReader(PostContent));
            //        string para = newString;
            //        List<string> lstRB = new List<string>();
            //        List<string> lstJJ = new List<string>();
            //        List<string> lstNextJJ = new List<string>();
            //        List<string> lstVBP = new List<string>();
            //        //int  AG = 0, EMO = 0, OI = 0;
            //        double VG = 0, AG = 0, EMO = 0, OI = 0;
            //        string[] word = para.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //        for (int i = 0; i < word.Length; i++)
            //        {
            //            int startindex = word[i].IndexOf("/");
            //            if (startindex < 0) { startindex = 0; }
            //            int lastindex = word[i].Length;
            //            string NewPos = word[i].Remove(0, startindex);
            //            string NewWord = word[i].Substring(0, startindex);
            //            switch (NewPos)
            //            {
            //                case "/VBP":
            //                    {
            //                        Stopword.Clear();
            //                        GetStopword();
            //                        int flag = 1;
            //                        for (int j = 0; j < Stopword.Count; j++)
            //                        {
            //                            if (NewWord == Stopword[j])
            //                            {
            //                                flag = 0;
            //                                break;
            //                            }
            //                        }
            //                        if (flag == 1)
            //                        {
            //                            lstVBP.Add((string)NewWord);
            //                        }
            //                        break;
            //                    }
            //                case "/RB":
            //                    {
            //                        lstRB.Add((string)NewWord);
            //                        if (i + 1 <= word.Length)
            //                        {
            //                            int Nextstartindex = word[i + 1].IndexOf("/");
            //                            if (Nextstartindex < 0) { Nextstartindex = 0; }
            //                            int Nextlastindex = word[i + 1].Length;
            //                            string NextNewPos = word[i + 1].Remove(0, Nextstartindex);
            //                            string NextNewWord = word[i + 1].Substring(0, Nextstartindex);
            //                            if (NextNewPos == "/JJ")
            //                            {
            //                                lstJJ.Add((string)NextNewWord);
            //                                i = i + 1;
            //                            }
            //                            else
            //                            {
            //                                lstRB.RemoveAt(lstRB.Count - 1);
            //                            }
            //                        }
            //                        else
            //                        {
            //                            lstRB.RemoveAt(lstRB.Count - 1);
            //                        }
            //                        break;
            //                    }
            //                case "/JJ":
            //                    {
            //                        lstNextJJ.Add((string)NewWord);
            //                        break;
            //                    }
            //                default:
            //                    { break; }
            //            }
            //        }
            //        //FIND Score of Verb Group
            //        for (int vbp = 0; vbp < lstVBP.Count; vbp++)
            //        {
            //            SqlDataAdapter daVBP = new SqlDataAdapter(new SqlCommand("select MAX(PosScore)as pos, MAX(NegScore)as Neg from dbo.SentiWordNet where SynsetTerms='" + lstVBP[vbp] + "'", DBConnection.conn));
            //            DataTable dtVBP = new DataTable();
            //            daVBP.Fill(dtVBP);
            //            if (dtVBP.Rows.Count > 0 && dtVBP.Rows[0]["pos"] != DBNull.Value || dtVBP.Rows[0]["neg"] != DBNull.Value)
            //            {
            //                Double PosScore = Convert.ToDouble(dtVBP.Rows[0]["pos"].ToString());
            //                Double NegScore = Convert.ToDouble(dtVBP.Rows[0]["neg"].ToString());
            //                if (PosScore > NegScore)
            //                {
            //                    VG = PosScore;
            //                }
            //                else if (NegScore > PosScore)
            //                {
            //                    VG = -(NegScore);
            //                }
            //                else
            //                {
            //                    VG = 0;
            //                }
            //                //VG Score Generate
            //                VG = +VG;
            //            }
            //            else
            //            {
            //                VG = 0;
            //            }
            //        }
            //        //FIND Score of Adjective Group
            //        Double RBscore = 0;
            //        Double JJScore = 0;
            //        for (int RB = 0; RB < lstRB.Count; RB++)
            //        {
            //            SqlDataAdapter daRB = new SqlDataAdapter(new SqlCommand("select MAX(PosScore)as pos, MAX(NegScore)as Neg from dbo.SentiWordNet where SynsetTerms='" + lstRB[RB] + "';select MAX(PosScore)as pos, MAX(NegScore)as Neg from dbo.SentiWordNet where SynsetTerms='" + lstJJ[RB] + "'", DBConnection.conn));
            //            DataSet dsRB = new DataSet();
            //            daRB.Fill(dsRB);

            //            if (dsRB.Tables[0].Rows.Count > 0 && dsRB.Tables[0].Rows[0]["pos"] != DBNull.Value || dsRB.Tables[0].Rows[0]["neg"] != DBNull.Value)
            //            {

            //                Double PosScore = Convert.ToDouble(dsRB.Tables[0].Rows[0]["pos"].ToString());
            //                Double NegScore = Convert.ToDouble(dsRB.Tables[0].Rows[0]["neg"].ToString());
            //                if (PosScore > NegScore)
            //                {
            //                    RBscore = PosScore;
            //                }
            //                else
            //                {
            //                    RBscore = -(NegScore);
            //                }
            //            }
            //            else
            //            {
            //                RBscore = 1;
            //            }
            //            if (dsRB.Tables[1].Rows.Count > 0 && dsRB.Tables[1].Rows[0]["pos"] != DBNull.Value || dsRB.Tables[1].Rows[0]["neg"] != DBNull.Value)
            //            {
            //                Double PosScore = Convert.ToDouble(dsRB.Tables[1].Rows[0]["pos"].ToString());
            //                Double NegScore = Convert.ToDouble(dsRB.Tables[1].Rows[0]["neg"].ToString());
            //                if (PosScore > NegScore)
            //                {
            //                    JJScore = PosScore;
            //                }
            //                else if (NegScore > PosScore)
            //                {
            //                    JJScore = -(NegScore);
            //                }
            //                else
            //                {
            //                    JJScore = 0;
            //                }
            //            }
            //            else
            //            {
            //                JJScore = 1;
            //            }

            //            AG = RBscore * JJScore;


            //            //AG Score Generate
            //            AG = +AG;
            //        }

            //        Double NextjjScore = 0;
            //        for (int nextjj = 0; nextjj < lstNextJJ.Count; nextjj++)
            //        {
            //            SqlDataAdapter daJJ = new SqlDataAdapter(new SqlCommand("select MAX(PosScore)as pos, MAX(NegScore)as Neg from dbo.SentiWordNet where SynsetTerms='" + lstNextJJ[nextjj] + "' ", DBConnection.conn));
            //            DataTable dtJJ = new DataTable();
            //            daJJ.Fill(dtJJ);
            //            if (dtJJ.Rows.Count > 0 && dtJJ.Rows[0]["pos"] != DBNull.Value || dtJJ.Rows[0]["neg"] != DBNull.Value)
            //            {
            //                Double PosScore = Convert.ToDouble(dtJJ.Rows[0]["pos"].ToString());
            //                Double NegScore = Convert.ToDouble(dtJJ.Rows[0]["neg"].ToString());
            //                if (PosScore > NegScore)
            //                {
            //                    NextjjScore = PosScore;
            //                }
            //                else if (NegScore > PosScore)
            //                    NextjjScore = -(NegScore);
            //                else
            //                    NextjjScore = 0;
            //            }
            //            NextjjScore = +NextjjScore;
            //        }
            //        AG = +NextjjScore;
            //        ///Find Count Of EMOTICONS And Score Of Emoticons
            //        GetEmoticon();
            //        string Emostyle;
            //        int CountEmostyle = 0;
            //        Double EmoFinalValue = 0;
            //        for (int em = 0; em < Emoticon.Count; em++)
            //        {
            //            SqlDataAdapter daEmos = new SqlDataAdapter(new SqlCommand("select Word,NoOfCount from CountWords where Word='" + Emoticon[em] + "'", DBConnection.conn));
            //            DataTable dtEmos = new DataTable();
            //            daEmos.Fill(dtEmos);
            //            if (dtEmos.Rows.Count > 0)
            //            {
            //                Emostyle = dtEmos.Rows[0]["Word"].ToString();
            //                CountEmostyle = Convert.ToInt32(dtEmos.Rows[0]["NoOfCount"].ToString());

            //                SqlDataAdapter daEmovalue = new SqlDataAdapter(new SqlCommand("select Strength from Emoticons where Emoticon='" + Emostyle + "'", DBConnection.conn));
            //                DataTable dtEmoValue = new DataTable();
            //                daEmovalue.Fill(dtEmoValue);
            //                if (dtEmoValue.Rows.Count > 0)
            //                {
            //                    EmoFinalValue = Convert.ToDouble(dtEmoValue.Rows[0]["Strength"].ToString());
            //                }
            //            }
            //            EmoFinalValue = +EmoFinalValue;
            //            CountEmostyle = +CountEmostyle;

            //        }
            //        EMO = CountEmostyle * EmoFinalValue;
            //        //Find OI
            //        OI = lstVBP.Count + lstJJ.Count + lstNextJJ.Count + lstRB.Count + CountEmostyle;

            //        if (OI == 0)
            //            OI = 1;
            //        //Tweet Sentiment Scoring
            //        Double LastScore = Convert.ToDouble((1 + (Pc + Math.Log(Ns) + Math.Log(Nx)) / 3) * (AG + VG + EMO)) / OI;
            //        if (LastScore < 0)
            //        {
            //            SqlCommand cmdUpdate = new SqlCommand("update CommentMaster set Score=@Score,Polarity='Objective' where PostId=@PostId", DBConnection.conn);
            //            cmdUpdate.Parameters.AddWithValue("@Score", LastScore);
            //            cmdUpdate.Parameters.AddWithValue("@PostId", row["PostId"].ToString());
            //            DBConnection.conn.Open();
            //            cmdUpdate.ExecuteNonQuery();
            //            DBConnection.conn.Close();
            //        }
            //        else if (LastScore > 0)
            //        {
            //            SqlCommand cmdUpdate = new SqlCommand("update CommentMaster set Score=@Score,Polarity='Subjective' where PostId=@PostId", DBConnection.conn);
            //            cmdUpdate.Parameters.AddWithValue("@Score", LastScore);
            //            cmdUpdate.Parameters.AddWithValue("@PostId", row["PostId"].ToString());
            //            DBConnection.conn.Open();
            //            cmdUpdate.ExecuteNonQuery();
            //            DBConnection.conn.Close();
            //        }
            //        else
            //        {
            //            SqlCommand cmdUpdate = new SqlCommand("update CommentMaster set Score=@Score,Polarity='Moderate' where PostId=@PostId", DBConnection.conn);
            //            cmdUpdate.Parameters.AddWithValue("@Score", LastScore);
            //            cmdUpdate.Parameters.AddWithValue("@PostId", row["PostId"].ToString());
            //            DBConnection.conn.Open();
            //            cmdUpdate.ExecuteNonQuery();
            //            DBConnection.conn.Close();
            //        }
            //    }

            //    SqlDataAdapter daGetResult = new SqlDataAdapter("select cm.cmtId, cm.PostId, cm.User_id, cm.Comment,(u.Fname+' '+u.Lname)as Name,cm.Polarity from CommentMaster cm,Users u where cm.User_id=u.User_id and  cm.PostId in(Select PostId from PostData where FromUser=@FromUser)", DBConnection.conn);
            //    daGetResult.SelectCommand.Parameters.AddWithValue("@FromUser", ddlUsers.SelectedValue);
            //    DataTable dtResult = new DataTable();
            //    daGetResult.Fill(dtResult);
            //    GridView1.DataSource = dtResult;
            //    GridView1.DataBind();
        }
        protected void truncate()
        {
            SqlCommand cmd = new SqlCommand("truncate table CountWords", DBConnection.conn);
            DBConnection.conn.Open();
            cmd.ExecuteNonQuery();
            DBConnection.conn.Close();
        }

        protected void Data()
        {
            Truncate_Data();
            Truncate_Data1();
            //SqlDataAdapter daGetComment = new SqlDataAdapter("select cm.cmtId, cm.PostId, cm.User_id, cm.Comment,(u.Fname+' '+u.Lname)as Name,cm.Polarity from CommentMaster cm,Users u where cm.User_id=u.User_id and  cm.PostId in(Select PostId from PostData where FromUser=@FromUser)", DBConnection.conn);
            SqlDataAdapter daGetComment = new SqlDataAdapter("select cm.cmtId, cm.PostId, cm.User_id, cm.Comment,(u.Fname+' '+u.Lname)as Name,cm.Polarity,cm.freindtype from CommentMaster cm,Users u where cm.User_id=u.User_id and  cm.PostId in(Select PostId from PostData where FromUser=@FromUser)", DBConnection.conn);
            daGetComment.SelectCommand.Parameters.AddWithValue("@FromUser", ddlUsers.SelectedValue);
            DataTable dtComment = new DataTable();
            daGetComment.Fill(dtComment);


            //temp Insert
            List<string> list = new List<string>();
            for (int l = 0; l < dtComment.Rows.Count; l++)
            {
                SqlCommand cmdtemp = new SqlCommand("insert into Temp values(@cmtId, @PostId, @User_id, @Comment, @Name, @Polarity, @freindtype)", DBConnection.conn);
                cmdtemp.Parameters.AddWithValue("@cmtId", dtComment.Rows[l]["cmtId"]);
                cmdtemp.Parameters.AddWithValue("@PostId", dtComment.Rows[l]["PostId"]);
                cmdtemp.Parameters.AddWithValue("@User_id", dtComment.Rows[l]["User_id"]);
                cmdtemp.Parameters.AddWithValue("@Comment", dtComment.Rows[l]["Comment"]);
                cmdtemp.Parameters.AddWithValue("@Name", dtComment.Rows[l]["Name"]);
                cmdtemp.Parameters.AddWithValue("@Polarity", dtComment.Rows[l]["Polarity"]);
                cmdtemp.Parameters.AddWithValue("@freindtype", dtComment.Rows[l]["freindtype"]);
                DBConnection.conn.Open();
                cmdtemp.ExecuteNonQuery();
                DBConnection.conn.Close();

            }

            SqlDataAdapter adptemp = new SqlDataAdapter("Select Distinct(User_id) from Temp", DBConnection.conn);
            DataTable dt_temp = new DataTable();
            adptemp.Fill(dt_temp);
            string name;
            for (int k = 0; k < dt_temp.Rows.Count; k++)
            {
                int U_Id = Convert.ToInt32(dt_temp.Rows[k]["User_id"]);
                SqlDataAdapter _adt1 = new SqlDataAdapter("Select * from Temp where User_id='" + U_Id + "'", DBConnection.conn);
                DataTable _dt1 = new DataTable();
                _adt1.Fill(_dt1);
                name = _dt1.Rows[0]["Name"].ToString();
                string Post; string comment = "";
                for (int j = 0; j < _dt1.Rows.Count; j++)
                {
                    Post = _dt1.Rows[j]["Comment"].ToString();
                    list.Add(Post);
                }


                foreach (var item in list)
                {
                    comment += " " + item;
                }

                //SqlDataAdapter daGetComment = new SqlDataAdapter("select cm.cmtId, cm.PostId, cm.User_id, cm.Comment,(u.Fname+' '+u.Lname)as Name,cm.Polarity from CommentMaster cm,Users u where cm.User_id=u.User_id and cm.polarity is null and  cm.PostId in(Select PostId from PostData where FromUser=@FromUser)", DBConnection.conn);
                //daGetComment.SelectCommand.Parameters.AddWithValue("@FromUser", ddlUsers.SelectedValue);
                //DataTable dtComment = new DataTable();
                //daGetComment.Fill(dtComment);
                //foreach (DataRow row in dtComment.Rows)
                //{
                string PostContent = comment;
                Pc = PostContent.Count(c => char.IsUpper(c));
                Nx = PostContent.Count(f => f == '!');
                if (Nx == 0)
                {
                    Nx = 1;
                }

                string[] words = PostContent.Split(' ');
                truncate();
                var counts = words
                 .GroupBy(w => w)
                 .Select(g => new { Word = g.Key, Count = g.Count() })
                 .ToList();
                foreach (var p in counts)
                {
                    // Console.WriteLine("Word '{0}' found {1} times", p.Word, p.Count);
                    SqlDataAdapter da = new SqlDataAdapter(new SqlCommand("insert into CountWords (Word,NoOfCount)values('" + p.Word + "','" + p.Count + "')", DBConnection.conn));
                    DBConnection.conn.Open();
                    da.SelectCommand.ExecuteNonQuery();
                    DBConnection.conn.Close();
                }

                SqlDataAdapter da1 = new SqlDataAdapter(new SqlCommand("delete from CountWords where word=' '", DBConnection.conn));
                DBConnection.conn.Open();
                da1.SelectCommand.ExecuteNonQuery();
                DBConnection.conn.Close();

                // SqlDataAdapter da2 = new SqlDataAdapter(new SqlCommand("select COUNT(word)as WordCount from CountWords where NoOfCount>=2", Comman.DbConnection.conn));

                SqlCommand cmd = new SqlCommand("select COUNT(word)as WordCount from CountWords where NoOfCount>=2");
                cmd.Connection = DBConnection.conn;
                DBConnection.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        Ns = Convert.ToInt32(dr["WordCount"].ToString());
                    }
                    else
                    {
                        Ns = 1;
                    }
                    if (Ns == 0)
                    {
                        Ns = 1;
                    }
                }
                DBConnection.conn.Close();
                newString = "";
                TagReader(new java.io.StringReader(PostContent));
                string para = newString;
                List<string> lstRB = new List<string>();
                List<string> lstJJ = new List<string>();
                List<string> lstNextJJ = new List<string>();
                List<string> lstVBP = new List<string>();
                //int  AG = 0, EMO = 0, OI = 0;
                double VG = 0, AG = 0, EMO = 0, OI = 0;
                string[] word = para.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < word.Length; i++)
                {
                    int startindex = word[i].IndexOf("/");
                    if (startindex < 0) { startindex = 0; }
                    int lastindex = word[i].Length;
                    string NewPos = word[i].Remove(0, startindex);
                    string NewWord = word[i].Substring(0, startindex);
                    switch (NewPos)
                    {
                        case "/VBP":
                            {
                                Stopword.Clear();
                                GetStopword();
                                int flag = 1;
                                for (int j = 0; j < Stopword.Count; j++)
                                {
                                    if (NewWord == Stopword[j])
                                    {
                                        flag = 0;
                                        break;
                                    }
                                }
                                if (flag == 1)
                                {
                                    lstVBP.Add((string)NewWord);
                                }
                                break;
                            }
                        case "/RB":
                            {
                                lstRB.Add((string)NewWord);
                                if (i + 1 <= word.Length)
                                {
                                    int Nextstartindex = word[i + 1].IndexOf("/");
                                    if (Nextstartindex < 0) { Nextstartindex = 0; }
                                    int Nextlastindex = word[i + 1].Length;
                                    string NextNewPos = word[i + 1].Remove(0, Nextstartindex);
                                    string NextNewWord = word[i + 1].Substring(0, Nextstartindex);
                                    if (NextNewPos == "/JJ")
                                    {
                                        lstJJ.Add((string)NextNewWord);
                                        i = i + 1;
                                    }
                                    else
                                    {
                                        lstRB.RemoveAt(lstRB.Count - 1);
                                    }
                                }
                                else
                                {
                                    lstRB.RemoveAt(lstRB.Count - 1);
                                }
                                break;
                            }
                        case "/JJ":
                            {
                                lstNextJJ.Add((string)NewWord);
                                break;
                            }
                        default:
                            { break; }
                    }
                }
                //FIND Score of Verb Group
                for (int vbp = 0; vbp < lstVBP.Count; vbp++)
                {
                    SqlDataAdapter daVBP = new SqlDataAdapter(new SqlCommand("select MAX(PosScore)as pos, MAX(NegScore)as Neg from dbo.SentiWordNet where SynsetTerms='" + lstVBP[vbp] + "'", DBConnection.conn));
                    DataTable dtVBP = new DataTable();
                    daVBP.Fill(dtVBP);
                    if (dtVBP.Rows.Count > 0 && dtVBP.Rows[0]["pos"] != DBNull.Value || dtVBP.Rows[0]["neg"] != DBNull.Value)
                    {
                        Double PosScore = Convert.ToDouble(dtVBP.Rows[0]["pos"].ToString());
                        Double NegScore = Convert.ToDouble(dtVBP.Rows[0]["neg"].ToString());
                        if (PosScore > NegScore)
                        {
                            VG = PosScore;
                        }
                        else if (NegScore > PosScore)
                        {
                            VG = -(NegScore);
                        }
                        else
                        {
                            VG = 0;
                        }
                        //VG Score Generate
                        VG = +VG;
                    }
                    else
                    {
                        VG = 0;
                    }
                }
                //FIND Score of Adjective Group
                Double RBscore = 0;
                Double JJScore = 0;
                for (int RB = 0; RB < lstRB.Count; RB++)
                {
                    SqlDataAdapter daRB = new SqlDataAdapter(new SqlCommand("select MAX(PosScore)as pos, MAX(NegScore)as Neg from dbo.SentiWordNet where SynsetTerms='" + lstRB[RB] + "';select MAX(PosScore)as pos, MAX(NegScore)as Neg from dbo.SentiWordNet where SynsetTerms='" + lstJJ[RB] + "'", DBConnection.conn));
                    DataSet dsRB = new DataSet();
                    daRB.Fill(dsRB);

                    if (dsRB.Tables[0].Rows.Count > 0 && dsRB.Tables[0].Rows[0]["pos"] != DBNull.Value || dsRB.Tables[0].Rows[0]["neg"] != DBNull.Value)
                    {

                        Double PosScore = Convert.ToDouble(dsRB.Tables[0].Rows[0]["pos"].ToString());
                        Double NegScore = Convert.ToDouble(dsRB.Tables[0].Rows[0]["neg"].ToString());
                        if (PosScore > NegScore)
                        {
                            RBscore = PosScore;
                        }
                        else
                        {
                            RBscore = -(NegScore);
                        }
                    }
                    else
                    {
                        RBscore = 1;
                    }
                    if (dsRB.Tables[1].Rows.Count > 0 && dsRB.Tables[1].Rows[0]["pos"] != DBNull.Value || dsRB.Tables[1].Rows[0]["neg"] != DBNull.Value)
                    {
                        Double PosScore = Convert.ToDouble(dsRB.Tables[1].Rows[0]["pos"].ToString());
                        Double NegScore = Convert.ToDouble(dsRB.Tables[1].Rows[0]["neg"].ToString());
                        if (PosScore > NegScore)
                        {
                            JJScore = PosScore;
                        }
                        else if (NegScore > PosScore)
                        {
                            JJScore = -(NegScore);
                        }
                        else
                        {
                            JJScore = 0;
                        }
                    }
                    else
                    {
                        JJScore = 1;
                    }

                    AG = RBscore * JJScore;


                    //AG Score Generate
                    AG = +AG;
                }

                Double NextjjScore = 0;
                for (int nextjj = 0; nextjj < lstNextJJ.Count; nextjj++)
                {
                    SqlDataAdapter daJJ = new SqlDataAdapter(new SqlCommand("select MAX(PosScore)as pos, MAX(NegScore)as Neg from dbo.SentiWordNet where SynsetTerms='" + lstNextJJ[nextjj] + "' ", DBConnection.conn));
                    DataTable dtJJ = new DataTable();
                    daJJ.Fill(dtJJ);
                    if (dtJJ.Rows.Count > 0 && dtJJ.Rows[0]["pos"] != DBNull.Value || dtJJ.Rows[0]["neg"] != DBNull.Value)
                    {
                        Double PosScore = Convert.ToDouble(dtJJ.Rows[0]["pos"].ToString());
                        Double NegScore = Convert.ToDouble(dtJJ.Rows[0]["neg"].ToString());
                        if (PosScore > NegScore)
                        {
                            NextjjScore = PosScore;
                        }
                        else if (NegScore > PosScore)
                            NextjjScore = -(NegScore);
                        else
                            NextjjScore = 0;
                    }
                    NextjjScore = +NextjjScore;
                }
                AG = +NextjjScore;
                ///Find Count Of EMOTICONS And Score Of Emoticons
                GetEmoticon();
                string Emostyle;
                int CountEmostyle = 0;
                Double EmoFinalValue = 0;
                for (int em = 0; em < Emoticon.Count; em++)
                {
                    SqlDataAdapter daEmos = new SqlDataAdapter(new SqlCommand("select Word,NoOfCount from CountWords where Word='" + Emoticon[em] + "'", DBConnection.conn));
                    DataTable dtEmos = new DataTable();
                    daEmos.Fill(dtEmos);
                    if (dtEmos.Rows.Count > 0)
                    {
                        Emostyle = dtEmos.Rows[0]["Word"].ToString();
                        CountEmostyle = Convert.ToInt32(dtEmos.Rows[0]["NoOfCount"].ToString());

                        SqlDataAdapter daEmovalue = new SqlDataAdapter(new SqlCommand("select Strength from Emoticons where Emoticon='" + Emostyle + "'", DBConnection.conn));
                        DataTable dtEmoValue = new DataTable();
                        daEmovalue.Fill(dtEmoValue);
                        if (dtEmoValue.Rows.Count > 0)
                        {
                            EmoFinalValue = Convert.ToDouble(dtEmoValue.Rows[0]["Strength"].ToString());
                        }
                    }
                    EmoFinalValue = +EmoFinalValue;
                    CountEmostyle = +CountEmostyle;

                }
                EMO = CountEmostyle * EmoFinalValue;
                //Find OI
                OI = lstVBP.Count + lstJJ.Count + lstNextJJ.Count + lstRB.Count + CountEmostyle;

                if (OI == 0)
                    OI = 1;
                //Tweet Sentiment Scoring
                Double LastScore = Convert.ToDouble((1 + (Pc + Math.Log(Ns) + Math.Log(Nx)) / 3) * (AG + VG + EMO)) / OI;

                //Truncate_Data();

                SqlCommand cmdUpdate = new SqlCommand("insert into MMM values(@Comment, @Name, @polarity,@score)", DBConnection.conn);
                cmdUpdate.Parameters.AddWithValue("@Comment", comment);
                cmdUpdate.Parameters.AddWithValue("@Name", name);
                cmdUpdate.Parameters.AddWithValue("@polarity", DBNull.Value);
                cmdUpdate.Parameters.AddWithValue("@score", LastScore);
                DBConnection.conn.Open();
                cmdUpdate.ExecuteNonQuery();
                DBConnection.conn.Close();

                SqlDataAdapter adp = new SqlDataAdapter("Select Top(1)* from MMM order by id desc", DBConnection.conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int Id = Convert.ToInt32(dt.Rows[0]["id"]);
                    if (LastScore < 0)
                    {
                        SqlCommand cmdUpdate1 = new SqlCommand("update MMM set score=@score,polarity='Objective' where id=@id", DBConnection.conn);
                        cmdUpdate1.Parameters.AddWithValue("@score", LastScore);
                        cmdUpdate1.Parameters.AddWithValue("@id", Id);
                        DBConnection.conn.Open();
                        cmdUpdate1.ExecuteNonQuery();
                        DBConnection.conn.Close();
                    }
                    else if (LastScore > 0)
                    {
                        SqlCommand cmdUpdate2 = new SqlCommand("update MMM set score=@score,polarity='Subjective' where id=@id", DBConnection.conn);
                        cmdUpdate2.Parameters.AddWithValue("@score", LastScore);
                        cmdUpdate2.Parameters.AddWithValue("@id", Id);
                        DBConnection.conn.Open();
                        cmdUpdate2.ExecuteNonQuery();
                        DBConnection.conn.Close();
                    }
                    else
                    {
                        SqlCommand cmdUpdate3 = new SqlCommand("update MMM set score=@score,polarity='Moderate' where id=@id", DBConnection.conn);
                        cmdUpdate3.Parameters.AddWithValue("@score", LastScore);
                        cmdUpdate3.Parameters.AddWithValue("@id", Id);
                        DBConnection.conn.Open();
                        cmdUpdate3.ExecuteNonQuery();
                        DBConnection.conn.Close();
                    }

                }

                list.Clear();
            }

            //
            SqlDataAdapter adpdata = new SqlDataAdapter(new SqlCommand("Select * from MMM", DBConnection.conn));
            DataTable dtp = new DataTable();
            adpdata.Fill(dtp);
            GridView1.DataSource = dtp;
            GridView1.DataBind();



        }
        protected void Truncate_Data()
        {
            SqlCommand cmd = new SqlCommand("Truncate table MMM", DBConnection.conn);
            DBConnection.conn.Open();
            cmd.ExecuteNonQuery();
            DBConnection.conn.Close();
        }
        protected void Truncate_Data1()
        {
            SqlCommand cmd = new SqlCommand("Truncate table Temp", DBConnection.conn);
            DBConnection.conn.Open();
            cmd.ExecuteNonQuery();
            DBConnection.conn.Close();
        }

    }
}