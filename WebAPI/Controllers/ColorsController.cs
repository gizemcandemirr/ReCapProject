using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorDal _colorDal;

        public ColorsController(IColorDal colorDal)
        {
            _colorDal = colorDal;


        }

        [HttpGet]
        public List<Color> Get()
        {
            var result = _colorDal.GetAll();
            return result;

        }
    }
}
