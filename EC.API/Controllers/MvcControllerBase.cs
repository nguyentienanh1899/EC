using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EC.API.Controllers
{
    public abstract class MvcControllerBase<T> : Controller where T : MvcControllerBase<T>
    {
        private readonly ISender _mediator;
        private readonly ILogger<T> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        protected ISender Mediator => _mediator ?? HttpContext.RequestServices.GetService<ISender>();
        protected ILogger<T> Logger => _logger ?? HttpContext.RequestServices.GetService<ILogger<T>>();
        protected IConfiguration Configuration => _configuration ?? HttpContext.RequestServices.GetService<IConfiguration>();
        protected IMapper Mapper => _mapper ?? HttpContext.RequestServices.GetService<IMapper>();
    }
}