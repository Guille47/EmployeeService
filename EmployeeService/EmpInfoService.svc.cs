using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EmpInfoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EmpInfoService.svc o EmpInfoService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EmpInfoService : IEmpInfoService
    {
        public void DoWork()
        {

        }
        //Consumiendo un api y enviarlo como respuesta
        async public Task<Employee[]> GetEmpSalary(string EmpId)
        {
            //Consume api 
            //https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
            Employee[] employee = null;
            const string url = "https://jsonplaceholder.typicode.com/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("/todos");

            if (response.IsSuccessStatusCode)
            {
                employee = await response.Content.ReadAsAsync<Employee[]>();
            }
            return employee;

            //string retorno = EmpId == "" ? "No hay ningun parametro de id" : EmpId;
            //return retorno;
        }
        //Extrayendo desde EDT
        public List<Employees> GetEmployees()
        {
            using (var context = new NorthwindEntities())
            {
                var blogs = context.Employees.ToList<Employees>();
                return blogs;
            }

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