using System;
using System.Data;

namespace WNKLab.Infra.Repository.Infrastructure
{
    public interface IConnectionFactory : IDisposable
    {
        IDbConnection GetConnection { get; }
    }
}
