using GenericRepositoryUoW.Data;
using GenericRepositoryUoW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<RepositoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }


        protected override void Seed(RepositoryContext context)
        {
            if (context.Facultys.ToList().Count == 0)
            {
                Course d = new Course { Name = "Course 1", Code = "1" };
                Course d2 = new Course { Name = "Course 2", Code = "2" };

                Term dn = new Term { Name = "Term 1" };
                Term dn2 = new Term { Name = "Term 2" };

                Faculty f = new Faculty { Name = "Faculty 1" };
                Faculty f2 = new Faculty { Name = "Faculty 2" };

                Department b = new Department { Name = "Department 1", Faculty = f, Description = "Department 1 Department 1" };
                Department b2 = new Department { Name = "Department 2", Faculty = f2, Description = "Department 2 Department 2" };

                DepartmentCourse bd = new DepartmentCourse { Department = b, Course = d, Term = dn };
                DepartmentCourse bd2 = new DepartmentCourse { Department = b, Course = d2, Term = dn };
                DepartmentCourse bd3 = new DepartmentCourse { Department = b2, Course = d, Term = dn2 };

                context.DepartmentCourses.AddOrUpdate(bd);
                context.DepartmentCourses.AddOrUpdate(bd2);
                context.DepartmentCourses.AddOrUpdate(bd3);

                TestType t = new TestType { Name = "Test Type 1" };
                TestType t2 = new TestType { Name = "Test Type 2" };

                Year y = new Year { Name = "2018" };
                Year y2 = new Year { Name = "2019" };

                IList<Question> Question1 = new List<Question>();

                Question1.Add(new Question { CorrectChoice = "A", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs1-gkvkp.png" });
                Question1.Add(new Question { CorrectChoice = "A", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs2-pfmtp.png" });
                Question1.Add(new Question { CorrectChoice = "B", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs3-pjuix.png" });
                Question1.Add(new Question { CorrectChoice = "A", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs4-brroy.png" });
                Question1.Add(new Question { CorrectChoice = "C", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs5-idjys.png" });
                Question1.Add(new Question { CorrectChoice = "A", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs6-qmngo.png" });
                Question1.Add(new Question { CorrectChoice = "E", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs7-shcwt.png" });
                Question1.Add(new Question { CorrectChoice = "A", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs8-sqbrp.png" });

                Test sinav = new Test { Course = d, TestType = t, Year = y, lstQuestion = Question1 };
                context.Tests.AddOrUpdate(sinav);

                IList<Question> Question2 = new List<Question>();

                Question2.Add(new Question { CorrectChoice = "C", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs1-gkvkp.png" });
                Question2.Add(new Question { CorrectChoice = "D", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs2-pfmtp.png" });
                Question2.Add(new Question { CorrectChoice = "B", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs3-pjuix.png" });
                Question2.Add(new Question { CorrectChoice = "A", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs4-brroy.png" });
                Question2.Add(new Question { CorrectChoice = "E", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs5-idjys.png" });
                Question2.Add(new Question { CorrectChoice = "C", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs6-qmngo.png" });
                Question2.Add(new Question { CorrectChoice = "B", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs7-shcwt.png" });
                Question2.Add(new Question { CorrectChoice = "A", ImageURL = "https://hep.blob.core.windows.net/Question/aof/gkvkppfmtppjuixbrroy/zihin-felsefesi-2014-2015-Term-sonu-snavs8-sqbrp.png" });

                Test sinav2 = new Test { Course = d2, TestType = t2, Year = y2, lstQuestion = Question2 };
                context.Tests.AddOrUpdate(sinav2);

                base.Seed(context);
            }
        }
    }
}