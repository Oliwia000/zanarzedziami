using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zanarzedziami.Model;

namespace zanarzedziami.Service
{
    class FilleService
    {

        public ObservableCollection<Tool> Tools { get; set; } = new ObservableCollection<Tool>();
    }
}
