using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // url
    public class BakersController : ControllerBase
    {
        private readonly ApplicationContext _context; // _ means a private field
        public BakersController(ApplicationContext context) {
            _context = context;
        }

        // OUR REST API

        // get all bakers
        [HttpGet] // HTTP methods
        // router.get()
        public IEnumerable<Baker> GetAll() {
            Console.WriteLine("get all bakers");

            // must return something
            // res.send
            // NO SQL
            return _context.Bakers;
        }

        // post
        [HttpPost]
        public IActionResult Post(Baker baker) {
            Console.WriteLine("in post");

            // SQL transactions
            _context.Add(baker);
            _context.SaveChanges();

            // 201
            return CreatedAtAction(nameof(Post), new {id = baker.id}, baker);
        }

    }
}
