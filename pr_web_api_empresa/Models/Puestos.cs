using System.ComponentModel.DataAnnotations;
namespace pr_web_api_empresa.Models{
    public class Puestos{
        [Key]
        public int id_puestos{get;set;}
        public string puesto {get;set;}
    }
}