using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cajero
{
    
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int m, mx, my;
        string User = "admin", Pass = "password";

        #region Comportamiento del Botón Cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void panelCerrar_MouseEnter(object sender, EventArgs e)
        {
            panelCerrar.BackColor = Color.Red;
            btnCerrar.BackColor = Color.Red;

        }
        private void panelCerrar_MouseLeave(object sender, EventArgs e)
        {
            panelCerrar.BackColor = Color.FromArgb(57, 47, 90);
            btnCerrar.BackColor = Color.FromArgb(57, 47, 90);
        }
        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            panelCerrar.BackColor = Color.Red;
            btnCerrar.BackColor = Color.Red;
        }

        #endregion

        #region Comportamiento del Botón Minimizar
        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void panelMini_MouseEnter(object sender, EventArgs e)
        {
            panelMini.BackColor = Color.FromArgb(112, 95, 171);
            btnMini.BackColor = Color.FromArgb(112, 95, 171);
        }
        private void panelMini_MouseLeave(object sender, EventArgs e)
        {
            panelMini.BackColor = Color.FromArgb(57, 47, 90);
            btnMini.BackColor = Color.FromArgb(57, 47, 90);
        }
        private void btnMini_MouseEnter(object sender, EventArgs e)
        {
            panelMini.BackColor = Color.FromArgb(112, 95, 171);
            btnMini.BackColor = Color.FromArgb(112, 95, 171);
        }
        private void btnMini_MouseDown(object sender, MouseEventArgs e)
        {
            panelMini.BackColor = Color.YellowGreen;
            btnMini.BackColor = Color.YellowGreen;
        }
        private void btnMini_MouseUp(object sender, MouseEventArgs e)
        {
            panelMini.BackColor = Color.FromArgb(57, 47, 90);
            btnMini.BackColor = Color.FromArgb(57, 47, 90);
        }

        #endregion

        #region Control de Movimiento de Ventana
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        #endregion

        #region Comportamiento de Campo Usuario
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = SystemColors.WindowFrame;
            }
        }
        #endregion

        #region Comportamiento del Campo Contraseña
        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.Black;
                txtPass.UseSystemPasswordChar = true;
            }
        }
        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = SystemColors.WindowFrame;
                txtPass.UseSystemPasswordChar = false;
            }
        }      
        #endregion

        #region Centrar paneles decorativos
        private void Form1_Load(object sender, EventArgs e)
        {
            Clases.centraXY(panel6, panel5);
            Clases.centraXY(panel5, panel2);

        }
        #endregion

        #region Ejecucion del funcionamiento del Botón Acceder
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "USUARIO")
            {
                if (txtPass.Text != "CONTRASEÑA")
                {
                    MenuPrincipal Menu = new MenuPrincipal();
                    if (txtUsuario.Text == User)
                    {
                        if (txtPass.Text == Pass)
                        {
                            Menu.Show();
                            this.Hide();
                        }
                        else msgError("Contraseña Incorrecta");
                    }
                    else msgError("Usuario Incorrecto");

                }
                else msgError("Por favor ingrese Su Contraseña");
            }
            else msgError("Por favor ingrese Su Nombre de Usuario");
            
        }
        #endregion

        #region Formato y alineación del Mensaje de Error
        private void msgError(string msg)
        {
            lblErrMsg.Text = "     " + msg;
            Clases.centraX(panel2, lblErrMsg);
            lblErrMsg.Visible = true;
        }
        #endregion

        private void linkRestContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            msgError("Contraseña por defecto es 'password'");
        }

    }
}
