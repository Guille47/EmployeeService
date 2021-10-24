using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEmpInfoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEmpInfoService
    {
        //--------------------
        //Retornando un json

        [OperationContract]
        [WebInvoke(
            Method ="GET", 
            UriTemplate= "/EmpSalaryDetail/{*EmpId}", 
            RequestFormat =WebMessageFormat.Json, 
            ResponseFormat =WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.Wrapped
            ) 
        ]
        Task<Employee[]> GetEmpSalary(string EmpId);
        //--------------------
        //Retornando como referencia de servicio o para generar un wsdl
        
        [OperationContract]
        Persona ObtenerPersona(string Identificacion);
        //--------------------
        //Retornando un json
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/Emp",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped
            )
        ]
        List<Employees> GetEmployees();
    }

    [DataContract]
    public class Persona:BaseRespuesta
    {
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int Edad { get; set; }
        public int Secreto { get; set; }
    }
    [DataContract]
    public class BaseRespuesta { 
        [DataMember]
        public string MensajeRespuesta { get; set; }
        [DataMember]
        public string Error { get; set; }

    }
}
