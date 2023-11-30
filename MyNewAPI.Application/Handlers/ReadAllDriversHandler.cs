using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyNewAPI.Application.DTOs;
using MyOwnAPI.Application.Queries;
using MyOwnAPI.Domain.Entities;
using MyOwnAPI.Domain.Interfaces;

namespace MyOwnAPI.Application.Handlers
{
    public class ReadAllDriversHandler : IRequestHandler<ReadAllDriversQuery, List<DriverDto>>
    {
        private readonly IReadDbContext _dbContext;
        private readonly IMapper _mapper;

        public ReadAllDriversHandler(IReadDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<DriverDto>> Handle(ReadAllDriversQuery request, CancellationToken cancellationToken)
        {
            var driverEntities = await _dbContext.Set<Driver>().ToListAsync(cancellationToken);
            return _mapper.Map<List<DriverDto>>(driverEntities);
        }
    }
}
