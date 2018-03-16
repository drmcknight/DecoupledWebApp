using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DecoupledWebApp.Domain.Models;

namespace DecoupledWebApp.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel(IEnumerable<User> users)
        {
            Users = users;
        }
        public IEnumerable<User> Users { get; set; }
    }
}