using GenericRepositoryUoW.Data;
using GenericRepositoryUoW.Data.Models;
using GenericRepositoryUoW.Data.UoW;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Data.Migrations
{
    /// <summary>
    /// DB Configuration class. EF settings set in its constructor
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<RepositoryContext>
    {
        /// <summary>
        /// EF settings except default values need to be set here
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        /// <summary>
        /// Seed function will run every time our model changes
        /// </summary>
        /// <param name="context">Seed function needs generic context to reac</param>
        protected override void Seed(RepositoryContext context)
        {
            //To create data which is needed for test purposes we use seed function.
            //DB may already have seed data so we first control if exists any data.

            #region MockData
            if (context.Facultys.ToList().Count == 0)
                {
                    Course d = new Course { Name = "Course 1", Code = "1" };
                    Course d2 = new Course { Name = "Course 2", Code = "2" };
                    Course d3 = new Course { Name = "Course 3", Code = "3" };
                    Course d4 = new Course { Name = "Course 4", Code = "4" };
                    Course d5 = new Course { Name = "Course 5", Code = "5" };
                    Term dn = new Term { Name = "Term 1" };
                    Term dn2 = new Term { Name = "Term 2" };
                    Term dn3 = new Term { Name = "Term 3" };
                    Term dn4 = new Term { Name = "Term 4" };
                    Faculty f = new Faculty { Name = "Faculty 1" };
                    Faculty f2 = new Faculty { Name = "Faculty 2" };
                    Faculty f3 = new Faculty { Name = "Faculty 3" };
                    Faculty f4 = new Faculty { Name = "Faculty 4" };
                    Faculty f5 = new Faculty { Name = "Faculty 5" };
                    Department b = new Department { Name = "Department 1", Faculty = f, Description = "Department 1 Description" };
                    Department b2 = new Department { Name = "Department 2", Faculty = f5, Description = "Department 2 Description" };
                    Department b3 = new Department { Name = "Department 3", Faculty = f5, Description = "Department 3 Description" };
                    Department b4 = new Department { Name = "Department 4", Faculty = f4, Description = "Department 4 Description" };
                    Department b5 = new Department { Name = "Department 5", Faculty = f2, Description = "Department 5 Description" };
                    Department b6 = new Department { Name = "Department 6", Faculty = f3, Description = "Department 6 Description" };
                    DepartmentCourse bd = new DepartmentCourse { Department = b, Course = d, Term = dn };
                    DepartmentCourse bd2 = new DepartmentCourse { Department = b, Course = d2, Term = dn };
                    DepartmentCourse bd3 = new DepartmentCourse { Department = b, Course = d3, Term = dn2 };
                    DepartmentCourse bd4 = new DepartmentCourse { Department = b, Course = d4, Term = dn3 };
                    DepartmentCourse bd5 = new DepartmentCourse { Department = b2, Course = d, Term = dn2 };
                    DepartmentCourse bd6 = new DepartmentCourse { Department = b3, Course = d3, Term = dn };
                    DepartmentCourse bd7 = new DepartmentCourse { Department = b4, Course = d5, Term = dn };
                    DepartmentCourse bd8 = new DepartmentCourse { Department = b5, Course = d, Term = dn2 };
                    DepartmentCourse bd9 = new DepartmentCourse { Department = b6, Course = d, Term = dn4 };
                    DepartmentCourse bd10 = new DepartmentCourse { Department = b3, Course = d4, Term = dn2 };
                    DepartmentCourse bd11 = new DepartmentCourse { Department = b4, Course = d4, Term = dn2 };
                    context.DepartmentCourses.AddOrUpdate(bd);
                    context.DepartmentCourses.AddOrUpdate(bd2);
                    context.DepartmentCourses.AddOrUpdate(bd3);
                    context.DepartmentCourses.AddOrUpdate(bd4);
                    context.DepartmentCourses.AddOrUpdate(bd5);
                    context.DepartmentCourses.AddOrUpdate(bd6);
                    context.DepartmentCourses.AddOrUpdate(bd7);
                    context.DepartmentCourses.AddOrUpdate(bd8);
                    context.DepartmentCourses.AddOrUpdate(bd9);
                    context.DepartmentCourses.AddOrUpdate(bd10);
                    context.DepartmentCourses.AddOrUpdate(bd11);
                    TestType t = new TestType { Name = "Test Type 1" };
                    TestType t2 = new TestType { Name = "Test Type 2" };
                    TestType t3 = new TestType { Name = "Test Type 3" };
                    Year y = new Year { Name = "2015" };
                    Year y1 = new Year { Name = "2016" };
                    Year y2 = new Year { Name = "2017" };
                    Year y3 = new Year { Name = "2018" };
                    Year y4 = new Year { Name = "2019" };
                    IList<Question> Question1 = new List<Question>();
                    Question1.Add(new Question { CorrectChoice = "A", ImageURL = "http://lorempixel.com/640/360/" });
                    Question1.Add(new Question { CorrectChoice = "A", ImageURL = "http://lorempixel.com/640/360/" });
                    Question1.Add(new Question { CorrectChoice = "B", ImageURL = "http://lorempixel.com/640/360/" });
                    Question1.Add(new Question { CorrectChoice = "A", ImageURL = "http://lorempixel.com/640/360/" });
                    Question1.Add(new Question { CorrectChoice = "C", ImageURL = "http://lorempixel.com/640/360/" });
                    Question1.Add(new Question { CorrectChoice = "A", ImageURL = "http://lorempixel.com/640/360/" });
                    Question1.Add(new Question { CorrectChoice = "E", ImageURL = "http://lorempixel.com/640/360/" });
                    Question1.Add(new Question { CorrectChoice = "A", ImageURL = "http://lorempixel.com/640/360/" });
                    IList<Question> Question2 = new List<Question>();
                    Question2.Add(new Question { CorrectChoice = "C", ImageURL = "http://lorempixel.com/640/360/" });
                    Question2.Add(new Question { CorrectChoice = "D", ImageURL = "http://lorempixel.com/640/360/" });
                    Question2.Add(new Question { CorrectChoice = "B", ImageURL = "http://lorempixel.com/640/360/" });
                    Question2.Add(new Question { CorrectChoice = "A", ImageURL = "http://lorempixel.com/640/360/" });
                    Question2.Add(new Question { CorrectChoice = "E", ImageURL = "http://lorempixel.com/640/360/" });
                    Question2.Add(new Question { CorrectChoice = "C", ImageURL = "http://lorempixel.com/640/360/" });
                    Question2.Add(new Question { CorrectChoice = "B", ImageURL = "http://lorempixel.com/640/360/" });
                    Question2.Add(new Question { CorrectChoice = "A", ImageURL = "http://lorempixel.com/640/360/" });
                    Test test = new Test { Course = d, TestType = t, Year = y, lstQuestion = Question1.ToList() };
                    context.Tests.AddOrUpdate(test);
                    Test test2 = new Test { Course = d2, TestType = t2, Year = y2, lstQuestion = Question2.ToList() };
                    context.Tests.AddOrUpdate(test2);
                    Test test3 = new Test { Course = d3, TestType = t, Year = y, lstQuestion = Question1.ToList() };
                    context.Tests.AddOrUpdate(test3);
                    Test test4 = new Test { Course = d4, TestType = t, Year = y, lstQuestion = Question2.ToList() };
                    context.Tests.AddOrUpdate(test4);
                    Test test5 = new Test { Course = d5, TestType = t2, Year = y, lstQuestion = Question1.ToList() };
                    context.Tests.AddOrUpdate(test5);
                    Test test6 = new Test { Course = d5, TestType = t3, Year = y, lstQuestion = Question2.ToList() };
                    context.Tests.AddOrUpdate(test6);
                    base.Seed(context);
                }
            #endregion

        }
    }
}