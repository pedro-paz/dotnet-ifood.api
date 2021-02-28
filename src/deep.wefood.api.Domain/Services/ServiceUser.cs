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

        public User Auth(string email, string senha)
        {
            var user = _userRepository.Query(x =>
              x.Email.Trim().ToLower() == email?.Trim().ToLower() &&
              x.Senha.Trim().ToLower() == senha?.Trim().ToLower()
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

        public IEnumerable<User> FindByCompany(string companyGuid)
        {
            var company = _companyRepository.Query(company => company.Guid == companyGuid).FirstOrDefault();
#if DEBUG
#endif
            if (company == null)
                throw new System.Exception("Company not found");

            return company.Usuarios;
        }

        public void Update(User newUser)
        {
            var oldUser = _userRepository.Query(user => user.Guid == newUser.Guid).FirstOrDefault();

            if (oldUser == null)
                throw new System.Exception("User not found");

            oldUser.Email = newUser.Email;
            oldUser.Nome = newUser.Nome;

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
            var company = _companyRepository.Query(x => x.Guid == user.Empresa?.Guid).FirstOrDefault();

            if (company == null)
                throw new System.Exception("Company not found");

            company.Usuarios.Add(user);
            _companyRepository.SaveChanges();
        }
    }
}
