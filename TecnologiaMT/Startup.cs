using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TecnologiaMT.Models;

[assembly: OwinStartupAttribute(typeof(TecnologiaMT.Startup))]
namespace TecnologiaMT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CrearRolesConUsuarios();
        }
        private void CrearRolesConUsuarios()
        {
            // Acceder al metodo de Seguridad
            ApplicationDbContext context = new ApplicationDbContext();

            //Definimos las variables manejadoras de roles y usuarios
            var ManejadorRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            IdentityRole rol = new IdentityRole();
            //Verificamos la existencia de los roles por defecto y creamos el rol y usuario para el Administrado
            //ROL ADMINISTRADOR

            if (!ManejadorRol.RoleExists("ADMINISTRADOR"))
            {
                //sino existe, se crea el rol y se asigna un nuevo usuario con ese rol
                rol = new IdentityRole();
                rol.Name = "ADMINISTRADOR";
                ManejadorRol.Create(rol);

                //creamos un primer usuario para ese rol
                var user = new ApplicationUser();

                //Asignamos los valores
                user.UserName = "Admin@gmail.com";
                user.Email = "Admin@gmail.com";

                string PWD = "Admin1234@";
                var chkUser = ManejadorUsuario.Create(user, PWD);
                //verificar

                //si se creo con exito
                if (chkUser.Succeeded)
                {
                    ManejadorUsuario.AddToRole(user.Id, "ADMINISTRADOR");
                }

            }
           //ROL VENDEDOR

            if (!ManejadorRol.RoleExists("VENDEDOR"))
            {
                //sino existe, se crea el rol y se asigna un nuevo usuario con ese rol
                rol = new IdentityRole();
                rol.Name = "VENDEDOR";
                ManejadorRol.Create(rol);

                //creamos un primer usuario para ese rol
                var user = new ApplicationUser();

                //Asignamos los valores
                user.UserName = "vendedor@gmail.com";
                user.Email = "vendedor@gmail.com";
                string PWD = "Vend1234%";
                var chkUser = ManejadorUsuario.Create(user, PWD);
                //si se creo con exito
                if (chkUser.Succeeded)
                {
                    ManejadorUsuario.AddToRole(user.Id, "VENDEDOR");
                }
            }

            //Verificamos la excistencia de los roles por defecto
            //ROL COBRADOR

            if (!ManejadorRol.RoleExists("COBRADOR"))
            {
                //    //sino existe, se crea el rol y se asigna un nuevo usuario con ese rol
            rol = new IdentityRole();
            rol.Name = "COBRADOR";
            ManejadorRol.Create(rol);

            //creamos un primer usuario para ese rol
            var user = new ApplicationUser();

            //Asignamos los valores
            user.UserName = "Cobrador@gmail.com";
            user.Email = "Cobrador@gmail.com";
            string PWD = "Cobra1234$";
            var chkUser = ManejadorUsuario.Create(user, PWD);
            //si se creo con exito
                if (chkUser.Succeeded)
                {
                    ManejadorUsuario.AddToRole(user.Id, "COBRADOR");
                }
            }

    
    
}
    }
}
