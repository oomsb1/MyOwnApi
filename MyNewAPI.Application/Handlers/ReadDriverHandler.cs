using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyNewAPI.Application.DTOs;
using MyOwnAPI.Application.Queries;
using MyOwnAPI.Domain.Entities;
using MyOwnAPI.Domain.Interfaces;

namespace MyOwnAPI.Application.Handlers
{
    public class ReadDriverHandler : IRequestHandler<ReadDriverQuery, DriverDto>
    {
        private readonly IReadDbContext _dbContext;
        private readonly IMapper _mapper;

        public ReadDriverHandler(IReadDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<DriverDto> Handle(ReadDriverQuery request, CancellationToken cancellationToken)
        {
            var driverEntity = await _dbContext.Set<Driver>().FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            return _mapper.Map<DriverDto>(driverEntity);
        }
    }
}
