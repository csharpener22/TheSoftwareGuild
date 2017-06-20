﻿using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);
            }
            else
            {
                var viewModel = new StudentVM();
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
            }

            return RedirectToAction("List");
        }



        [HttpGet]
        public ActionResult EditStudent(int studentId)
        {
            var student = StudentRepository.Get(studentId);
            var model = new StudentVM();

            model.Student.StudentId = student.StudentId;
            model.Student.FirstName = student.FirstName;
            model.Student.LastName = student.LastName;
            model.Student.Major = student.Major;
            model.Student.GPA = student.GPA;
            model.Student.Address = student.Address;

            return View(model);
        }
        [HttpPost]
        [ActionName("EditStudent")]
        public ActionResult EditStudent(StudentVM student)
        {
            
            
                StudentRepository.Edit(student.Student);
            
            
            return RedirectToAction("EditStudent");
        }

        [HttpGet]

        public ActionResult DeleteStudent(int studentId)
        {
            var model = StudentRepository.Get(studentId);

            return View(model);
        }


        [HttpPost]
        [ActionName("DeleteStudent")]
        public ActionResult DeleteStudent2(int studentId)
        {
            StudentRepository.Delete(studentId);
            return RedirectToAction("List");
        }
    }
}