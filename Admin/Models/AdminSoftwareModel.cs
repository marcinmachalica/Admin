using System.Collections.Generic;

namespace Admin.Models
{
    public class AdminSoftwareModel
    {

        public List<Soft> Programs { get; set; }
        public List<Proces> Processes { get; set; }
        public List<Hotfix> Hotfixes { get; set; }

    }
}