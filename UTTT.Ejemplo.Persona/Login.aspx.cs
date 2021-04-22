using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;

namespace UTTT.Ejemplo.Persona
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                UTTT.Ejemplo.Linq.Data.Entity.Usuario usuario = new Linq.Data.Entity.Usuario();
                DcGeneralDataContext usa = new DcGeneralDataContext();
                var encrippass = EncriptarContra.Encriptar(txtContra.Text);
                var user = usa.Usuario.FirstOrDefault(p => p.usuario1 == txtUser.Text && p.passw == encrippass.ToString() && p.idEstado ==1);
                //if (user.usuario1 == txtUser.Text && user.passw == encrippass)
                var estadobloq = usa.Usuario.FirstOrDefault(p => p.usuario1 == txtUser.Text && p.passw == encrippass.ToString() && p.idEstado == 2);
                var estadocan = usa.Usuario.FirstOrDefault(p => p.usuario1 == txtUser.Text && p.passw == encrippass.ToString() && p.idEstado == 3);
                if(user != null)
                {
                    if(estadobloq != null || estadocan != null)
                    {
                        this.lblmsj.Text = "El usuario se encuentra cancelado o bloqueado";
                    }
                    else { 

                    Session["id"] = user.id;
                    this.Response.Redirect("~/Inicio.aspx");
                    }
                }
                else
                {
                    this.lblmsj.Text = "El usuario o contrasñea son incorrectos";
                }
            }
            catch (Exception ex)
            {
                this.lblmsj.Text = ex.Message;
            }
        }
    }
}