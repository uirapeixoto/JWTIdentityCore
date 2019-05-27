using Dapper;
using JWTIdentityCore.Api.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JWTIdentityCore.Api.DAO
{
    public class UsersDAO
    {
        private IConfiguration _configuration;

        public UsersDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User Find(string UserName)
        {
            using (SqlConnection conexao = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection")))
            {
                var result = conexao.QueryFirstOrDefault<User>(
                    @"SELECT u.Id
                          ,u.UserName
                          ,u.Email
                          ,u.Password
	                      ,p.Name Profile
	                      ,c.Name Client
                          ,u.CreatedAt
                          ,u.ModifiedAt
                      FROM [dbo].[UserProfile] pu
                      JOIN [dbo].[User] u on pu.IdUser = u.Id
                      JOIN [dbo].[Profile] p on pu.IdProfile = p.ID
                      JOIN [dbo].[Client] c on pu.IdClient= c.ID 
                    WHERE [UserName] = @UserName", new { UserName = UserName });

                return result ?? new User();
            }
        }
    }
}
