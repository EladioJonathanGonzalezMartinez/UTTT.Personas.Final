using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;
using UTTT.Ejemplo.Persona.Control.Ctrl;

namespace UTTT.Ejemplo.Persona
{
    public partial class Recuperar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        UTTT.Ejemplo.Linq.Data.Entity.Usuario usuario = new Linq.Data.Entity.Usuario();
        DcGeneralDataContext usa = new DcGeneralDataContext();
        private UTTT.Ejemplo.Linq.Data.Entity.Usuario db;
        private DcGeneralDataContext dcGlobal = new DcGeneralDataContext();
        protected void Button1_Click(object sender, EventArgs e)
        {
            try { 
            var em = usa.Persona.FirstOrDefault(p => p.strCorreoE == txtCorre.Text );
            if (em != null)
            {
               
                        DcGeneralDataContext Guardar = new DcGeneralDataContext();
                        EncripMD5("124578");
                        string toke = GenerarToken();
                        string corre = txtCorre.Text;
                        var usuar = dcGlobal.Usuario.FirstOrDefault(p => p.idPersona == em.id);
                        EnviarCorreo(toke, corre);
                        if(usuar != null)
                        {
                            usuario = Guardar.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Usuario>().First(c => c.id == usuar.id);
                            var por = toke;
                            Session["abc"] = por.ToString().Trim();
                            usuario.token = por.ToString().Trim();
                            var net = Session["abc"].ToString();
                            Guardar.SubmitChanges();
                            this.Response.Redirect("~/UsuarioPrincipal.aspx", false);
                        }


                    
                    else
                    {
                        this.showMessage("Este correo no esta registrado");
                    }
            }
            }
            catch(Exception _e)
            {
                this.lblmsj.Text = _e.Message;
            }
        }
        public static string EncripMD5(string word)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(word));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        public void EnviarCorreo(string tokens, string correo)
        {
            string EmailOrigen = "jonar1417@gmail.com";
            string EmailDestino = correo;
            string contra = "pros1234";

            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Cambio de contraseña", "http://www.ejonathanut.somee.com/RecuperarContra.aspx" + "?token=" + tokens);
            oMailMessage.IsBodyHtml = true;
            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, contra);
            oSmtpClient.Send(oMailMessage);

            oMailMessage.Dispose();
        }
        public static string GenerarToken()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray()) i *= ((int)b + 1);
            return EncripMD5(string.Format("{0:x}", i - DateTime.Now.Ticks));
        }
    }
}