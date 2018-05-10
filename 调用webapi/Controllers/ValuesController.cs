using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using 调用webapi.Models;

namespace 调用webapi.Controllers
{
    /// <summary>
    /// 这个叫做属性路由
    /// </summary>
    [RoutePrefix("test")]
    public class ValuesController : ApiController
    {
        private DbData db = DbData.Current;

        public List<MoStudent> students = new List<MoStudent>()
        {
            new MoStudent{ Id =1 , Name ="小1", Sex = true, Birthday= Convert.ToDateTime("1991-05-31")},
             new MoStudent{ Id =2 , Name ="小2", Sex = false, Birthday= Convert.ToDateTime("1991-05-31")},
             new MoStudent{ Id =3 , Name ="小3", Sex = false, Birthday= Convert.ToDateTime("1991-05-31")},
             new MoStudent{ Id =4 , Name ="小4", Sex = true, Birthday= Convert.ToDateTime("1991-05-31")}

        };

        [HttpGet]  //强调 是get请求
        [Route("AllStudents")]  //属性路由
        public List<MoStudent> AllStudents()
        {
            return students;
        }


        [Route("GetAllStudents01_1")]
        public async Task<HttpResponseMessage> GetAllStudents01_1()
        {
            var result = await JsonConvert.SerializeObjectAsync(students);

            return new HttpResponseMessage
            {
                Content = new StringContent(result),
                StatusCode=HttpStatusCode.OK
            };
        }

        [Route("all01_2")]
        [AcceptVerbs("POST","GET")]
        public HttpResponseMessage GetAllStudents01_2()
        {
            var students = db.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK,students);
        }



        [Route("add")]
        [HttpPost]
        public HttpResponseMessage AddStudent(MoStudent moStudent)
        {
            var httpStatus = HttpStatusCode.OK;

            if(ModelState.IsValid)
            {
                var isfalse = db.Save(moStudent);
            }
            return Request.CreateResponse(httpStatus, moStudent);
        }









    }
}
