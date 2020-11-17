using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoYoTestDemo.Models;

namespace YoYoTestDemo.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Player> players { get; set; }
    }
}
