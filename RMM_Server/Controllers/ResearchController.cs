using Microsoft.AspNetCore.Mvc;
using RMM_Server.Domains;
using RMM_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RMM_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchController : ControllerBase
    {
        [HttpGet("getResearchByFaculty/{faculty_id}")]
        public List<Research> GetResearchByFaculty(string faculty_id)
        {
            ResearchDomain rd = new ResearchDomain();
            List<Research> result = rd.GetResearchByFacultyId(faculty_id);
            return result;
        }

        [HttpGet("getAllResearch")]
        public List<Research> GetAllResearch()
        {
            ResearchDomain rd = new ResearchDomain();
            List<Research> result = rd.GetAllResearch();
            return result;
        }

        [HttpGet("getAllResearchByStudent/{student_id}")]
        public List<Research> GetAllResearchByStudentId(string student_id)
        {
            ResearchDomain rd = new ResearchDomain();
            List<Research> result = rd.GetAllResearchByStudentId(student_id);
            return result;
        }

        [HttpPost("createResearch")]
        public Research CreateResearch(Research r)
        {
            ResearchDomain rd = new ResearchDomain();
            rd.AddResearch(r);
            return r;
        }

        // PUT api/<ResearchController>/5
        [HttpPut("updateAppProgress")]
        public void Put(Progress p)
        {
            ResearchDomain r = new ResearchDomain();
            r.UpdateApplicantProgress(p.progress, p.research_id, p.student_id);
        }


        // DELETE api/<ResearchController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
