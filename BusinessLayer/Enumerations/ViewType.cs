using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Enumerations
{
    /// <summary>
    /// THIS CLASS IS USED TO DEFINE VIEWTYPE ENUM
    /// </summary>

    #region ENUM
    public enum ViewType
    {
        Task = 0,
        Efficiency = 1
    }
    #endregion

    #region METHODS
    /// <summary>
    /// IS NOT USED BUT ITS HERE TO SHOW AN CLASS EXTENSION
    /// </summary>
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
    #endregion
}
