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
    public class UserController : ControllerBase
    {
        public readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        

        [HttpGet]
        [Route("ViewUser/{id}")]

        public Response GetUserById(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EProductCS").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetUserById(connection, id);
            return response;
        }

        [HttpPost]
        [Route("registration")]
        public Response register(Users users)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EProductCS").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.register(connection, users);
            return response;
        }

        [HttpPost]
        [Route("login")]
        public Response login(Users users)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EProductCS").ToString());
            Response response = dal.Login(users, connection);
            return response;
        }

        [HttpPut]
        [Route("updateProfile")]
        public Response updateProfile(Users users)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EProductCS").ToString());
            Response response = dal.updateProfile( connection, users);
            return response;
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public Response DeleteProfile(int id)
        {
            SqlConnection connection = new SqlConnection((_configuration.GetConnectionString("EProductCS").ToString()));
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.DeleteProfile(connection, id);
            return response;
        }
    }
}