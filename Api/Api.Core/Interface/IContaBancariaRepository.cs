using Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Interface
{
    public interface IContaBancariaRepository<TEntity> : IBaseRepository<Conta>
    {
    }
}
