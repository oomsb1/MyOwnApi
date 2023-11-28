using Microsoft.EntityFrameworkCore;
using MyOwnAPI.Domain.Interfaces;

namespace MyOwnApi.DAL
{
    public class MyApiDbContext: DbContext, IReadDbContext
    {

    }
}