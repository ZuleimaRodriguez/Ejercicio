using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio01.MiBd
{
   public class Departamento
    {
     
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
