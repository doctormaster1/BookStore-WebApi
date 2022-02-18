using System;
using System.Linq;
using AutoMapper;
using WebApi.Entities;
using WebApi.DBOperations;

namespace WebApi.Application.UserOperations.CreateUser{
    public class CreateUserCommand
    {
        public CreateUserModel Modal { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateUserCommand(IBookStoreDbContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){
            var user = _dbContext.Users.SingleOrDefault(x=> x.Email == Modal.Email);
            if(user is not null) throw new InvalidOperationException("Kullanıcı Mevcut");

            user = _mapper.Map<User>(Modal);          
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
