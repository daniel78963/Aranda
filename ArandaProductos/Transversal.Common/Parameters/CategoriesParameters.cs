using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transversal.Common.Parameters
{ 
   public class CategoriesParameters : QueryStringParameters
    {
        public CategoriesParameters()
        {
            OrderBy = "nombrecategoria";
        }
        //public uint MinYearOfBirth { get; set; }
        //public uint MaxYearOfBirth { get; set; } = (uint)DateTime.Now.Year;
        //public bool ValidYearRange => MaxYearOfBirth > MinYearOfBirth;
        public string NombreCategoria { get; set; }
    }
}
