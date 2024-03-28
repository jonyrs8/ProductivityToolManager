using BusinessLayer.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    /// <summary>
    /// THIS CLASS SHOULD ONLY BE USED TO MANAGE VIEWTYPEDESCRIPTION OBJECTS
    /// </summary>
    public class ViewTypeDescription
    {
        #region CONSTRUCTORES
        public ViewTypeDescription(ViewType viewType)
        {
            this.ViewType = viewType;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// METHOD TO SHOW DESCRIPTION OF VIEWTYPE ENUM CLASS
        /// </summary>
        public ViewType ViewType { get; set; }
        public string Description 
        { 
            get { return this.ViewType.Description(); } 
        }
        #endregion
    }
}
