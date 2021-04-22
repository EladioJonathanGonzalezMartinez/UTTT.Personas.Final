using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;
using UTTT.Ejemplo.Persona.Control;
using UTTT.Ejemplo.Persona.Control.Ctrl;

namespace UTTT.Ejemplo.Persona
{
    public partial class UsuarioManager : System.Web.UI.Page
    {
        private SessionManager session = new SessionManager();
        private int idPersona = 0;
        private UTTT.Ejemplo.Linq.Data.Entity.Usuario baseEntity;
        private DataContext dcGlobal = new DcGeneralDataContext();
        private int tipoAccion = 0;
        string mensaje;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                this.Response.Redirect("~/Login.aspx");
            }
            this.lblmsj.Text = "";
            try
            {
                this.Response.Buffer = true;
                this.session = (SessionManager)this.Session["SessionManager"];
                this.idPersona = this.session.Parametros["idPersona"] != null ?
                    int.Parse(this.session.Parametros["idPersona"].ToString()) : 0;
                if (this.idPersona == 0)
                {
                    this.baseEntity = new Linq.Data.Entity.Usuario();
                    this.tipoAccion = 1;

                }
                else
                {

                    this.tipoAccion = 2;
                }

                if (!this.IsPostBack)
                {
                    if (this.session.Parametros["baseEntity"] == null)
                    {
                        this.session.Parametros.Add("baseEntity", this.baseEntity);
                    }

                    if (this.idPersona == 0)
                    {
                        this.lblmsj.Text = "Agregar";
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception _e)
            {
                this.showMessage("Ha ocurrido un problema al cargar la página" + _e.Message);
                this.Response.Redirect("~/PersonaPrincipal.aspx", false);
                this.showMessageException(_e.Message);
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            this.lblmsj.Text = "";
            try
            {
                DataContext dcGuardar = new DcGeneralDataContext();
                UTTT.Ejemplo.Linq.Data.Entity.Usuario user = new Linq.Data.Entity.Usuario();
                DcGeneralDataContext usa = new DcGeneralDataContext();
                var idp = int.Parse(this.ddlPersona.Text);
                var perso = usa.Usuario.FirstOrDefault(p => p.idPersona == idp);
                if (this.idPersona == 0)
                {
                    if (txtcontra.Text != txtrecontra.Text)
                    {
                        this.lblmsj.Text = "los 2 campos de password deben ser iguales";
                    }
                    else if (user.usuario1 == txtuser.Text)
                    {
                        this.lblmsj.Text = "Este usuario ya existe";
                    }
                    else if (user.usuario1 != txtuser.Text && perso == null)
                    {
                        user.usuario1 = this.txtuser.Text.Trim();
                        user.idPersona = int.Parse(this.ddlPersona.Text);
                        var contra = EncriptarContra.Encriptar(txtcontra.Text);
                        user.passw = contra.ToString().Trim();
                        user.fecha = DateTime.ParseExact(this.txtDate.Text,"dd/MM/yyyy", null);
                        //persona.dteFecha = DateTime.Parse(this.txtDate.Text);
                        user.idEstado = 1;
                        dcGuardar.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Usuario>().InsertOnSubmit(user);
                        dcGuardar.SubmitChanges();
                        this.showMessage("El registro se agrego correctamente.");
                        this.Response.Redirect("~/UsuarioPrincipal.aspx", false);
                    }
                    else
                    {
                        this.lblmsj.Text = "esta persona ya esta siendo usada";
                    }
                }
                if (this.idPersona > 0)
                {

                }
            }
            catch (Exception _e)
            {
                this.showMessageException(_e.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/UsuarioPrincipal.aspx");
        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {

        }

        protected void ddlPersona_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
