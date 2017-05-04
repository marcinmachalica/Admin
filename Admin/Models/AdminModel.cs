using MongoDB.Bson;
using MongoDB.Driver;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Admin.Models
{
    public class AdminModel
    {
        public string _id { get; set; }
        public AdminHardwareModel Hardware { get; set; }
        public AdminSoftwareModel Software { get; set; }




        //async public Task<List<AdminHardwareModel>> ReadMongoBase()
        //{


        //    var _client = new MongoClient();
        //    var _db = _client.GetDatabase("ComputersStore");
        //    var coll = _db.GetCollection<AdminHardwareModel>("Computer");


        //    return await coll.Find(_ => true).ToListAsync();


        //}
    }
}