using mvcdatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcdatabase.Views.ViewModels.Home
{
    public class HomePageViewModel
    {
        public List<Kisiler> Kisiler { get; set; }
        public List<Adresler> Adresler { get; set; }
    }
}