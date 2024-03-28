using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    /// <summary>
    /// THIS INTERFACE IS USED TO IMPLEMENTED AREA AND VALUE PROPERTIES
    /// </summary>
    public interface IAreaValue
    {
        #region PROPERTIES
        string Area { get; set; }
        double Value { get; }
        #endregion
    }


}
