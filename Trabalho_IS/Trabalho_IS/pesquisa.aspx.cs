using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Trabalho_IS
{
    public partial class pesquisa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/filmes.xml"));

            XmlNodeList elemList1 = doc.SelectNodes("/filmes/Tudo/filme");

            Image[] iFilme = new Image[elemList1.Count];
            Literal[] titulo = new Literal[elemList1.Count];
            Literal[] generos = new Literal[elemList1.Count];
            Literal[] descricoes = new Literal[elemList1.Count];

            for (int i = 0; i < elemList1.Count; i++)
            {
                HtmlGenericControl div1 = new HtmlGenericControl("div");
                div1.Attributes.Add("class", "w3-third w3-margin-bottom");
                div1.Attributes.Add("style", "height:800px;");
                todosfilmes.Controls.Add(div1);

                HtmlGenericControl div2 = new HtmlGenericControl("div");
                div2.Attributes.Add("class", "w3-card-4");
                div2.Attributes.Add("style", "height:800px;");
                div1.Controls.Add(div2);

                Image imagem = new Image();
                imagem.Attributes.Add("class", "images");
                imagem.Attributes.Add("name", "iFilme" + i.ToString());
                imagem.ID = "iFilme" + i.ToString();
                div2.Controls.Add(imagem);
                iFilme[i] = imagem;

                HtmlGenericControl div3 = new HtmlGenericControl("div");
                div3.Attributes.Add("class", "w3-container");
                div2.Controls.Add(div3);

                HtmlGenericControl h1_1 = new HtmlGenericControl("h3");
                div3.Controls.Add(h1_1);

                Literal literal1 = new Literal();
                literal1.ID = "titulo" + i;
                h1_1.Controls.Add(literal1);
                titulo[i] = literal1;

                HtmlGenericControl p_1 = new HtmlGenericControl("p");
                p_1.Attributes.Add("class", "w3-opacity");
                div3.Controls.Add(p_1);

                Literal literal2 = new Literal();
                literal2.ID = "genero" + i;
                p_1.Controls.Add(literal2);
                generos[i] = literal2;

                HtmlGenericControl p_2 = new HtmlGenericControl("p");
                div3.Controls.Add(p_2);

                Literal literal3 = new Literal();
                literal3.ID = "descricao" + i;
                p_2.Controls.Add(literal3);
                descricoes[i] = literal3;

                HtmlGenericControl p_3 = new HtmlGenericControl("p");
                div3.Controls.Add(p_3);

                Button botao1 = new Button();
                botao1.Attributes.Add("class", "w3-button w3-light-grey w3-block");
                botao1.Text = "Reservar";
                botao1.Click += (sa, ea) =>
                {
                    Response.Redirect("reserva.aspx");
                };
                p_3.Controls.Add(botao1);
            }

            XmlNodeList elemList2 = doc.SelectNodes("/filmes/Tudo/filme/img");

            for (int i = 0; i < elemList2.Count; i++)
            {
                iFilme[i].ImageUrl = "./images/" + elemList2[i].InnerXml;
            }

            XmlNodeList elemList3 = doc.SelectNodes("/filmes/Tudo/filme/titulo");
            for (int i = 0; i < elemList3.Count; i++)
            {
                titulo[i].Text = elemList3[i].InnerText;
            }

            XmlNodeList elemList4 = doc.SelectNodes("/filmes/Tudo/filme");
            for (int i = 0; i < elemList4.Count; i++)
            {
                generos[i].Text = elemList4[i].Attributes[0].Value;
            }

            XmlNodeList elemList5 = doc.SelectNodes("/filmes/Tudo/filme/descricao");
            for (int i = 0; i < elemList5.Count; i++)
            {
                descricoes[i].Text = elemList5[i].InnerText;
            }
        }
    }
}