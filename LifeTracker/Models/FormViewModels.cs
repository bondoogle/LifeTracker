using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeTracker.Models
{
    public class FormViewModels
    {
        public class AddChoreFormModel
        {
            public string ChoreName { get; set; }
            public string ChoreDescription { get; set; }
            public string ChoreType { get; set; }
        }
    }
}