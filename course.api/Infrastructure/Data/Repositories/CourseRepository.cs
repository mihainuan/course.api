﻿using course.api.Business.Entities;
using course.api.Business.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course.api.Infrastructure.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseDbContext _context;

        public CourseRepository(CourseDbContext context)
        {
            _context = context;
        }

        public void Add(Course course)
        {
            _context.Courses.Add(course);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Course>ObterCursoPorUsuario(int UserId)
        {
            return _context.Courses.Include(i => i.User).Where(w => w.UserId == UserId).ToList();
        }
    }
}
