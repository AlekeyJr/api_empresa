using Microsoft.AspNetCore.Mvc;
using System.Linq;
using pr_web_api_empresa.Models;
namespace pr_web_api_empresa.Controllers{
[Route("api/[controller]")]
    public class EmpleadosController : Controller{
        private Conexion dbConexion;
        public EmpleadosController(){
            dbConexion = Conectar.Create();
        }
        [HttpGet]
        public ActionResult Get(){
            return Ok(dbConexion.Empleado.ToArray());
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id){
            var empleados = dbConexion.Empleado.SingleOrDefault(a => a.id_empleado ==id);
            if (empleados !=null){
                return Ok(empleados); 
            }else{
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Empleado empleados){

            if (ModelState.IsValid){
                dbConexion.Empleado.Add(empleados);
                dbConexion.SaveChanges();
                return Ok(empleados);
            }else{
                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody]Empleado empleados){
            var v_empleados = dbConexion.Empleado.SingleOrDefault(a => a.id_empleado == empleados.id_empleado);
            if(v_empleados !=null && ModelState.IsValid){
                dbConexion.Entry(v_empleados).CurrentValues.SetValues(empleados);
                dbConexion.SaveChanges();
                return Ok();
            }else{
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            var empleados = dbConexion.Empleado.SingleOrDefault(a => a.id_empleado == id);
            if (empleados !=null){
                dbConexion.Empleado.Remove(empleados);
                dbConexion.SaveChanges();
                 return Ok();
            }else{
                return NotFound();
            }

        }
    }

}