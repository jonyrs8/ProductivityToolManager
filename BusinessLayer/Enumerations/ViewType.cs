using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Enumerations
{
    public enum ViewType
    {
        Task = 0,
        Efficiency = 1
    }

    public static class ViewTypeExtensionsMethods 
    {
        public static string Description(this ViewType viewType) 
        { 
            switch(viewType)
            {
                case ViewType.Task:
                    return Properties.Resources.ViewType_Task;
                case ViewType.Efficiency:
                    return Properties.Resources.ViewType_Efficiency;
                default:
                    return string.Empty;
            }
        }

        
    }
}
