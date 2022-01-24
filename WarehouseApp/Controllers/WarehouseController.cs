using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace WarehouseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseDbContext warehouseDbContext;

        public WarehouseController(WarehouseDbContext context)
        {
            warehouseDbContext = context;
        }

        //Create record
        [Authorize]
        [HttpPut]
        public ActionResult Put([FromBody] Good request)
        {
            Good good = new Good()
            {
                Name = request.Name,
                Features = request.Features
            };
            try
            {
                warehouseDbContext.Add(good);
                warehouseDbContext.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        //Update record
        [Authorize]
        [HttpPost]
        public ActionResult Post([FromBody] Good request)
        {
            Good item = warehouseDbContext.Goods.Where(g => g.GoodId == request.GoodId || g.Name == request.Name).First();
            try
            {
                item.Name = request.Name;
                foreach (var feature in request.Features)
                {
                    item.Features.Add(feature);
                }
                warehouseDbContext.Goods.Update(item);
                warehouseDbContext.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [Authorize]
        [HttpGet("{GoodId}")]
        public ActionResult<List<Good>> Get(int GoodId)
        {
            List<Good> result = new List<Good>();

            result = (from good in warehouseDbContext.Goods
                            where good.GoodId == GoodId
                            select new Good
                            {
                                GoodId = good.GoodId,
                                Name = good.Name,
                                Features = good.Features.ToList()
                            }).ToList();

            if (result.Count > 0)
            {
                return result;
            }
            return NotFound();
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<Good>> Get()
        {
            List<Good> result = new List<Good>();

            result = (from good in warehouseDbContext.Goods
                             select new Good
                             {
                                 GoodId = good.GoodId,
                                 Name = good.Name,
                                 Features = good.Features.ToList()
                             }).ToList();

            if (result.Count > 0)
            {
                return result;
            }
            return NotFound();
        }

        //Delete record
        [Authorize]
        [HttpDelete]
        public ActionResult Delete([FromBody] Good request)
        {
            Good item = warehouseDbContext.Goods.Where(g => g.GoodId == request.GoodId || g.Name == request.Name).First();
            try
            {
                warehouseDbContext.Goods.Remove(item);
                warehouseDbContext.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}