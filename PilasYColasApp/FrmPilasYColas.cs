using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PilasYColasApp.clases.implementaciones;

namespace PilasYColasApp
{
    public partial class FrmPilasYColas : Form
    {
        Pila pila = new Pila(10);
        Cola cola = new Cola();
        public FrmPilasYColas()
        {
            InitializeComponent();
        }

        void cargarPila()
        {
            LbxPila.Items.Clear();
            for (int i = 0; i < pila.oPila.Length; i++)
            {
                if (pila.oPila[i] != null)
                    LbxPila.Items.Add(pila.oPila[i]);
            }
        }
        void cargarCola()
        {
            LbxCola.Items.Clear();
            for (int i = 0; i < cola.oCola.Count; i++)
            {
                if (cola.oCola[i] != null)
                    LbxCola.Items.Add(cola.oCola[i]);
            }
        }
        private void BtnAñadirPila_Click(object sender, EventArgs e)
        {
            pila.añadir(TbxPila.Text);
            cargarPila();
        }

        private void BtnPrimeroPila_Click(object sender, EventArgs e)
        {
            if(pila.primero() != null)
                MessageBox.Show("El primer item es: "+(string)pila.primero(), "Info", MessageBoxButtons.OK);
            else
                MessageBox.Show("No hay primer item", "Error", MessageBoxButtons.OK);
        }

        private void BtnExtraerPila_Click(object sender, EventArgs e)
        {
            if (pila.primero() != null)
                MessageBox.Show("El primer item extraido es: " + (string)pila.extraer(), "Info", MessageBoxButtons.OK);
            else
                MessageBox.Show("No hay primer item", "Error", MessageBoxButtons.OK);
            cargarPila();
        }

        private void BtnVaciaPila_Click(object sender, EventArgs e)
        {
            if (pila.estaVacia())
                MessageBox.Show("La pila esta vacia", "Info", MessageBoxButtons.OK);
            else
                MessageBox.Show("La pila NO esta vacia", "Info", MessageBoxButtons.OK);
        }

        private void BtnAñadirCola_Click(object sender, EventArgs e)
        {
            cola.añadir(TbxCola.Text);
            cargarCola();
        }

        private void BtnPrimeroCola_Click(object sender, EventArgs e)
        {
            if (cola.primero() != null)
                MessageBox.Show("El primer item es: " + (string)cola.primero(), "Info", MessageBoxButtons.OK);
            else
                MessageBox.Show("No hay primer item", "Error", MessageBoxButtons.OK);
        }

        private void BtnExtraerCola_Click(object sender, EventArgs e)
        {
            if (cola.primero() != null)
                MessageBox.Show("El primer item extraido es: " + (string)cola.extraer(), "Info", MessageBoxButtons.OK);
            else
                MessageBox.Show("No hay primer item", "Error", MessageBoxButtons.OK);
            cargarCola();

        }

        private void BtnVaciaCola_Click(object sender, EventArgs e)
        {
            if (cola.estaVacia())
                MessageBox.Show("La cola esta vacia", "Info", MessageBoxButtons.OK);
            else
                MessageBox.Show("La cola NO esta vacia", "Info", MessageBoxButtons.OK);
        }
    }
}
