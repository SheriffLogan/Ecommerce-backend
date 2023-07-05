using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce1.Models
{
    public class DAL
    {
        public Response GetUsers(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Users", connection);
            DataTable dt = new DataTable();
            List<Users> ListUsers = new List<Users>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Users users = new Users();
                    users.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    users.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    users.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    users.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    users.Type = Convert.ToString(dt.Rows[i]["Type"]);
                    ListUsers.Add(users);
                }
            }
            if (ListUsers.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.ListUsers = ListUsers;
            }
            else
            {
                response.StatusCode = 0;
                response.StatusMessage = "No Data Found";
                response.ListUsers = null;
            }
            return response;
        }

        public Response GetUserById(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Users Where Id = '" + id + "'", connection);
            DataTable dt = new DataTable();
            Users Users = new Users();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Users users = new Users();
                    users.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    users.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                    users.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                    users.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    users.Type = Convert.ToString(dt.Rows[0]["Type"]);
                    response.StatusCode = 200;
                    response.StatusMessage = "Data Found";
                    response.Users = users;
                }
            }
            else
            {
                response.StatusCode = 0;
                response.StatusMessage = "No Data Found";
                response.ListUsers = null;
            }
            return response;
        }

        public Response register(SqlConnection connection, Users users)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Insert into Users(FirstName, LastName, Email, Password, Type, CreatedOn) Values('" + users.FirstName + "', '" + users.LastName + "', '" + users.Email + "', '" + users.FirstName + "', '" + users.FirstName + "', GETDATE())", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data inserted";
            }
            else
            {
                response.StatusCode = 0;
                response.StatusMessage = "No Data inserted";
            }
            return response;
        }

        public Response Login(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Users where Email = '"+users.Email+"' AND Password = '"+users.Password+"'", connection);
            DataTable dt = new DataTable();
            Users Users = new Users();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "User is Valid";
                response.Users = users;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User is Invalid";
                response.Users = null;
            }
            return response;
        }

        public Response updateProfile(SqlConnection connection, Users users)

        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Update Users Set FirstName = '" + users.FirstName + "', LastName = '" + users.LastName + "', Email = '" + users.Email + "' Where Id = '" + users.Id + "' ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Record updated successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Some error occurred. Try after some time";

            }
            return response;

        }

        public Response DeleteProfile(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Delete from Users Where Id = '"+id+"'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Profile Deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Profile Deletd";
            }
            return response;
        }

        public Response addToCart(Cart cart, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("insert into Cart(UserID, ProductId, UnitPrice, Discount, Quantity, TotalPrice) Values ('"+cart.UserId+ "', '" + cart.ProductId + "', '" + cart.UnitPrice + "', '" + cart.Discount + "', '" + cart.Quantity + "', '" + cart.TotalPrice + "')", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Item added to cart";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Item could not be added";
            }
            return response;
        }

        public Response addProduct(Products products, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("insert into Products(Name, Manufacturer, UnitPrice, Discount, Quantity, Status, ImageUrl) Values ('"+products.Name+ "', '" + products.Manufacturer + "', '" + products.UnitPrice + "', '" + products.Discount + "', '" + products.Quantity + "', '" + products.Status + "', '" + products.ImageUrl + "')", connection);
          
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product inserted Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Product could not be inserted";
            }
            return response;
        }

        public Response UpdateProduct(Products products, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Update Products Set Name = '" + products.Name + "', Manufacturer = '" + products.Manufacturer + "', UnitPrice = '" + products.UnitPrice + "', Discount = '" + products.Discount + "', Quantity = '" + products.Quantity + "', Status = '" + products.Status + "', ImageUrl = '" + products.ImageUrl + "' Where Id = '" + products.Id + "' ", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product Updated Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Product could not be Updated";
            }
            return response;
        }

        public Response placeOrder(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("insert into Orders(userId) values ('"+users.Id+"')", connection);
            
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Order has been placed successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order coud not be placed";
            }

            return response;
        }

        public Response orderList(Users users, SqlConnection connection)
        {
            Response response = new Response();
            List<Orders> listOrder = new List<Orders>();
            SqlDataAdapter da = new SqlDataAdapter("select * from Orders where userid = '"+users.Id+"'", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Orders order = new Orders();
                    order.Id = Convert.ToInt32(dt.Rows[i]["ID"]);
                    order.OrderNo = Convert.ToString(dt.Rows[i]["OrederNo"]);
                    order.OrderTotal = Convert.ToDecimal(dt.Rows[i]["OrderTotal"]);
                    order.OrderStatus = Convert.ToString(dt.Rows[i]["OrderStatus"]);
                    listOrder.Add(order);

                }
                if (listOrder.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Order details are fetched";
                    response.listOrders = listOrder;

                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Order details are not available";
                    response.listOrders = null;

                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order details are not available";
                response.listOrders = null;

            }


            return response;
        }


    }
}
