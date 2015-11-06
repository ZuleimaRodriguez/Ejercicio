using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01.MiBd
{
    public class demoEF : DbContext 
    {
       public  DbSet<Empleado> Empleados { get; set; } 
        /*creacion de tabla y le estamos diciendo que se base en la clase 
        empleados despues le damos nombre */


    }
}
