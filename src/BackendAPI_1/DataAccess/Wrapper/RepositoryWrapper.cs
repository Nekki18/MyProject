using Domain.Interfaces;
using Domain.Models;
using DataAccess.Repositories;

namespace Domain.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private BookLoversContext _repoContext;

        private IUserRepository _user;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public RepositoryWrapper(BookLoversContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
