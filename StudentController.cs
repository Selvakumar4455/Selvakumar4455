using Microsoft.AspNetCore.Mvc;
using TestWeb.DataAccess;
using TestWeb.Models;

namespace TestWeb.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            StudentDA studentDA = new StudentDA();
            List<Student> students = studentDA.GetStudents();

            return View(students);
        }

        public IActionResult Create()
        {
            Student student = new Student();
            return View(student);
        }

        public IActionResult Create(Student student)
        {
            StudentDA studentDA = new StudentDA();
            var response = studentDA.CreateStudent(student);

            return Redirect("Index");
        }

        public IActionResult Edit(int ID)
        {
            StudentDA studentDA = new StudentDA();
            Student student = studentDA.GetStudent(ID);

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            StudentDA studentDA = new StudentDA();
            var response = studentDA.UpdateStudent(student);

            return Redirect("../Index");
        }

        public IActionResult Details(int ID)
        {
            StudentDA studentDA = new StudentDA();
            Student student = studentDA.GetStudent(ID);

            return View(student);
        }

        public IActionResult Delete(int ID)
        {
            StudentDA studentDA = new StudentDA();
            bool response = studentDA.DeleteStudent(ID);

            return Redirect("../Index");
        }

    }
}
