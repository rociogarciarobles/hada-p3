using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Read_Click(object sender, EventArgs e)
        {
            ENProduct enu = new ENProduct();
            enu.code = code.Text;
            if (enu.readProduct())
            {
                code.Text = enu.code;
                name.Text = enu.name;
                amount.Text = enu.amount.ToString();
                price.Text = enu.price.ToString();   //INCLUIDO price category y  creationDate
                creationDate.Text = enu.creationDate.ToString();
                category.Text = enu.category.ToString();
            
            }
            else
            {
                label1.Text = "Error, no se encuentra al Product.";
            }
        }

        protected void Read_First_Click(object sender, EventArgs e)
        {
            ENProduct enu = new ENProduct();
            if (enu.readFirstProduct())
            {
                code.Text = enu.code;
                name.Text = enu.name;
                amount.Text = enu.amount.ToString();
                price.Text = enu.price.ToString();   //INCLUIDO price category y  creationDate
                creationDate.Text = enu.creationDate.ToString();
                category.Text = enu.category.ToString();
            }
            else
            {
                label1.Text = "Error, la base de datos está vacía";
            }
        }

        protected void Read_Next_Click(object sender, EventArgs e)
        {
            ENProduct enu = new ENProduct();
            enu.code = code.Text;
            if (enu.readNextProduct())
            {
                code.Text = enu.code;
                name.Text = enu.name;
                amount.Text = enu.amount.ToString();
                price.Text = enu.price.ToString();   //INCLUIDO price category y  creationDate
                creationDate.Text = enu.creationDate.ToString();
                category.Text = enu.category.ToString();
            }
            else
            {
                label1.Text = "Error, la base de datos está vacía";
            }
        }
        protected void Read_Prev_Click(object sender, EventArgs e)
        {
            ENProduct enu = new ENProduct();
            enu.code = code.Text;
            if (enu.readPrevProduct())
            {
                code.Text = enu.code;
                name.Text = enu.name;
                amount.Text = enu.amount.ToString();
                price.Text = enu.price.ToString();   //INCLUIDO price category y  creationDate
                creationDate.Text = enu.creationDate.ToString();
                category.Text = enu.category.ToString();
            }
            else
            {
                label1.Text = "Error, la base de datos está vacía";
            }
        }
        protected void Create_Click(object sender, EventArgs e)
        {
            if (code.Text == "" || name.Text == "" || amount.Text == "" || price.Text == "" || creationDate.Text == "" || category.Text == "")
            {
                label1.Text = "Completa todos los campos antes de crear un Product por favor";
            }
            else
            {

                ENProduct enu = new ENProduct();
                enu.code = code.Text;
                enu.name = name.Text;
                enu.amount = int.Parse(amount.Text);
                enu.price = float.Parse(price.Text);  //INCLUIDO price category y  creationDate
                enu.creationDate = DateTime.Parse(creationDate.Text);
                enu.category = int.Parse(category.Text);
                if (enu.createProduct())
                {
                    label1.Text = "Creado Product.";
                }
                else
                {
                    label1.Text = "Error, no se ha podido crear.";
                }
            }
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            ENProduct enu = new ENProduct();
            enu.code = code.Text;
            enu.name = name.Text;
            enu.amount = int.Parse(amount.Text);
            enu.price = float.Parse(price.Text);  //INCLUIDO price category y  creationDate
            enu.creationDate = DateTime.Parse(creationDate.Text);
            enu.category = int.Parse(category.Text);
            if (enu.updateProduct())
            {
                label1.Text = "Actualizado Product.";
            }
            else
            {
                label1.Text = "Error, no se ha podido actualizar.";
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            ENProduct enu = new ENProduct();
            enu.code = code.Text;
            if (enu.deleteProduct())
            {
                code.Text = "";
                name.Text = "";
                amount.Text = "";
                price.Text = "";
                creationDate.Text = "";//INCLUIDO price category y  creationDate
                category.Text = "";
                label1.Text = "Eliminado Product.";
            }
            else
            {
                label1.Text = "Error, no se ha podido eliminar.";
            }
        }
    }
}