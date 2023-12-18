using MediatR;
using MyNewAPI.Application.DTOs;

namespace MyOwnAPI.Application.Queries
{
    public class ReadDriverQuery : IRequest<DriverDto>
    {
        public int Id { get; set; }
        public ReadDriverQuery(int id)
        {
            Id = id;
        }
    }
}
