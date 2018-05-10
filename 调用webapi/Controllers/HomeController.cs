using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using 调用webapi.Models;

namespace 调用webapi.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {

        /// <summary>
        /// 1.方法1 在控制器中 访问 webapi
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("test01")]
        public async Task<ActionResult>  Index()
        {
            var searchData = new MoStudent();
            //查询条件

            var webapiURL = "http://localhost:59641/test/all01_2";

            var httpResponseMsg = new HttpResponseMessage();

            using(var httpClient=new HttpClient())
            {
                httpResponseMsg = await httpClient.GetAsync(webapiURL);
            }
            var students = httpResponseMsg.Content.ReadAsAsync<List<MoStudent>>().Result;

            return View(students);
        }

        /// <summary>
        /// 2.方法2 在视图中 用ajax调用webapi
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("test02")]
        public ActionResult Index222()
        {
            return View();
        }




        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(MoStudent model)
        {
            if(ModelState.IsValid)
            {
                var webapiUrl = "http://localhost:59641/test/add";

                var httpResponseMsg = new HttpResponseMessage();

                using (var httpClient =new HttpClient())
                {
                    httpResponseMsg = await httpClient.PostAsync<MoStudent>(webapiUrl,model,new System.Net.Http.Formatting.JsonMediaTypeFormatter());
                }
                model = httpResponseMsg.Content.ReadAsAsync<MoStudent>().Result;
            }
            ModelState.AddModelError("",model.Id>0?"添加成功":"添加失败");
            return View(model);
        }
      
    }
}
