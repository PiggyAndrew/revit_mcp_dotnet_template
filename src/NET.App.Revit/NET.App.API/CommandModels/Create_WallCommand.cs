using System;
using System.Collections.Generic;
using System.Text;
using NET.App.Revit.Models;

namespace NET.App.API.CommandModels
{
    public class Create_WallCommand : ICommand<Create_Wall>
    {
        public string Description { get; set; }
        public string Name { get ; set ; }
        public Create_Wall Parameter { get; set  ; }
    }
}
