using NUnit.Framework;
using RMM_Server.Domains;
using RMM_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMM_Server.Tests
{
    public class ResearchDomainTest
    {
        private ResearchDomain rd;

        [SetUp]
        public void SetUp()
        {
            rd = new ResearchDomain();
        }

        [Test]
        public void TestUpdateAppProgress()
        {
            Progress p = new Progress() { 
                progress = 2,
                research_id = 999999,
                student_id = "testid123"
            };

            rd.UpdateApplicantProgress(p.progress, p.research_id, p.student_id);
            var result = rd.GetAppProgression(p.research_id, p.student_id);
            Assert.AreEqual(result.progress, p.progress);

            p.progress = 3;
            rd.UpdateApplicantProgress(p.progress, p.research_id, p.student_id);
            result = rd.GetAppProgression(p.research_id, p.student_id);
            Assert.AreEqual(result.progress, p.progress);
        }

        [Test]
        public void TestCreateResearchCreatesResearch()
        {
            //arrange
            string[] s = { "Computer", "English" };
            Research r = new Research()
            {
                Id = 999998,
                Faculty_Id = "dxi1017",
                Name = "research",
                Description = "description",
                Location = 1,
                Required_skills = "required",
                Encouraged_Skills = "encouraged",
                Start_Date = "2022-11-19",
                End_Date = "2023-11-19",
                Active = true,
                Address = "123 fake st",
                IsPaid = 1,
                IsNonpaid = 0,
                IsCredit = 1,
                ResearchDepts = s
            };

            //act
            var result = rd.AddResearch(r);

            //assert
            Assert.NotNull(result);
            rd.DeleteResearchByID(999998);
        }
    }
}
