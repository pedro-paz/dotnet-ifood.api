using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace deep.wefood.api.Services
{
    public class ServiceUser : IServiceUser
    {
        private IRepository<User> _userRepository;
        private IRepository<Company> _companyRepository;

        public ServiceUser(IRepository<User> userRepository, IRepository<Company> companyRepository)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
        }

        public User Authenticate(string email, string senha)
        {
            var user = _userRepository.Query(x =>
              x.Email.Trim().ToLower() == email?.Trim().ToLower() &&
              x.Password.Trim().ToLower() == senha?.Trim().ToLower()
            ).FirstOrDefault();

            if (user == null)
                throw new System.Exception("User not found");

            return user;
        }

        public User FindByGuid(string guid)
        {
            return _userRepository.Query(x =>
              x.Guid.ToLower() == guid.ToLower()
            ).FirstOrDefault();
        }

        public void Update(User newUser)
        {
            var oldUser = _userRepository.Query(user => user.Guid == newUser.Guid).FirstOrDefault();

            if (oldUser == null)
                throw new System.Exception("User not found");

            oldUser.Email = newUser.Email;
            oldUser.Name = newUser.Name;

            _userRepository.Update(oldUser);
            _userRepository.SaveChanges();
        }

        public void Delete(string guid)
        {
            var user = _userRepository.Query(user => user.Guid == guid).FirstOrDefault();

            if (user == null)
                throw new System.Exception("User not found");

            _userRepository.Delete(user);
            _userRepository.SaveChanges();
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
            _userRepository.SaveChanges();
        }
    }
}
