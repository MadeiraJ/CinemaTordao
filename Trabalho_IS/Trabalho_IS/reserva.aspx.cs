using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Trabalho_IS
{
    public partial class reserva : System.Web.UI.Page
    {
        int sala1;
        int lugarEscolhido;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (var dc = new Trabalho_IS1Entities4())
                {
                    var filmes = dc.Filmes.SqlQuery("SELECT * FROM Filmes").ToList();
                    filmesSelecao.Items.Clear();
                    selecaoDia.Items.Clear();
                    SelecaoSessao.Items.Clear();

                    for (int i = 0; i < filmes.Count; i++)
                    {
                        ListItem listItem = new ListItem();
                        listItem.Text = filmes[i].nome_filme;
                        filmesSelecao.Items.Add(listItem);
                    }

                    for (int i = 0; i < 7; i++)
                    {
                        var hoje = DateTime.Now;
                        var datazinha = hoje.AddDays(i);
                        ListItem listItem = new ListItem();
                        listItem.Text = datazinha.ToString("yyyy-MM-dd");
                        selecaoDia.Items.Add(listItem);
                    }
                }

            }
            atualizarHoras(sender, e);
        }

        protected void atualizarHoras(object sender, EventArgs e)
        {
            using (var dc = new Trabalho_IS1Entities4())
            {
                SelecaoSessao.Items.Clear();
                var query = "SELECT * FROM Filmes_sala" +
                    " inner join Filmes on Filmes_Sala.id_filme = Filmes.id_filme" +
                    $" where Filmes.nome_filme='{filmesSelecao.SelectedValue}'" +
                    $" and data=CONVERT(DATETIME, '{selecaoDia.SelectedValue}', 111)";

                var reservas = dc.Filmes_Sala.SqlQuery(query).ToList();

                for (int j = 0; j < reservas.Count; j++)
                {
                    ListItem listItem = new ListItem();
                    listItem.Text = reservas[j].hora.Value.ToString("hh:mm");
                    SelecaoSessao.Items.Add(listItem);
                }
                desenharCadeiras(sender, e);
            }
        }

        protected void desenharCadeiras(object sender, EventArgs e)
        {
            using (var dc = new Trabalho_IS1Entities4())
            {
                var query = "SELECT * from Filmes, Filmes_Sala" +
                     " inner join Reservas" +
                     " on Reservas.id_filme_sala = Filmes_Sala.id_filme_sala" +
                     $" where Filmes.nome_filme='{filmesSelecao.SelectedValue}'" +
                     $" and Filmes_Sala.data=CONVERT(DATETIME, '{selecaoDia.SelectedValue}', 111)";

                var reservas = dc.Reservas.SqlQuery(query).ToList();

                query = "SELECT * from Filmes, Salas" +
                  " inner join Filmes_Sala" +
                  " on Filmes_Sala.id_sala = Salas.id_sala" +
                  " where Filmes_Sala.id_filme=Filmes.id_filme" +
                  $" and Filmes.nome_filme='{filmesSelecao.SelectedValue}'";

                var sala = dc.Salas.SqlQuery(query).ToList();

                imagens.Controls.Clear();
                if (SelecaoSessao.Items.Count > 0 && sala.Count > 0)
                {
                    sala1 = sala[0].id_sala;
                    for (int i = 0; i < sala[0].lotacao; i++)
                    {
                        ImageButton imagem = new ImageButton();
                        imagem.ImageUrl = "images/cadeira.png";

                        imagem.Click += Cadeira_Click;

                        imagem.CssClass = "cadeira";

                        for (int j = 0; j < reservas.Count; j++)
                            if (reservas[j].lugar.Equals(i))
                                imagem.CssClass = "cadeira indisponivel";

                        imagens.Controls.Add(imagem);
                    }
                }
            }
        }

        protected void MandarMail_Click(object sender, EventArgs e)
        {
            String nome = Nome.Text;
            String telefone = nTelefone.Text;
            String mail = Mail.Text;

            Random a = new Random();
            String r = "";

            for (int i = 1; i < 9; i++)
                r += a.Next(0, 9).ToString();


            DateTime data1 = Convert.ToDateTime(selecaoDia.SelectedValue);
            DateTime horainicio = Convert.ToDateTime(SelecaoSessao.SelectedValue);

            String caminhoLogo = Server.MapPath("images/logo.jpg");
            String conteudoMail =
                $"<div style=\"padding-top: 10px; padding-left: 10px;\"><img src='{caminhoLogo}'@>" +
                $"<p>Olá {nome}!</p>" +
                "<br>" +
                $"<p> A comunidade Tordão lembra-o para poder ver conosco o filme {filmesSelecao.SelectedValue} " +
                $" no dia {data1.ToString("dd/MM/yyyy")} às {horainicio.ToString("hh:mm")}, terá que" +
                $" pagar a sua compra via multibanco, através da referência {r}. " +
                $"Não se esqueça, guardamos-lhe o melhor lugar (lugar: {lugarEscolhido})!." +
                "<br>" +
                "<p> Cumprimentos cinemáticos,</p>" +
                "<p> Cinema Tordão </p>" +
                "</div>";

            /*LinkedResource logo = new LinkedResource(caminhoLogo);
            logo.ContentId = "idLogo";
            AlternateView av1 = AlternateView.CreateAlternateViewFromString(conteudoMail, null, MediaTypeNames.Text.Html);
            av1.LinkedResources.Add(logo);*/
            try
            {
                MailMessage email = new MailMessage();
                email.From = new MailAddress("cinematordao@hotmail.com");
                email.To.Add(mail);
                email.Subject = "Cinema Tordão";
                email.Body = conteudoMail;
                //email.AlternateViews.Add(av1);

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.live.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                email.IsBodyHtml = true;
                //smtp.Credentials = new NetworkCredential("hula_hula_oh@hotmail.com", "#123456A");
                smtp.Credentials = new NetworkCredential("cinematordao@hotmail.com", "#123456A");
                smtp.Send(email);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                    $"alert('Oops ocorreu um erro! Lamentamos muito, o erro é:\n{ex}')", true);
            }
        

        int filme;

            using (var dc = new Trabalho_IS1Entities4())
            {
                XmlDocument doc = new XmlDocument();
    XmlNode filmes = doc.CreateElement("filmes");
    doc.AppendChild(filmes);

                var Listafilmes = dc.Filmes.SqlQuery("SELECT * FROM Filmes").ToList();
                for (int i = 0; i<Listafilmes.Count; i++)
                {
                    XmlNode _filme = doc.CreateElement("filme");
    XmlAttribute _id = doc.CreateAttribute("id_filme");
    _id.Value = Listafilmes[i].id_filme.ToString();
                    _filme.Attributes.Append(_id);

                    XmlAttribute _nome = doc.CreateAttribute("nome_filme");
    _nome.Value = Listafilmes[i].nome_filme.ToString();
                    _filme.Attributes.Append(_nome);

                    XmlAttribute _duracao = doc.CreateAttribute("duracao");
    _duracao.Value = Listafilmes[i].duracao.ToString();
                    _filme.Attributes.Append(_duracao);

                    filmes.AppendChild(_filme);
                }

doc.PreserveWhitespace = true;

                string uploadPath = Server.MapPath("");
doc.Save(Path.Combine(uploadPath, "filmesData.xml"));

                var query = $"SELECT * FROM Filmes where Filmes.nome_filme='{filmesSelecao.SelectedValue}'";
var res = dc.Filmes.SqlQuery(query).ToList();
filme = res[0].id_filme;

                query = "SELECT * from Filmes_Sala where" +
                       $" id_filme={filme} and id_sala={sala1}" +
                       $" and data = CONVERT(DATETIME, '{selecaoDia.SelectedValue}', 111) and hora= CONVERT(DATETIME, '{SelecaoSessao.SelectedValue}', 102)";
                var res2 = dc.Filmes_Sala.SqlQuery(query).ToList();
Reservas res1 = new Reservas
{
    id_filme_sala = res2[0].id_filme_sala,
    email = mail,
    nome = nome,
    referencia = Convert.ToInt32(r),
    telefone = Convert.ToInt32(telefone),
    lugar = lugarEscolhido
};
dc.Reservas.Add(res1);
                dc.SaveChanges();
            }

        }

        protected void Cadeira_Click(object sender, ImageClickEventArgs e)
{
    ImageButton imagemzinha = (ImageButton)sender;
    if (imagemzinha.CssClass.ToString().Contains("escolhido"))
        imagemzinha.CssClass = "cadeira";

    else
    {
        imagemzinha.Attributes["class"] = "cadeira escolhido";
        lugarEscolhido = (imagens.Controls.IndexOf(imagemzinha));
    }
}
    }

}