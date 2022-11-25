using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Xml.Linq;
using TestWeb.Common;
using TestWeb.Models;

namespace TestWeb.DataAccess
{
    public class StudentDA
    {
        private SqlDbType ID;

        public List<Student> GetStudents()
        {
            DataLayer dataLayer = new DataLayer();
            string spName = "Usp_Student_Select";
            DataTable dt = dataLayer.GetDataFromSP(spName);

            List<Student> students = new List<Student>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Student student = new Student();
                    student.ID = Convert.ToInt32(dr["ID"]);
                    student.FirstName = dr["FirstName"].ToString();
                    student.MiddleName = dr["MiddleName"].ToString();
                    student.LastName = dr["LastName"].ToString();
                    student.Gender = Convert.ToChar(dr["Gender"]);
                    student.Address = dr["Address"].ToString();
                    student.DOB = Convert.ToDateTime(dr["DOB"]);

                    students.Add(student);
                }
            }

            return students;
        }

        public bool CreateStudent(Student student)
        {
            DataLayer dataLayer = new DataLayer();
            string spName = "USP_Student_Insert";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ID", student.ID));
            sqlParameters.Add(new SqlParameter("@FirstName", student.FirstName));
            sqlParameters.Add(new SqlParameter("@MiddleName", student.MiddleName));
            sqlParameters.Add(new SqlParameter("@LastName", student.LastName));
            sqlParameters.Add(new SqlParameter("@Gender", student.Gender));
            sqlParameters.Add(new SqlParameter("@Address", student.Address));
            sqlParameters.Add(new SqlParameter("@DOB", student.DOB));
            DataTable dt = dataLayer.UpdateFromSP(spName, sqlParameters);
            Student students = new Student();

            return true;
 
        }

        public Student GetStudent(int id)
        {
            DataLayer dataLayer = new DataLayer();
            string spName = "Usp_GetStudentById_Select";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("ID", id));
            DataTable dt = dataLayer.GetDataFromSP(spName, sqlParameters);

            Student student = new Student();

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                student.ID = Convert.ToInt32(dr["ID"]);
                student.FirstName = dr["FirstName"].ToString();
                student.MiddleName = dr["MiddleName"].ToString();
                student.LastName = dr["LastName"].ToString();
                student.Gender = Convert.ToChar(dr["Gender"]);
                student.Address = dr["Address"].ToString();
                student.DOB = Convert.ToDateTime(dr["DOB"]);
            }

            return student;
        }

        public bool UpdateStudent(Student student)
        {
            DataLayer dataLayer = new DataLayer();
            string spName = "USP_Student_Update";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ID",student.ID));
            sqlParameters.Add(new SqlParameter("@FirstName", student.FirstName));
            sqlParameters.Add(new SqlParameter("@MiddleName", student.MiddleName));
            sqlParameters.Add(new SqlParameter("@LastName", student.LastName));
            sqlParameters.Add(new SqlParameter("@Gender", student.Gender));
            sqlParameters.Add(new SqlParameter("@Address", student.Address));
            sqlParameters.Add(new SqlParameter("@DOB", student.DOB));
            DataTable dt = dataLayer.UpdateFromSP(spName, sqlParameters);
            Student students = new Student();

            return true;

   
        }
        
        public bool DeleteStudent(int id)
        {
            DataLayer dataLayer = new DataLayer();
            string spName = "USP_Student_Delect";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ID", id));
            DataTable dt = dataLayer.UpdateFromSP(spName, sqlParameters);
            return true;
        }
    }
}
