using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;
using UTTT.Ejemplo.Persona.Control;
using UTTT.Ejemplo.Persona.Control.Ctrl;

namespace UTTT.Ejemplo.Persona
{
    public partial class RecuperarContra : System.Web.UI.Page
    {
        private SessionManager session = new SessionManager();
        private int idPersona = 0;
        private UTTT.Ejemplo.Linq.Data.Entity.Usuario dbs;
        private DcGeneralDataContext DcG = new DcGeneralDataContext();


        protected void Page_Load(object sender, EventArgs e)
        {
            string valor = Convert.ToString(Request.QueryString["token"]);
            var token = valor;
            if (token == null)
            {
                this.Response.Redirect("~/Login.aspx");
            }
            else
            {
                idPersona = 1;
            }
            try
            {
                var por = token.ToString();
                this.Response.Buffer = true;
                this.dbs = DcG.GetTable<Linq.Data.Entity.Usuario>().First(c => c.token == por.ToString());
                if (!this.IsPostBack)
                {
                    if (this.session.Parametros["baseEntity"] == null)
                    {
                        this.session.Parametros.Add("baseEntity", this.dbs);
                    }
                    if (this.idPersona == 0)
                    {
                    }
                    else
                    {
                        this.txtUser.Text = this.dbs.usuario1;
                    }
                }

            }
            catch (Exception _e)
            {
                this.showMessage("Ha ocurrido un problema al cargar la página" + _e.Message);
                this.showMessageException(_e.Message);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcontra.Text == txtrecontra.Text && txtrecontra.Text == txtcontra.Text)
                {

                    string valor = Convert.ToString(Request.QueryString["token"]);
                    var por = valor;
                    this.dbs = DcG.GetTable<Linq.Data.Entity.Usuario>().First(c => c.token == por.ToString());
                    DcGeneralDataContext Guardar = new DcGeneralDataContext();
                    UTTT.Ejemplo.Linq.Data.Entity.Usuario usuario = new Linq.Data.Entity.Usuario();
                    if (DcG != null)
                    {
                        usuario = Guardar.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Usuario>().First(c => c.token == por.ToString());
                        var contra = EncriptarContra.Encriptar(txtcontra.Text);
                        usuario.passw = contra.ToString().Trim();
                        Guardar.SubmitChanges();
                        FormsAuthentication.SignOut();
                        Session.Abandon();
                        this.Response.Redirect("~/Login.aspx");
                    }
                }
                else
                {
                    this.lblmsj.Text = "los campos contraseñas deben ser iguales";
                }
            }
            catch (Exception ex)
            {
                this.showMessage(ex.Message);
            }
        }
    }
}