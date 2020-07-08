using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPIAgendaTOP.Contexts;
using WebAPIAgendaTOP.Controllers.Entities;
using System.Text.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Data.SqlTypes;
using WebAPIAgendaTOP.Helpers;
using Microsoft.AspNetCore.Components;
using System.Collections.Immutable;

namespace WebAPIAgendaTOP.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    //[Authorize] Envía HTTP Error 401 UnAuthorized para todas las acciones del controlador
    public class TareasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TareasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //[HttpGet] //GET por defecto
        //public ActionResult<IEnumerable<Tarea>> Get()
        //{            
        //  return context.Agenda.Include(x => x.Cliente).ToList();
        //}

        //[HttpGet("/listado")] //GET accesible por la url api/Tareas/listado
        //[HttpGet("listado")]

        //[ServiceFilter(typeof(MiFiltroDeAccion))]
        //[ResponseCache(Duration =15)] Guarda en cache 15s si el navegador lo permite
        //[Authorize] //Envía HTTP Error 401 UnAuthorized si es el caso solo para la acción debajo
        [HttpGet]
        public List<Tarea> Get()
        {
            //var serializeOptions = new JsonSerializerOptions();
            //serializeOptions.WriteIndented = true;

            //var jsonString = JsonSerializer.Serialize(context.Agenda.ToList());
            //return jsonString.ToList<Tarea>();         
            //throw new NotImplementedException();
            return context.Agenda.ToList();
            //return context.Agenda.ToList().Where<Tarea == DateTime.Now>
            //return DateTime.Now.Second.ToString();
        }

        [Microsoft.AspNetCore.Mvc.Route("~/api/[controller]/{fecha}")]
        //[HttpGet("{fecha}")]
        [HttpGet()]
        public List<Tarea> Get (DateTime fecha)
        {
            //string query = "SELECT * FROM Department WHERE DepartmentID = @p0";
            //List<Tarea> tareasFecha = context.Agenda.SqlQuery(query, fecha).SingleOrDefaultAsync();

            //return context.Agenda.ToList().Where < t.fecha.ToString() == fecha >;
            var consulta = "Select * from Agenda where fecha >= '" + fecha + "' and fecha<'" + fecha.AddDays(1) + "'" ;
            return context.Agenda.FromSqlRaw(consulta).OrderBy(x => x.fecha).AsEnumerable().ToList();
//            return context.Agenda.OrderByDescending(x => x.fecha).ToList();

            //return context.Agenda.ToList().Where;
            //return DateTime.Now.Second.ToString();
        }

        [Microsoft.AspNetCore.Mvc.Route("~/api/[controller]/cliente/{cliente}")]
        //[HttpGet("{cliente}")]
        [HttpGet()]
        public List<Tarea> Get(string cliente)
        {
            //string query = "SELECT * FROM Department WHERE DepartmentID = @p0";
            //List<Tarea> tareasFecha = context.Agenda.SqlQuery(query, fecha).SingleOrDefaultAsync();
            int idCliente = 0;
            //** OBTENEMOS EL ID DEL CLIENTE EN FUNCIÓN DE SU NOMBRE
            var consulta = "Select * from Clientes where nombre= '" + cliente + "'";
            List<Cliente> clienteIdList = context.Clientes.FromSqlRaw(consulta).ToList();

            foreach (var item in clienteIdList)
            {
                idCliente = item.id;
            }
            //return context.Agenda.ToList().Where < t.fecha.ToString() == fecha >;
            var consulta2 = "Select * from Agenda where Clienteid=" + idCliente.ToString();
            return context.Agenda.FromSqlRaw(consulta2).OrderBy(x => x.fecha).AsEnumerable().ToList();
            //            return context.Agenda.OrderByDescending(x => x.fecha).ToList();

            //return context.Agenda.ToList().Where;
            //return DateTime.Now.Second.ToString();
        }


        //[HttpGet("{id}", Name = "ObtenerTarea")]
        [HttpGet("{id},{nada}", Name = "ObtenerTarea")]
        public ActionResult<Entities.Tarea> Get(int id)
        {
            //var tarea = context.Agenda.FirstOrDefaultAsync(x => x.id == id);
            var tarea = context.Agenda.FirstOrDefault(x => x.id == id);

            if (tarea == null)
            {
                return NotFound();
            }

            return tarea;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Tarea tarea)
        {
            //** OBTENEMOS EL ID DEL CLIENTE EN FUNCIÓN DE SU NOMBRE
            var consulta = "Select * from Clientes where nombre= '" + tarea.cliente + "'";
            List<Cliente> clienteIdList = context.Clientes.FromSqlRaw(consulta).ToList();

            foreach (var item in clienteIdList)
            {
                tarea.ClienteID = item.id;
            }
         
            context.Agenda.Add(tarea);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerTarea", new { id = tarea.id, nada = "" } , tarea);
        }

        [HttpPut("{id}")]
        public ActionResult<Tarea> Put(int id, [FromBody] Tarea tarea)
        {
            if (id != tarea.id)
            {
                return BadRequest();
            }
            //** OBTENEMOS EL ID DEL CLIENTE EN FUNCIÓN DE SU NOMBRE
            var consulta = "Select * from Clientes where nombre= '" + tarea.cliente + "'";
            List<Cliente> clienteIdList = context.Clientes.FromSqlRaw(consulta).ToList();

            foreach (var item in clienteIdList)
            {
                tarea.ClienteID = item.id;
            }


            context.Entry(tarea).State = EntityState.Modified;
            context.SaveChanges();
            return (tarea);
        }

        [HttpDelete("{id}")]
        public ActionResult<Tarea> Delete(int id)
        {
            var tarea = context.Agenda.FirstOrDefault(x => x.id == id);

            if (tarea == null)
            {
                return NotFound();
            }

            context.Agenda.Remove(tarea);
            context.SaveChanges();
            return tarea;
        }
    }
}

