using DDD.Data.Context;
using DDD.Domain.Entities;

namespace DDD.Data.Repositories
{
    public class UserRepository: RepositoryBase<User>
    {
       public UserRepository(ContextSettings context):base(context){ }
    }
}