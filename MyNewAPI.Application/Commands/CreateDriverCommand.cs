using MediatR;
using MyNewAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnAPI.Application.Commands
{
    public class CreateDriverCommand :IRequest<int>
    {
        public DriverDto DriverRequest { get; set; }
        public CreateDriverCommand(DriverDto driver)
        {
            DriverRequest = driver;
        }
    }
}
