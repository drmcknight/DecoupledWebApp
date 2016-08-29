﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoupledWebApp.Domain.Commands
{
    public class CheckOutBookCommand : ICommand
    {
        public CheckOutBookCommand(string userName, string bookTitle)
        {
            UserName = userName;
            BookTitle = bookTitle;
        }

        public string UserName { get; private set; }
        public string BookTitle { get; private set; }
    }
}
