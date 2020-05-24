using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using webapi2.Daos.Member;
using webapi2.Filters;
using webapi2.Filters.Actions;
using webapi2.Models;

namespace webapi2.Controllers
{
    [EnableCors(origins: "http://domain_of_the_site_that_requests_this_web_api", headers: "*", methods: "*")]
    [RoutePrefix("api/member")]
    public class MemberController : ApiController
    {
        private static readonly MemberDao memberDao = new MemberDao();
        [HttpGet]
        [Route("")]
        public IHttpActionResult FindMembers()
        {
            List<member> members = memberDao.FindAll();
            if (members.Count > 0)
                return Ok(members);

            //return Content(HttpStatusCode.NotFound, "Members not found");
            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Members not found"));
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult FindMember(int? id)
        {
            member member = memberDao.FindOne(id);
            if (member is null)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Member id {id} not found"));

            return Ok(member);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult SaveMember(member m)
        {
            if (!ModelState.IsValid)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));

            member member = memberDao.Save(m);
            if (m is null)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Saving member failed"));

            return Ok(member);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateMember(int? id, member m)
        {
            if (!ModelState.IsValid)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));

            member member = memberDao.Update(id, m);
            if (member is null)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Updating member id {id} failed"));

            return Ok(member);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeletingMember(int? id)
        {
            bool flag = memberDao.Delete(id);
            if (flag) return Ok($"Member id {id} deleted");

            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Deleting member id {id} failed"));
        }

        // exception test at action scope
        [ExceptionHandler]
        [HttpGet]
        [Route("exception")]
        public IHttpActionResult ExceptionTest()
        {
            throw new Exception("ExceptionTest action throws an exception");
        }

        // exception test at global scope
        [HttpGet]
        [Route("globalexception")]
        public IHttpActionResult GlobalExceptionTest()
        {
            throw new Exception("GlobalExceptionTest throws an exception");
        }

        // ActionInfo filter test at action scope
        [ActionInfo]
        [HttpGet]
        [Route("actionfilter")]
        public IHttpActionResult ActionFilterTest()
        {
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, "ActionInfo filter test"));
        }

    }
}
