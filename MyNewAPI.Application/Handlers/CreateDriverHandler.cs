using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyNewAPI.Application.DTOs;
using MyOwnAPI.Application.Commands;
using MyOwnAPI.Application.Queries;
using MyOwnAPI.Domain.Entities;
using MyOwnAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnAPI.Application.Handlers
{
    public class CreateDriverHandler : IRequestHandler<CreateDriverCommand, int>
    {
        private readonly IWriteDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateDriverHandler(IWriteDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = _mapper.Map<Driver>(request.DriverRequest);
            //validate
            _dbContext.Set<Driver>().Add(driver);
            await _dbContext.SaveChangesAsync(cancellationToken);
            //return _mapper.Map<List<DriverDto>>(driverEntities);
            return driver.Id;
        }
    }
}
