using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MVCDemoApp.Models
{
    public class TestDataAccessLayer
    {
        string connectionString = "Data Source=USER\SQLEXPRESS;Initial Catalog=sobi;Integrated Security=True";

        //To View all details    

        public IEnumerable<Test> GetAll()

        {

            List<Test> lst = new List<Test>();

            using (SqlConnection con = new SqlConnection(connectionString))

            {

                SqlCommand cmd = new SqlCommand("stpGetAll", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())

                {

                    Test test = new Test();

                    test.AccountId = Convert.ToInt32(rdr["AccountId"]);

                    test.UserName = rdr["UserName"].ToString();

                    test.EmailId = rdr["EmailId"].ToString();

                    test.CompanyName = rdr["CompanyName"].ToString();

                    lst.Add(test);

                }

                con.Close();

            }

            return lst;

        }


        //To Add new record    

        public void AddTest(Test addtest)

        {

            using (SqlConnection con = new SqlConnection(connectionString))

            {

                SqlCommand cmd = new SqlCommand("stpInsert", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", addtest.UserName);

                cmd.Parameters.AddWithValue("@EmailId", addtest.EmailId);

                cmd.Parameters.AddWithValue("@CompanyName", addtest.CompanyName);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

            }

        }

        //To Update the records  

        public void UpdateTest(Test updtest)

        {

            using (SqlConnection con = new SqlConnection(connectionString))

            {

                SqlCommand cmd = new SqlCommand("stpUpdate", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AccountId", updtest.AccountId);

                cmd.Parameters.AddWithValue("@UserName", updtest.UserName);

                cmd.Parameters.AddWithValue("@EmailId", updtest.EmailId);

                cmd.Parameters.AddWithValue("@CompanyName", updtest.CompanyName);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

            }

        }


        //Get the details   

        public Test GetData(int? id)

        {

            Test test = new Test();

            using (SqlConnection con = new SqlConnection(connectionString))

            {

                string sqlQuery = "SELECT * FROM testLogin WHERE AccountId= " + id;

                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())

                {

                    test.AccountId = Convert.ToInt32(rdr["AccountId"]);

                    test.UserName = rdr["UserName"].ToString();

                    test.EmailId = rdr["EmailId"].ToString();

                    test.CompanyName = rdr["CompanyName"].ToString();

                }

            }

            return test;

        }

        //To Delete the record  

        public void DeleteTest(int? id)

        {

            using (SqlConnection con = new SqlConnection(connectionString))

            {

                SqlCommand cmd = new SqlCommand("stpDelete", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AccountId", id);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

            }

        }



    }
}
