﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programacion_3
{
    public partial class frmCategorias : Form

    {
        private List<Categoria> listaCategoria;
        public frmCategorias()
        {
            InitializeComponent();
            //Fondo para la app
            Bitmap img = new Bitmap(Application.StartupPath + @"/Fondo/backgrounds.jpg");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;   //para que sea ajustable en tamaño
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMarcas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            CategoriasNegocio categoria = new CategoriasNegocio();
            listaCategoria = categoria.listar();
            dgvCategorias.DataSource = listaCategoria;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AgregarCategoria agregarCategoria = new AgregarCategoria();
            agregarCategoria.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                CategoriasNegocio negocio = new CategoriasNegocio();
                Categoria seleccionado;
                try
                {
                    seleccionado = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                    DialogResult respuesta = MessageBox.Show("¿Eliminar el registro " + seleccionado.Nombre + "?", "Eliminar categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        negocio.eliminar(seleccionado.IDCategoria);
                        MessageBox.Show("Se ha eliminado la categoría.");
                        //cargar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar la categoría a eliminar.");
            }
        }
    }
}
