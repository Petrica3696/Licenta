using System;
using System.Collections.Generic;
using Models.Read;

namespace DataAccess.Read.Abstractions
{
    public interface IRepository
    {
        List<T> ExecuteQuery<T>(string query)
            where T : BaseModel;

        T ExecuteQueryFirstOrDefault<T>(string query)
            where T : BaseModel;
    }
}
