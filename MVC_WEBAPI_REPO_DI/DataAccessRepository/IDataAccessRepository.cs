using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_WEBAPI_REPO_DI.Models;

namespace MVC_WEBAPI_REPO_DI.DataAccessRepository
{
    //Generic Interface
    public interface IDataAccessRepository<TEntity,in TPrimaryKey> where TEntity: class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TPrimaryKey id);
        void Post(TEntity entity);
        void Put(TPrimaryKey id, TEntity entity);
        void Delete(TPrimaryKey id);
    }
}
