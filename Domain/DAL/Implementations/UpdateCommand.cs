using Domain.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DAL.Implementations
{
    public class UpdateCommand<T> : IUpdateCommand<T> where T : class
    {
        public void Execute(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
