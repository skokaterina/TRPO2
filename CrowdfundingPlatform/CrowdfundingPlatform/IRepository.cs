using CrowdfundingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdfundingPlatform
{
    public interface IUserRepository
    {
        List<User> Users { get; }
        bool CreateUser(User user);
        bool UpdateUser(User user);
        User GetUser(string email);
        User GetUser(Guid id);        
        User Login(string userName, string Password);
        List<Role> Roles { get; }
        List<Basket> Basket();
    }

    public interface IProjectRepository
    {
        Project Project(Guid Id);
        List<Project> List();
        void Create(Project Project);
        
        void Update(Project Project);
    }

    public interface IAwardRepository
    {
        Award Award(Guid Id);
        List<Award> List(Guid ProjectId);
        void Create(Award Award);
        Award Create(Guid ProjectId);
        void Update(Award Award);
        void Buy(Award Award);
    }
}