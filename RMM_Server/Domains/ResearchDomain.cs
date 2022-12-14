using MySql.Data.MySqlClient;
using RMM_Server.Models;
using RMM_Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMM_Server.Domains
{
    public class ResearchDomain
    {
        public List<Research> GetResearchByFacultyId(string f_id)
        {
            DatabaseService ds = new DatabaseService();
            MySqlConnection conn = ds.Connect();
            string query = $"SELECT a.*, b.first_name, b.last_name " +
                $"FROM research AS a JOIN faculty as B ON a.faculty_id = b.faculty_id " +
                $"WHERE a.faculty_id = '{f_id}'";
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataReader reader = com.ExecuteReader();
            List<Research> research_list = new List<Research>();
            while (reader.Read())
            {
                Research r = new Research();
                r.Id = ConvertFromDBVal<int>(reader[0]);
                r.Faculty_Id = ConvertFromDBVal<string>(reader[1]);
                r.Name = ConvertFromDBVal<string>(reader[2]);
                r.Description = ConvertFromDBVal<string>(reader[3]);
                r.Location = ConvertFromDBVal<int>(reader[4]);
                r.Required_skills = ConvertFromDBVal<string>(reader[5]);
                r.Encouraged_Skills = ConvertFromDBVal<string>(reader[6]);
                r.Start_Date = ConvertFromDBVal<DateTime>(reader[7]).ToShortDateString();
                r.End_Date = ConvertFromDBVal<DateTime>(reader[8]).ToShortDateString();
                if (ConvertFromDBVal<sbyte>(reader[9]) == 1)
                {
                    r.Active = true;
                } 
                else
                {
                    r.Active = false;
                }
                r.Address = ConvertFromDBVal<string>(reader[10]);
                r.IsPaid = ConvertFromDBVal<int>(reader[11]);
                r.IsNonpaid = ConvertFromDBVal<int>(reader[12]);
                r.IsCredit = ConvertFromDBVal<int>(reader[13]);
                r.Faculty_FirstName = ConvertFromDBVal<string>(reader[14]);
                r.Faculty_LastName = ConvertFromDBVal<string>(reader[15]);

                research_list.Add(r);
            }
            reader.Close();

            return research_list;
        }

        public List<Research> GetAllResearch()
        {
            DatabaseService ds = new DatabaseService();
            MySqlConnection conn = ds.Connect();
            string query = $"SELECT a.*, b.first_name, b.last_name FROM research AS a " +
                $"JOIN faculty as B ON a.faculty_id = b.faculty_id;";
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataReader reader = com.ExecuteReader();
            List<Research> research_list = new List<Research>();
            while (reader.Read())
            {
                Research r = new Research();
                r.Id = ConvertFromDBVal<int>(reader[0]);
                r.Faculty_Id = ConvertFromDBVal<string>(reader[1]);
                r.Name = ConvertFromDBVal<string>(reader[2]);
                r.Description = ConvertFromDBVal<string>(reader[3]);
                r.Location = ConvertFromDBVal<int>(reader[4]);
                r.Required_skills = ConvertFromDBVal<string>(reader[5]);
                r.Encouraged_Skills = ConvertFromDBVal<string>(reader[6]);
                r.Start_Date = ConvertFromDBVal<DateTime>(reader[7]).ToShortDateString();
                r.End_Date = ConvertFromDBVal<DateTime>(reader[8]).ToShortDateString();
                if (ConvertFromDBVal<sbyte>(reader[9]) == 1)
                {
                    r.Active = true;
                }
                else
                {
                    r.Active = false;
                }
                r.Address = ConvertFromDBVal<string>(reader[10]);
                r.IsPaid = ConvertFromDBVal<int>(reader[11]);
                r.IsNonpaid = ConvertFromDBVal<int>(reader[12]);
                r.IsCredit = ConvertFromDBVal<int>(reader[13]);
                r.Faculty_FirstName = ConvertFromDBVal<string>(reader[14]);
                r.Faculty_LastName = ConvertFromDBVal<string>(reader[15]);

                research_list.Add(r);
            }
            reader.Close();

            return research_list;
        }

        public List<Research> GetAllResearchByStudentId(string s_id)
        {
            DatabaseService ds = new DatabaseService();
            MySqlConnection conn = ds.Connect();
            string query = $"SELECT a.*, c.first_name, c.last_name, b.progress_bar FROM research AS a " +
                $"JOIN participant AS b ON a.research_id = b.research_id " +
                $"JOIN faculty AS c ON a.faculty_id = c.faculty_id " +
                $"WHERE b.student_id = '{s_id}'";
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataReader reader = com.ExecuteReader();
            List<Research> research_list = new List<Research>();
            while (reader.Read())
            {
                Research r = new Research();
                r.Id = ConvertFromDBVal<int>(reader[0]);
                r.Faculty_Id = ConvertFromDBVal<string>(reader[1]);
                r.Name = ConvertFromDBVal<string>(reader[2]);
                r.Description = ConvertFromDBVal<string>(reader[3]);
                r.Location = ConvertFromDBVal<int>(reader[4]);
                r.Required_skills = ConvertFromDBVal<string>(reader[5]);
                r.Encouraged_Skills = ConvertFromDBVal<string>(reader[6]);
                r.Start_Date = ConvertFromDBVal<DateTime>(reader[7]).ToShortDateString();
                r.End_Date = ConvertFromDBVal<DateTime>(reader[8]).ToShortDateString();
                if (ConvertFromDBVal<sbyte>(reader[9]) == 1)
                {
                    r.Active = true;
                }
                else
                {
                    r.Active = false;
                }
                r.Address = ConvertFromDBVal<string>(reader[10]);
                r.IsPaid = ConvertFromDBVal<int>(reader[11]);
                r.IsNonpaid = ConvertFromDBVal<int>(reader[12]);
                r.IsCredit = ConvertFromDBVal<int>(reader[13]);
                r.Faculty_FirstName = ConvertFromDBVal<string>(reader[14]);
                r.Faculty_LastName = ConvertFromDBVal<string>(reader[15]);
                r.Progression = ConvertFromDBVal<int>(reader[16]);

                research_list.Add(r);
            }
            reader.Close();

            return research_list;
        }


        public void UpdateApplicantProgress(int p, int rID, string sID)
        {
            DatabaseService ds = new DatabaseService();
            MySqlConnection conn = ds.Connect();
            string query = $"UPDATE participant " +
                $"SET progress_bar = {p} " +
                $"WHERE research_id = {rID} AND student_id = '{sID}'";
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataReader reader = com.ExecuteReader();
            reader.Close();
        }

        public Progress GetAppProgression(int rID, string sID)
        {
            Progress p = new Progress();
            DatabaseService ds = new DatabaseService();
            MySqlConnection conn = ds.Connect();
            string query = $"SELECT * FROM participant " +
                $"WHERE research_id = {rID} AND student_id = '{sID}'";
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                p.research_id = ConvertFromDBVal<int>(reader[0]);
                p.student_id = ConvertFromDBVal<string>(reader[1]);
                p.progress = ConvertFromDBVal<int>(reader[2]);
            }
            reader.Close();

            return p;
        }

        public Research AddResearch(Research r)
        {
            int active = ConvertBoolToInt(r.Active);

            DatabaseService ds = new DatabaseService();
            MySqlConnection conn = ds.Connect();

            // add research to db
            string query = $"INSERT into research VALUES (" +
                $" null, '{r.Faculty_Id}', '{r.Name}', '{r.Description}', '{r.Location}', '{r.Required_skills}'," +
                $" '{r.Encouraged_Skills}', '{r.Start_Date}', '{r.End_Date}', '{active}', '{r.Address}', '{r.IsPaid}'," +
                $" '{r.IsNonpaid}', '{r.IsCredit}')";
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataReader reader = com.ExecuteReader();
            reader.Close();

            int count = GetCountOfResearchTable();

            // add associated depts to research
            foreach (string dept in r.ResearchDepts)
            {
                int d_id = 0;
                query = $"SELECT subdepartment_id from subdepartment WHERE name = '{dept}'";
                com = new MySqlCommand(query, conn);
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    d_id = ConvertFromDBVal<int>(reader[0]);
                }
                reader.Close();

                query = $"INSERT into researchdept VALUES ('{count}', '{d_id}')";
                com = new MySqlCommand(query, conn);
                reader = com.ExecuteReader();
                reader.Close();
            }

            return r;
        }

        public int GetCountOfResearchTable()
        {
            int count = 0; 
            DatabaseService ds = new DatabaseService();
            MySqlConnection conn = ds.Connect();
            string query = $"SELECT count(*) FROM research";
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                count = ConvertFromDBVal<int>(Convert.ToInt32(reader[0]));
            }
            reader.Close();

            return count;
        }

        public void DeleteResearchByID(int id)
        {
            DatabaseService ds = new DatabaseService();
            MySqlConnection conn = ds.Connect();
            string query = $"DELETE from research WHERE research_id = '{id}'";
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataReader reader = com.ExecuteReader();
            reader.Close();
        }

        public static T ConvertFromDBVal<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(T); // returns the default value for the type
            }
            else
            {
                return (T)obj;
            }
        }

        public int ConvertBoolToInt(bool b)
        {
            if (b == true) return 1;
            else return 0;
        }
    }
}
