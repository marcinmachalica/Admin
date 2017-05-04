using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.ViewModels
{
    public class ProgramsViewModel
    {
        public string Id { get; set; }
        public List<Soft> Programs { get; set; }
        public List<Hotfix> Hotfixes { get; set; }
    }
}