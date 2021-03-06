﻿using MyWebApi.DataAccess;
using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyWebApi.Controllers
{
    public class StudentApiController : ApiController
    {
        public StudentApiController()
        {
        }

        public IHttpActionResult GetStudentById(int id)
        {
            StudentViewModel student = null;
            using (var context = new SchoolEntities())
            {
                student = context.Students
                    .Include("StudentAddress")
                    .Where(p => p.StudentId == id)
                    .Select(s => new StudentViewModel()
                    {
                        Id = s.StudentId,
                        FirstName = s.FirstName,
                        LastName = s.LastName
                    }).FirstOrDefault<StudentViewModel>();
            }

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        public IHttpActionResult GetAllStudents(bool includeAddress = false)
        {
            IList<StudentViewModel> students = null;
            using (var context = new SchoolEntities())
            {
                students = context.Students.Include("StudentAddress").Select(s => new StudentViewModel()
                {
                    Id = s.StudentId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                }).ToList<StudentViewModel>();

                if (students.Count == 0)
                {
                    return NotFound();
                }

                return Ok(students);
            }
        }

        //public IHttpActionResult GetAllStudentsInSameStandard(int standardId)
        //{
        //    IList<StudentViewModel> students = null;
        //    using (var context = new SchoolEntities())
        //    {
        //        students = context.Students.Include("StudentAddress").Include("Standard").Where(s => s.StandardId == standardId)
        //            .Select(p => new StudentViewModel()
        //            {
        //                Id = p.StudentId,
        //                FirstName = p.FirstName,
        //                LastName = p.LastName,
        //                Standard = new StandardViewModel()
        //                {
        //                    Name = p.Standard.StandardName,
        //                },
        //                Address = new AddressViewModel()
        //                {
        //                    StudentId = p.StudentAddress.StudentId,
        //                    Address1 = p.StudentAddress.Address1,
        //                    Address2 = p.StudentAddress.Address2,
        //                    City = p.StudentAddress.City,
        //                    State = p.StudentAddress.State
        //                }
        //            }).ToList<StudentViewModel>();
        //    }

        //    if(students.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(students);
        //}

        public IHttpActionResult PostNewStudent(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            using (var context = new SchoolEntities())
            {
                context.Students.Add(new Student()
                {
                    StudentId = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName
                });
                context.SaveChanges();
            }

            return Ok();
        }

        public IHttpActionResult Put(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            using (var context = new SchoolEntities())
            {
                var existingStudent = context.Students.Where(s => s.StudentId == student.Id).FirstOrDefault();
                if (existingStudent != null)
                {
                    existingStudent.FirstName = student.FirstName;
                    existingStudent.LastName = student.LastName;
                    context.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            using (var context = new SchoolEntities())
            {
                var existingStudent = context.Students.Where(s => s.StudentId == id).FirstOrDefault();
                context.Entry(existingStudent).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            return Ok();
        }
    }
}