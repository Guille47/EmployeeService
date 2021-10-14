using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EmpInfoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EmpInfoService.svc o EmpInfoService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EmpInfoService : IEmpInfoService
    {
        public void DoWork()
        {

        }
        public string GetEmpSalary(string EmpId)
        {
            return "Salary of " + EmpId + " is " + 3000.00;
        }

        public Persona ObtenerPersona(string Identificacion)
        {
            if (Identificacion == "0")
            {
                return new Persona() { Nombre = "Guillermo Jimenez", Edad = 25 };
            }
            else if (Identificacion == "1")
            {
                return new Persona() { Nombre = "Carolina", Edad = 26 };
            }
            else { 
                return new Persona() { Error = "Persona no encontrada" };
            }
        }
    }
}