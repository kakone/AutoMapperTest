using AutoMapper;
using AutoMapper.AspNet.OData;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        public TestController(IMapper mapper, MyDbContext dbContext)
        {
            Mapper = mapper;
            DbContext = dbContext;
        }

        private IMapper Mapper { get; }
        private MyDbContext DbContext { get; }

        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> GetAsync(ODataQueryOptions<OrderDTO> options)
        {
            return await DbContext.Orders.GetAsync(Mapper, options);
        }

        [HttpGet("ProjectTo")]
        public async Task<IEnumerable<OrderDTO>> ProjectToAsync()
        {
            return await DbContext.Orders.ProjectTo<OrderDTO>(Mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
