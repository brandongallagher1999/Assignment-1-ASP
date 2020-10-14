using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using test123.Models;

namespace test123.Services
{
    public class UserInfoService
    {
        //private MongoClient ClientConnection;
        //private var Database;
        private readonly IMongoCollection<User_Info> _user_info;
        public UserInfoService()
        {
            try
            {

                string host = "cryptoguys.mongo.cosmos.azure.com";
                string dbName = "project";
                string collectionName = "user_info";
                string password = "Ogxgq08WJk8MerckKmWDL7531KWXQaLmkBOr0RZlzGHfSJDrj1aNft7d5qRdfNlwkaTHCyi4pS0kSVYPQnXc8w==";
                string username = "cryptoguys";
                MongoClientSettings settings = new MongoClientSettings();
                settings.Server = new MongoServerAddress(host, 10255);
                settings.UseTls = true;
                settings.SslSettings = new SslSettings();
                settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;
                PasswordEvidence evidence = new PasswordEvidence(password);
                MongoIdentity identity = new MongoInternalIdentity(dbName, username);
                settings.Credential = new MongoCredential("SCRAM-SHA-1", identity, evidence);


                var mongoClient = new MongoClient(settings);


                //var ClientConnection = new MongoClient("mongodb://localhost:27017");
                var Database = mongoClient.GetDatabase("project");

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
