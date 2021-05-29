using ApplicationCore;
using DomainModels.Entities;
using Repository.Abstraction;
using Repository.Implementation;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        DatabaseContext db;

        public UnitOfWork()
        {
            db = new DatabaseContext();
        }


        private IAuthenticateRepository _AuthenticateRepository;

        public IAuthenticateRepository AuthenticateRepository
        {

            get
            {
                if (_AuthenticateRepository == null)
                {
                    _AuthenticateRepository = new AuthenticateRepository(db);

                }

                return _AuthenticateRepository;
            }

        }


        private IRepository<User> _UserRepository;

        public IRepository<User> UserRepository
        {

            get
            {
                if (_UserRepository == null)
                {
                    _UserRepository = new Repository<User>(db);

                }

                return _UserRepository;
            }

        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
