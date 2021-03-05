using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Core.ApplicationServices.Categories.Commands.CreateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Common;
using Zamin.EndPoints.Web.Controllers;

namespace ProductManagement.EndPoints.API.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            return await Create(createCategoryCommand);
        }
    }
}
