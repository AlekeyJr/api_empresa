using Microsoft.EntityFrameworkCore;
namespace pr_web_api_empresa.Models{
class Conexion : DbContext{
    public Conexion (DbContextOptions<Conexion> options) : base(options){}
    public DbSet<Clientes> Clientes {get;set;}
    public DbSet<Puestos> Puestos {get;set;}
    public DbSet<Empleado> Empleado {get;set;}
}
class Conectar{
    private const string cadenaConexion="server=localhost;port=3306;database=db_empresa;userid=usr_empresa;pwd=Empresa123";
    public static Conexion Create(){
        var constructor = new DbContextOptionsBuilder<Conexion>();
        constructor.UseMySQL(cadenaConexion);
        var cn = new Conexion(constructor.Options);
        return cn;

    }

}
}