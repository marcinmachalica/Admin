using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Admin.ViewModels;
using MongoDB.Bson.Serialization;

namespace Admin.Controllers
{
    public class HomeController : Controller
    {



        async public Task<ActionResult> Index()
        {
            try
            {
                Config conf = new Config();
                var coll = conf.Connect();
                IEnumerable<AdminModel> list = await coll.Find(_ => true).ToListAsync();
                List<IndexViewModel> ViewList = new List<IndexViewModel>();
                foreach (var item in list)
                {
                    IndexViewModel VM = new IndexViewModel()
                    {
                        ViewModelId = item._id,
                        ComputerName = item.Hardware.ComputerName,
                        OsVersion = item.Hardware.OsVersion,
                        UserName = item.Hardware.UserName,
                        Is64 = item.Hardware.Is64,
                        TickCount = item.Hardware.TickCount,
                        UserDomain = item.Hardware.UserDomain,
                        CpuName = item.Hardware._cpu.CPUName,
                        GpuName = item.Hardware._gpu.GPUName,
                        RAMsize = (item.Hardware._memory.UsedMemory[0] + item.Hardware._memory.UsedMemory[1]).ToString(),
                        Mbname = item.Hardware._mb.MBName,
                        HDDName = item.Hardware._hdd.HDName[0],
                        LastUpdate = item.Hardware.LastUpdate
                    };
                    ViewList.Add(VM);

                }



                return View(ViewList);
            }
            catch { return View("Error"); }
        }


        async public Task<ActionResult> Details(string id)
        {
            try
            {
                Config conf = new Config();
                var coll = conf.Connect();
                AdminModel list = await coll.Find(_ => _._id == id).SingleAsync();
                var model = new DetailsViewModel(list);

                return View("Details", model);
            }
            catch { return View("Error"); }
        }

        async public Task<ActionResult> AjaxDetails(string id)
        {
            try
            {
                Config conf = new Config();
                var coll = conf.Connect();
                AdminModel list = await coll.Find(_ => _._id == id).SingleAsync();
                var model = new DetailsViewModel(list);

                return PartialView("_AjaxDetails", model);
            }
            catch { return View("Error"); }
        }

        async public Task<ActionResult> Programs(string id, int code = 0)
        {
            try
            {
                Config conf = new Config();
                var coll = conf.Connect();
                AdminModel list = await coll.Find(_ => _._id == id).SingleAsync();
                ProgramsViewModel model = new ProgramsViewModel()
                {
                    Id = id,
                    Programs = list.Software.Programs,
                    Hotfixes = list.Software.Hotfixes
                };
                return View("Programs", model);
            }
            catch
            {
                return View("Error");
            }
        }

        async public Task<ActionResult> Processes(string id, int code = 0)
        {
            try
            {
                Config conf = new Config();
                var coll = conf.Connect();
                AdminModel list = await coll.Find(_ => _._id == id).SingleAsync();
                ProcessViewModel model = new ProcessViewModel()
                {
                    Id = id,
                    Processes = list.Software.Processes
                };
                return View("Processes", model);
            }
            catch { return View("Error"); }
        }

        async public Task<ActionResult> Uninstall(string id, string identifyingNumber)
        {

            Config conf = new Config();
            var coll = conf.Connect();
            AdminModel model = await coll.Find(_ => _._id == id).SingleAsync();
            foreach (var item in model.Software.Programs)
            {
                if (item.IdentifyingNumber == identifyingNumber)
                {
                    item.Remove = true;
                };
            }
            var filter = Builders<AdminModel>.Filter.Eq(s => s._id, id);
            await coll.DeleteOneAsync(filter);
            try
            {
                await coll.InsertOneAsync(model);
            }
            catch { return RedirectToAction("Programs", new { id = id, code = 2 }); };
            return RedirectToAction("Programs", new { id = id, code = 1 }); ;
        }

        async public Task<ActionResult> KillProces(string id, string procesID)
        {

            Config conf = new Config();
            var coll = conf.Connect();
            AdminModel model = await coll.Find(_ => _._id == id).SingleAsync();
            foreach (var item in model.Software.Processes)
            {
                if (item.ProcesId == procesID)
                {
                    item.Remove = true;
                };
            }
            var filter = Builders<AdminModel>.Filter.Eq(s => s._id, id);
            await coll.DeleteOneAsync(filter);
            try
            {
                await coll.InsertOneAsync(model);
            }
            catch { return RedirectToAction("Processes", new { id = id, code = 2 }); };
            return RedirectToAction("Processes", new { id = id, code = 1 }); ;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}