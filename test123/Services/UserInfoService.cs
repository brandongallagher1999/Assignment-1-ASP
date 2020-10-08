using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test123.Models;

namespace test123.Services
{
    public class UserInfoService
    {
        private IConfiguration config;
        //private MongoClient ClientConnection;
        //private var Database;
        private readonly IMongoCollection<User_Info> _user_info;
        public UserInfoService()
        {
            try
            {
                
                var ClientConnection = new MongoClient("mongodb://localhost:27017");
                var Database = ClientConnection.GetDatabase("project");

                _user_info = Database.GetCollection<User_Info>("user_info");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        //R
        public User_Info Get(String username)
        {
            return _user_info.Find<User_Info>(user => user.username == username).FirstOrDefault();
        }
        // C
        public User_Info Create(User_Info user)
        {
            _user_info.InsertOne(user);
            return user;
        }
        // U
        public void Update(String username, User_Info newUser) =>
            _user_info.ReplaceOne(user => user.username == username, newUser);

        // D
        public void Remove(String username) =>
            _user_info.DeleteOne(user => user.username == username);

        /*
         *   "ProjectDatabaseSettings": {
                "UserLoginCollection": "user_login",
                "ConnectionString": "mongodb://localhost:27017",
                "DatabaseName" : "project"
              }
         * 
         */
    }
}
