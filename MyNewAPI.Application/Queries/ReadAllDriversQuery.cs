using MediatR;
using MyNewAPI.Application.DTOs;

namespace MyOwnAPI.Application.Queries
{
    public class ReadAllDriversQuery : IRequest<List<DriverDto>>
    {
    }
}
