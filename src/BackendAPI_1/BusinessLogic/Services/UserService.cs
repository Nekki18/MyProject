using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<User>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _repositoryWrapper.User
                .FindByCondition(x => x.UserId == id);
            return user.First();
        }

        public async Task Create(User model)
        {
            await _repositoryWrapper.User.Create(model);
            _= _repositoryWrapper.Save();
        }

        public async Task Update(User model)
        {
            _ = _repositoryWrapper.User.Update(model);
            _ = _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User
                .FindByCondition(x => x.UserId == id);

            _ = _repositoryWrapper.User.Delete(user.First());
            _ = _repositoryWrapper.Save();
        }
    }
}