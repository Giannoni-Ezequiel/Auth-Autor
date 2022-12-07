using Auth_Autor.Models;

namespace Auth_Autor.Datos
{
    public class Logica_DA
    {
        public List<User> ListaUsuarios()
        {
            return new List<User>()
            {
                new User(){ nombreUser = "Ezequiel", emailUser = "eze@gmail.com", contraseniaUser = "shashasha", Rol = new string[]{"Admin"}},
                new User(){ nombreUser = "Lorena", emailUser = "alfa@gmail.com", contraseniaUser = "sha123456", Rol = new string[] { "SuperAdmin" } },
                new User(){ nombreUser = "Fernando", emailUser = "Fer@gmail.com", contraseniaUser = "shas978", Rol = new string[] { "User" } },
                new User(){ nombreUser = "Mateo", emailUser = "mate@gmail.com", contraseniaUser = "shas456", Rol = new string[] { "Admin" } }
        };
        }
    public User ValidarUsuario(string correo, string contrasenia) {
        return ListaUsuarios().Where(item => item.emailUser == correo && item.contraseniaUser == contrasenia).FirstOrDefault();
    }
    }
}
