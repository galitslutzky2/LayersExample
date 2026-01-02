using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    //   abstact = מחלקה שאי אפשר ליצור מופע שלה - המחלקות שירשו אותה ישתמש בפעולות שלה  
    public abstract class BaseDal  
    {
        protected string ConnectionString;
        protected SqlConnection conn;

        //-  - פעולה שמחייבת את המחלקות היורשות לממש
        // must be public to be accessible from outside
        public abstract BaseEntity CreateModel(DataRow row);
        protected BaseDal()
        {
            // נתיב מוחלט -לא מומלץ
            // ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\MyProject\\LayersExample2\\DAL\\Database1.mdf;Integrated Security=True";

            // נתיב יחסי לפרויקט  
            //  Database1.mdf שבו נמצא
            string DBfileName = "Database1.mdf";
            string projectDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\DAL\"));
            ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
                projectDir + DBfileName + ";Integrated Security=True";

            // יצירת האובייקט שמייצג את החיבור לדטה בייס
            conn = new SqlConnection(ConnectionString);
        }

        protected int ExecuteInsertQuery(string sql)
        {
            return ExecuteQuery(sql);
        }
        protected int ExecuteUpdateQuery(string sql)
        {
            return ExecuteQuery(sql);
        }
        protected int ExecuteDeleteQuery(string sql)
        {
            return ExecuteQuery(sql);
        }

        /// <summary>
        /// מפעיל שאילתא שמחזירה טבלה
        /// למשל
        /// select * from Students where Gender='male'
        protected DataTable ExecuteSelectAllQuery(string sql)
        {
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception ex)
            {
                HandleError(ex, sql);
                throw; // חשוב! לא לבלוע שגיאה
            }
            finally
            {
                conn.Close();
            }

            return table;
        }

        /// <summary>
        /// מפעיל שאילתה שמחזירה מחרוזת
        /// </summary>
        /// <param name="sql">The sql qurey to execute</param>        
        /// <returns>the scalar execution converted to string</returns>
        protected string ExecuteSelectStringQuery(string sql)
        {
            object obj = ExecuteSelectOneData(sql);
            return Convert.ToString(obj);
        }

        /// <summary>
        /// מפעיל שאילתה שמחזירה ערך בוליאני
        /// </summary>
        /// <param name="sql">The sql qurey to execute</param>        
        /// <returns>the scalar execution converted to boolean</returns>
        protected bool ExecuteSelectBoolQuery(string sql)
        {
            object obj = ExecuteSelectOneData(sql);
            return Convert.ToBoolean(obj);
        }

        /// <summary>
        /// מפעיל שאילתה שמחזירה ערך שלם
        /// </summary>
        /// <param name="sql">The sql qurey to execute</param>        
        /// <returns>the scalar execution converted to int</returns>
        protected int ExecuteSelectIntQuery(string sql)
        {
            object obj = ExecuteSelectOneData(sql);
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// מפעיל שאילתה שמחזירה ערך יחיד
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected object ExecuteSelectOneData(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                HandleError(ex, sql);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// מפעיל שאילתא שלא מחזירה ערך (INSERT, UPDATE, DELETE)
        private int ExecuteQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                HandleError(ex, sql);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        protected virtual void HandleError(Exception ex, string sql)
        {
            // כאן אפשר:
            // לכתוב לקובץ
            // לשמור ל-DB
            // לשלוח לוג

            Console.WriteLine("SQL Error:");
            Console.WriteLine(sql);
            Console.WriteLine(ex.Message);
        }
    }
}



