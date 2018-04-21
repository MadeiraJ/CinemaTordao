using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Trabalho_IS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/filmes.xml"));

            Image[] destaque = { destaque1, destaque2, destaque3, destaque4, destaque5 };

            XmlNodeList elemList1 = doc.SelectNodes("/filmes/Em_cartaz/filme/imgDestaque");
            for (int i = 0; i < elemList1.Count; i++)
            {
                destaque[i].ImageUrl = "./images/" + elemList1[i].InnerXml;
            }

            Label[] nDestaque = { nDestaque1, nDestaque2, nDestaque3, nDestaque4, nDestaque5 };

            XmlNodeList elemList2 = doc.SelectNodes("/filmes/Em_cartaz/filme/titulo");
            for (int i = 0; i < elemList2.Count; i++)
            {
                nDestaque[i].Text = elemList2[i].InnerText;
            }

            Image[] iMaisVistos = { maisVisto1, maisVisto2, maisVisto3, maisVisto4, maisVisto5, maisVisto6 };

            XmlNodeList elemList3 = doc.SelectNodes("/filmes/Mais_vistos/filme/img");
            for (int i = 0; i < elemList3.Count; i++)
            {
                iMaisVistos[i].ImageUrl = "./images/" + elemList3[i].InnerXml;
            }

            Literal[] nVistos = { nVisto1, nVisto2, nVisto3, nVisto4, nVisto5, nVisto6 };

            XmlNodeList elemList4 = doc.SelectNodes("/filmes/Mais_vistos/filme/titulo");
            for (int i = 0; i < elemList4.Count; i++)
            {
                nVistos[i].Text = elemList4[i].InnerText;
            }

            Literal[] generos = { genero1, genero2, genero3, genero4, genero5, genero6 };

            XmlNodeList elemList5 = doc.SelectNodes("/filmes/Mais_vistos/filme");
            for (int i = 0; i < elemList5.Count; i++)
            {
                generos[i].Text = elemList5[i].Attributes[0].Value;
            }

            Literal[] descricoes = { descricao1, descricao2, descricao3, descricao4, descricao5, descricao6 };

            XmlNodeList elemList6 = doc.SelectNodes("/filmes/Mais_vistos/filme/descricao");
            for (int i = 0; i < elemList6.Count; i++)
            {
                descricoes[i].Text = elemList6[i].InnerText;
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("reserva.aspx");
        }
    }
}