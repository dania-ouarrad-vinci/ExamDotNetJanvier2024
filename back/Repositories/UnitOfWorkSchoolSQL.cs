using back.Entities;

namespace back.Repositories
{
    public class UnitOfWorkSchoolSQL : IUnitOfWorkSchool
    {
        private readonly SchoolContext _context;

        private BaseRepositorySQL<Student> _studentssRepository;



        public UnitOfWorkSchoolSQL(SchoolContext context)
        {

            this._context = context;
            this._studentssRepository = new BaseRepositorySQL<Student>(context);
        }

        public IRepository<Student> StudentsRepository
        {
            get { return this._studentssRepository; }
        }

       
    }
}