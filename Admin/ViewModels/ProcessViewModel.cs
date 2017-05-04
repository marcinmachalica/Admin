using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.ViewModels
{
    public class ProcessViewModel
    {
        public string Id { get; set; }
        public List<Proces> Processes { get; set; }
        
    }
}