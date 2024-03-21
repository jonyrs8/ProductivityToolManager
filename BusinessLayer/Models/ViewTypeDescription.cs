using BusinessLayer.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class ViewTypeDescription
    {
        public ViewTypeDescription(ViewType viewType)
        {
            this.ViewType = viewType;
        }
        public ViewType ViewType { get; set; }
        public string Description 
        { 
            get { return this.ViewType.Description(); } 
        }

    }
}
