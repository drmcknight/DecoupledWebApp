﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoupledWebApp.Mediation
{
    public interface ICommandHandler
    {
        CommandResult Handle(ICommand command);
        bool UserCanPerformCommand();
    }
}
