using System;
using System.Collections.Generic;
using System.Text;

namespace NET.App.API.CommandModels
{
    public class Revit_Response
    {
        public Revit_Response(bool isSuccess,string messages) {

            IsSuccess = isSuccess;
            Messages = messages;
        }
        bool IsSuccess { get; set; }


        public string Messages { get; set; }
    }
}
