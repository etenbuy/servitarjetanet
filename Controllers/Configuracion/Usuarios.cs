using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using DataObjects;
using BusinessObjects;
using System.Data;

namespace Controllers.Configuracion
{
    public class Usuarios
    {
        public string CrearUsuario(string login, string password, string email, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, IList<string> roles)
        {
            MembershipCreateStatus createStatus;

            string CreateAccountResults = string.Empty;
            try
            {
                MembershipUser memUser = Membership.CreateUser(login, password, email);

                CreateAccountResults = "La cuenta de usuario fue creada correctamente!";

                DaoResult daoResult = ConfiguracionDao.ActualizarDatosUsuario(memUser.ProviderUserKey, primerNombre, segundoNombre, primerApellido, segundoApellido);

                foreach (string rol in roles)
                {
                    Roles.AddUserToRole(memUser.UserName, rol);
                }

                if (daoResult.ErrorCount > 0)
                {     
                    CreateAccountResults = "La cuenta de usuario fue creada correctamente, pero existen errores en los datos.";
                }
                

            }
            catch (MembershipCreateUserException ex)
            {
                createStatus = ex.StatusCode;

                switch (createStatus)
                {

                    case MembershipCreateStatus.DuplicateUserName:
                        CreateAccountResults = "Ya existe una cuenta con este usuario.";
                        break;

                    case MembershipCreateStatus.DuplicateEmail:
                        CreateAccountResults = "Ya existe un usuario con esta cuenta de email.";
                        break;

                    case MembershipCreateStatus.InvalidEmail:
                        CreateAccountResults = "El email que usted introdujo es inválido.";
                        break;

                    case MembershipCreateStatus.InvalidAnswer:
                        CreateAccountResults = "There security answer was invalid.";
                        break;

                    case MembershipCreateStatus.InvalidPassword:
                        CreateAccountResults = "La contraseña  que usted introdujo es inválida. Debe tener al menos 5 dígitos.";
                        break;

                    default:
                        CreateAccountResults = "Se ha generado un error desconocido; la cuenta NO fue creada.";
                        break;
                }

            }
            catch (Exception ex)
            {
                CreateAccountResults = "Se ha generado un error desconocido; la cuenta NO fue creada.";
            }

            return CreateAccountResults;

        }

        public string ActualizarUsuario(Usuario usuario, IList<string> roles)
        {
            string UpdateAccountResults = string.Empty;
        
            MembershipCreateStatus createStatus;

            string CreateAccountResults = string.Empty;
            try
            {

                Membership.UpdateUser(usuario.memUser);

                CreateAccountResults = "La cuenta de usuario fue actualizada correctamente!";

                DaoResult daoResult = ConfiguracionDao.ActualizarDatosUsuario(usuario.memUser.ProviderUserKey, usuario.PrimerNombre, usuario.SegundoNombre, usuario.PrimerApellido, usuario.SegundoApellido);

                string[] rolesUsuario = Roles.GetRolesForUser(usuario.memUser.UserName);

                if (rolesUsuario.Length > 0)
                    Roles.RemoveUserFromRoles(usuario.memUser.UserName, rolesUsuario);

                foreach (string rol in roles)
                {
                    Roles.AddUserToRole(usuario.memUser.UserName, rol);
                }
            

                if (daoResult.ErrorCount > 0)
                {
                    CreateAccountResults = "La cuenta de usuario fue creada correctamente, pero existen errores en los datos.";
                }


            }
            catch (MembershipCreateUserException ex)
            {
                createStatus = ex.StatusCode;

                switch (createStatus)
                {

                    case MembershipCreateStatus.DuplicateUserName:
                        CreateAccountResults = "Ya existe una cuenta con este usuario.";
                        break;

                    case MembershipCreateStatus.DuplicateEmail:
                        CreateAccountResults = "Ya existe un usuario con esta cuenta de email.";
                        break;

                    case MembershipCreateStatus.InvalidEmail:
                        CreateAccountResults = "El email que usted introdujo es inválido.";
                        break;

                    case MembershipCreateStatus.InvalidAnswer:
                        CreateAccountResults = "There security answer was invalid.";
                        break;

                    case MembershipCreateStatus.InvalidPassword:
                        CreateAccountResults = "La contraseña  que usted introdujo es inválida. Debe tener al menos 5 dígitos.";
                        break;

                    default:
                        CreateAccountResults = "Se ha generado un error desconocido; la cuenta NO fue creada.";
                        break;
                }

            }
            catch (Exception ex)
            {
                CreateAccountResults = "Se ha generado un error desconocido; la cuenta NO fue creada.";
            }

            return CreateAccountResults;
        }

        public Usuario GetUsuario(string login)
        {
            MembershipUser memUser = Membership.GetUser(login);
            if (memUser == null)
                return null;

            DataRow dr =  ConfiguracionDao.GetDatosUsuario(memUser.ProviderUserKey);

            Usuario usuario = new Usuario();     
            usuario.PrimerNombre = dr["PrimerNombre"].ToString();
            usuario.SegundoNombre = dr["SegundoNombre"].ToString();
            usuario.PrimerApellido = dr["PrimerApellido"].ToString();
            usuario.SegundoApellido = dr["SegundoApellido"].ToString(); 
            usuario.memUser = memUser;
            
            return usuario;

 
        }

    }
}
