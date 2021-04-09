using course.api.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course.api.Business.Repositories
{
    public interface ICourseRepository
    {
        void Add(Course course);
        void Commit();
        IList<Course> ObterCursoPorUsuario(int UserId);
    }
}
