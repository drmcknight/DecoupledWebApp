using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoupledWebApp.Domain.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public User CurrentOwner { get; set; }

        public void Checkout(User person)
        {
            CurrentOwner = person;
            // Fire
        }
    }
}
