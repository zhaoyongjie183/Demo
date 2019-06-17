using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProtobufWebapi.Model;

namespace ProtobufWebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private IEnumerable<Student> Students;

        public ValuesController()

        {

            Students = new Student[] {

                new Student() { ID=1,StuName="book",StuAge="1"},

                new Student() { ID=2,StuName="asp.net core",StuAge="10"},

            };

        }
        [HttpGet]

        [Produces("application/proto")]

        public IEnumerable<Student> Get()

        {

            return Students;

        }

        [HttpPost]

        [Produces("application/proto")]

        public Student Regist(Student model)

        {

            return Students.FirstOrDefault(r => r.ID == model.ID);

        }
    }
}
