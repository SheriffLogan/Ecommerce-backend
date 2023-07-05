using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Ecommerce1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public readonly IConfiguration _configuration;

        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("UserList")]

        public Response GetUsers()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EProductCS").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetUsers(connection);

            return response;
        }

        [HttpPost]
        [Route("addProduct")]
        public Response addProduct(Products Products)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EProductCS").ToString());
            Response response = dal.addProduct(Products, connection);
            return response;
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public Response UpdateProduct(Products Products)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EProductCS").ToString());
            Response response = dal.UpdateProduct(Products, connection);
            return response;
        }
    }

}