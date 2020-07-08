using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPIAgendaTOP.Contexts;
using WebAPIAgendaTOP.Controllers.Entities;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Collections;

namespace WebAPIAgendaTOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ClientesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<string> Get()
        {
            //** DEVOLVEMOS SOLAMENTE NOMBRE DE CLIENTE
            var clientes = context.Clientes
              .Select(f => new Cliente
              {
                  
                  nombre = f.nombre
              })
              .OrderBy(x => x.nombre).ToList();

            List<string> optionList = new List<string>();
            foreach (var item in clientes)
            {
                optionList.Add(item.nombre.Trim());
            }
            
            return optionList;
            //.Select(f => new ClienteBasico
            //{
            //    id = f.id,
            //    nombre = f.nombre
            //})
            //return clientesBasico;
//            List<string> optionList = 
//             new List<string>
//{
//    "ANA","ANTONIO","CARLOS"
//};
//            return optionList;

            //return context.Clientes.OrderBy(x => x.nombre).ToList();

            //return context.Clientes.FromSqlRaw<Cliente>("Select nombre from dbo.Clientes").ToList();
            //return context.Clientes.Include(x => x.Tareas).ToList();
        }

        [HttpGet("{id}", Name = "ObtenerCliente")]
        public ActionResult<Entities.Cliente> Get(int id)
        {
            var cliente = context.Clientes.FirstOrDefault(x => x.id == id);
            //var cliente = context.Clientes.Include(x => x.Tareas).FirstOrDefault(x => x.id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [Microsoft.AspNetCore.Mvc.Route("~/api/[controller]/filtro")]
        //[HttpGet("{cliente}")]
        [HttpGet()]
        public List<Cliente> Get(string nombre = null, string direccion = null)
        {
            if (Request.Query.ContainsKey("nombre") && nombre == null)
                nombre = "";
            if (Request.Query.ContainsKey("direccion") && direccion == null)
                direccion = "";
            //string query = "SELECT * FROM Department WHERE DepartmentID = @p0";
            //List<Tarea> tareasFecha = context.Agenda.SqlQuery(query, fecha).SingleOrDefaultAsync();
            int idCliente = 0;
            //** OBTENEMOS EL ID DEL CLIENTE EN FUNCIÓN DE SU NOMBRE
            var consulta = "Select * from Clientes where nombre= '" + nombre + "'";
            List<Cliente> clienteIdList = context.Clientes.FromSqlRaw(consulta).ToList();

            foreach (var item in clienteIdList)
            {
                idCliente = item.id;
            }
            //return context.Agenda.ToList().Where < t.fecha.ToString() == fecha >;
            string condicionId;
            string condicionDireccion;
            string condicion;
            if (idCliente == 0)
                condicionId = "";
            else
                condicionId = " id=" + idCliente.ToString()
            ;
            if (direccion == "")
                condicionDireccion = "";
            else
                condicionDireccion = " direccion like '%" + direccion + "%'"
            ;

            condicion = condicionId;
            if ((condicion != "") && (condicionDireccion != ""))
                condicion = condicion + " and ";

            condicion = condicion + condicionDireccion;

            if (condicion != "")
                condicion = " where " + condicion;

            var consulta2 = "Select * from Clientes " + condicion;
            List<Cliente> listaNombres = context.Clientes.FromSqlRaw(consulta2).OrderBy(x => x.nombre).AsEnumerable().ToList();

            return listaNombres;

            //            return context.Agenda.OrderByDescending(x => x.fecha).ToList();

            //return context.Agenda.ToList().Where;
            //return DateTime.Now.Second.ToString();
        }

        //[Microsoft.AspNetCore.Mvc.Route("~/api/[controller]/filtro")]
        ////[HttpGet("{cliente}")]
        //[HttpGet()]
        //public List<string> Get(string nombre = null, string direccion = null)
        //{
        //    if (Request.Query.ContainsKey("nombre") && nombre == null)
        //        nombre = "";
        //    if (Request.Query.ContainsKey("direccion") && direccion == null)
        //        direccion = "";
        //    //string query = "SELECT * FROM Department WHERE DepartmentID = @p0";
        //    //List<Tarea> tareasFecha = context.Agenda.SqlQuery(query, fecha).SingleOrDefaultAsync();
        //    int idCliente = 0;
        //    //** OBTENEMOS EL ID DEL CLIENTE EN FUNCIÓN DE SU NOMBRE
        //    var consulta = "Select * from Clientes where nombre= '" + nombre + "'";
        //    List<Cliente> clienteIdList = context.Clientes.FromSqlRaw(consulta).ToList();

        //    foreach (var item in clienteIdList)
        //    {
        //        idCliente = item.id;
        //    }
        //    //return context.Agenda.ToList().Where < t.fecha.ToString() == fecha >;
        //    string condicionId;
        //    string condicionDireccion;
        //    string condicion;
        //    if (idCliente == 0)
        //        condicionId = "";
        //    else
        //        condicionId = " id=" + idCliente.ToString()
        //    ;
        //    if (direccion == "")
        //        condicionDireccion = "";
        //    else
        //        condicionDireccion = " direccion like '%" + direccion + "%'"
        //    ;

        //    condicion = condicionId;
        //    if ((condicion != "") && (condicionDireccion != ""))
        //        condicion = condicion + " and ";

        //    condicion = condicion + condicionDireccion;

        //    if (condicion != "")
        //        condicion = " where " + condicion;

        //    var consulta2 = "Select nombre from Clientes " + condicion;
        //    List<ClienteBasico> listaNombres = context.ClientesBasico.FromSqlRaw(consulta2).OrderBy(x => x.nombre).AsEnumerable().ToList();

        //    List<string> optionList = new List<string>();
        //    foreach (var item in listaNombres)
        //    {
        //        optionList.Add(item.nombre.Trim());
        //    }

        //    return optionList;

        //    //            return context.Agenda.OrderByDescending(x => x.fecha).ToList();

        //    //return context.Agenda.ToList().Where;
        //    //return DateTime.Now.Second.ToString();
        //}

        [Microsoft.AspNetCore.Mvc.Route("~/api/[controller]/nombre/{nombre}")]
        //[HttpGet("{cliente}")]
        [HttpGet()]
        public List<Entities.Cliente> Get(string nombre)
        {
            //string query = "SELECT * FROM Department WHERE DepartmentID = @p0";
            //List<Tarea> tareasFecha = context.Agenda.SqlQuery(query, fecha).SingleOrDefaultAsync();
            int idCliente = 0;
            //** OBTENEMOS EL ID DEL CLIENTE EN FUNCIÓN DE SU NOMBRE
            var consulta = "Select * from Clientes where nombre= '" + nombre + "'";
            List<Cliente> clienteIdList = context.Clientes.FromSqlRaw(consulta).ToList();

            foreach (var item in clienteIdList)
            {
                idCliente = item.id;
            }
            //return context.Agenda.ToList().Where < t.fecha.ToString() == fecha >;
            var consulta2 = "Select * from Clientes where id=" + idCliente.ToString();
            return context.Clientes.FromSqlRaw(consulta2).OrderBy(x => x.nombre).AsEnumerable().ToList();
            //            return context.Agenda.OrderByDescending(x => x.fecha).ToList();

            //return context.Agenda.ToList().Where;
            //return DateTime.Now.Second.ToString();
        }

        [HttpPost]
        public ActionResult<Cliente> Post([FromBody] Cliente cliente)
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerCliente", new { id = cliente.id }, cliente);
        }

        [HttpPut("{id}")]
        public ActionResult<Cliente> Put(int id, [FromBody] Cliente value)
        {
            if (id != value.id) 
            {
                return BadRequest();
            }

            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            //return Ok();
            return (value);
        }

        [HttpDelete("{id}")]
        public ActionResult<Cliente> Delete(int id)
        {
            var cliente = context.Clientes.FirstOrDefault(x => x.id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            context.Clientes.Remove(cliente);
            context.SaveChanges();
            return cliente;
        }

    }

}
