using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Cajero
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            
        }
        
        # region"Variables para Movimiento de Ventana"
        int m, mx, my;
        #endregion

        #region"Variables para Control de Punto decimal y Decimales permitidos"
        int contPuntos;
        int NoDecimales;
        int? cantDigitos = null;
        #endregion

        // Variable general de saldo
        decimal saldo;
        
        #region"Variables para registro de Movimientos"
        int NoMovs = 0;
        string RegMov;
        List<string> Movimientos = new List<string>();
        #endregion

        #region Funciones para el RichTextBox de Informacion
        private void restaurarRtb()
        {
            rtbDatos.Text = "BIENVENIDO A SU CAJERO DE CONFIANZA";
            rtbDatos.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void centrarTextRtb()
        {
            rtbDatos.SelectionAlignment = HorizontalAlignment.Center;
        }
        #endregion

        #region Inicializar variables, campos y ventanas
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            saldo = 4000.00m;
            panelRest.Visible = false;

            panelRetirar.Visible = false;
            Clases.centraX(panelMenu, rtbDatos);
            contPuntos = 0;
            restaurarRtb();
        }
        #endregion

        private void MenuPrincipal_Resize(object sender, EventArgs e)
        {
            Clases.centraX(panelMenu, rtbDatos);
            Clases.centraX(panelMenu, panelRetirar);
        }

        #region "Movimiento de Ventana"
        private void panelEncabezado_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;

        }
        private void panelEncabezado_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }
        private void panelEncabezado_MouseUp(object sender, MouseEventArgs e) => m = 0;
        #endregion

        #region "Boton Cerrar"
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void panelCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
            panelCerrar.BackColor = Color.Red;
        }
        private void panelCerrar_MouseEnter(object sender, EventArgs e)
        {
            panelCerrar.BackColor = Color.Red;
            btnCerrar.BackColor = Color.Red;
        }
        private void panelCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Black;
            panelCerrar.BackColor = Color.Black;
        }
        #endregion

        #region"Boton Maximizar"
        private void btnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panelRest.Visible = true;
            panelMax.Visible = false;
        }
        private void panelMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panelRest.Visible = true;
            panelMax.Visible = false;
        }
        private void btnMax_MouseEnter(object sender, EventArgs e)
        {
            btnMax.BackColor = Color.DimGray;
            panelMax.BackColor = Color.DimGray;
        }
        private void panelMax_MouseEnter(object sender, EventArgs e)
        {
            panelMax.BackColor = Color.DimGray;
            btnMax.BackColor = Color.DimGray;
        }
        private void panelMax_MouseLeave(object sender, EventArgs e)
        {
            btnMax.BackColor = Color.Black;
            panelMax.BackColor = Color.Black;
        }     
        private void btnMax_MouseDown(object sender, MouseEventArgs e)
        {
            btnMax.BackColor = Color.GreenYellow;
            panelMax.BackColor = Color.GreenYellow;
        }
        private void btnMax_MouseUp(object sender, MouseEventArgs e)
        {
            btnMax.BackColor = Color.Black;
            panelMax.BackColor = Color.Black;
        }
        private void panelMax_MouseDown(object sender, MouseEventArgs e)
        {
            panelMax.BackColor = Color.GreenYellow;
            btnMax.BackColor = Color.GreenYellow;
        }
        private void panelMax_MouseUp(object sender, MouseEventArgs e)
        {
            panelMax.BackColor = Color.Black; 
            btnMax.BackColor = Color.Black;
        }
        #endregion

        #region"Boton Restaurar"
        private void btnRest_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            panelMax.Location = panelRest.Location;
            panelRest.Visible = false;
            panelMax.Visible = true;
        }
        private void panelRest_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            panelMax.Location = panelRest.Location;
            panelRest.Visible = false;
            panelMax.Visible = true;
        }
        private void btnRest_MouseEnter(object sender, EventArgs e)
        {
            btnRest.BackColor = Color.DimGray;
            panelRest.BackColor = Color.DimGray;
        }
        private void panelRest_MouseEnter(object sender, EventArgs e)
        {
            btnRest.BackColor = Color.DimGray;
            panelRest.BackColor = Color.DimGray;
        }
        private void panelRest_MouseLeave(object sender, EventArgs e)
        {
            panelRest.BackColor = Color.Black;
            btnRest.BackColor = Color.Black;
        }
        private void btnRest_MouseDown(object sender, MouseEventArgs e)
        {
            btnRest.BackColor = Color.YellowGreen;
            panelRest.BackColor = Color.YellowGreen;
        }
        private void panelRest_MouseDown(object sender, MouseEventArgs e)
        {
            btnRest.BackColor = Color.YellowGreen;
            panelRest.BackColor = Color.YellowGreen;
        }
        private void btnRest_MouseUp(object sender, MouseEventArgs e)
        {
            btnRest.BackColor = Color.Black;
            panelRest.BackColor = Color.Black;
        }
        private void panelRest_MouseUp(object sender, MouseEventArgs e)
        {
            btnRest.BackColor = Color.Black;
            panelRest.BackColor = Color.Black;
        }
        #endregion

        #region"Boton Minimizar"
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void panelMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnMin_MouseEnter(object sender, EventArgs e)
        {
            btnMin.BackColor = Color.DimGray;
            panelMin.BackColor = Color.DimGray;
        }
        private void panelMin_MouseEnter(object sender, EventArgs e)
        {
            btnMin.BackColor = Color.DimGray;
            panelMin.BackColor = Color.DimGray;
        }
        private void panelMin_MouseLeave(object sender, EventArgs e)
        {
            btnMin.BackColor = Color.Black;
            panelMin.BackColor = Color.Black;
        }
        private void btnMin_MouseDown(object sender, MouseEventArgs e)
        {
            btnMin.BackColor = Color.YellowGreen;
            panelMin.BackColor = Color.YellowGreen;
        }
        private void panelMin_MouseDown(object sender, MouseEventArgs e)
        {
            btnMin.BackColor = Color.YellowGreen;
            panelMin.BackColor = Color.YellowGreen;
        }
        private void btnMin_MouseUp(object sender, MouseEventArgs e)
        {
            btnMin.BackColor = Color.Black;
            panelMin.BackColor = Color.Black;
        }
        private void panelMin_MouseUp(object sender, MouseEventArgs e)
        {
            btnMin.BackColor = Color.Black;
            panelMin.BackColor = Color.Black;
        }


        #endregion

       
        /// <summary>
        /// Habilita el panel para realizar un retiro y oculta el rtbDatos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetirar_Click(object sender, EventArgs e)
        {
            panelRetirar.Location = rtbDatos.Location;
            panelRetirar.Size = rtbDatos.Size;
            panelRetirar.Visible = true;
            rtbDatos.Visible = false;
        }

        private void txtRetiro_Click(object sender, EventArgs e)
        {
            if (txtRetiro.Text == "Q0.00")
            {
                txtRetiro.Select(txtRetiro.Text.Length - 3, 0);
            }
        }

        private void txtRetiro_KeyDown(object sender, KeyEventArgs e)
        {
            char punto = Convert.ToChar(190);
            char val = Convert.ToChar(e.KeyValue);
            if (txtRetiro.Text == "Q0.00")
            {
                if (char.IsDigit(val))
                {
                    if (contPuntos != 1)
                    {
                        txtRetiro.Clear();
                    }
                }
                else 
                {
                   if (val == punto)
                    {
                        contPuntos = 0;
                    }
                    
                    txtRetiro.Text = "Q0.00";

                }
            }
        }

        private void txtRetiro_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRetiro.Text))
            {
                #region"Procedimiento para controlar los Decimales"
                // Evalua si  el usuario ya ha seleccionado el punto decimal
                if (contPuntos == 1)
                {
                    var valor = txtRetiro.Text;
                    var decimales = valor.Remove(valor.Length - 1, 1);

                    //Condicional y ciclo para controlar que no se excedan los decimales.
                    if (decimales.Length == cantDigitos)
                    {
                        switch (NoDecimales)
                        {
                            case 1:
                                txtRetiro.Text = decimales;
                                txtRetiro.Select(txtRetiro.Text.Length - 1, 0);
                                NoDecimales = 2;
                                break;
                            case 2:
                                txtRetiro.Text = decimales;
                                txtRetiro.Select(txtRetiro.Text.Length, 0);
                                NoDecimales = 3;
                                break;
                            case 3:
                                MessageBox.Show("Solo se permiten dos decimales");
                                txtRetiro.Text = decimales;
                                txtRetiro.Select(txtRetiro.Text.Length, 0);
                                NoDecimales = 3;
                                break;
                        }
                    }
                }
                #endregion

                #region"Procedimiento para controlar los enteros Sin Decimal"
                //Ingresa Mientras el usuario no haya presionado el Punto
                if (e.KeyValue != 190)
                {
                    //Evalua si el conteo de puntos es cero
                    if (contPuntos == 0)
                    {
                        decimal ValorMoneda = decimal.Parse(txtRetiro.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("es-GT"));
                        string decimalValue = ValorMoneda.ToString("G0");
                        CultureInfo culture = new CultureInfo("es-GT");
                        decimal valueBefore = Decimal.Parse(decimalValue, NumberStyles.AllowThousands);
                        txtRetiro.Text = String.Format(culture, "{0:c2}", valueBefore);
                        txtRetiro.Select(txtRetiro.Text.Length - 3, 0);
                    }
                }
                #endregion

                #region"Procedimiento para Eliminar el punto extra y establecer los enteros
                //Ingresa si la tecla presionada es el Punto
                if (e.KeyValue == 190)
                {
                    //Ingresa si la cantidad de puntos es menor a 1
                    if (contPuntos < 1)
                    {
                        var valorInicial = txtRetiro.Text;

                        //Elimina el punto Ingresado
                        var nwvalor = valorInicial.Remove(valorInicial.Length - 3, 1);
                        txtRetiro.Text = nwvalor;
                        txtRetiro.Select(txtRetiro.Text.Length - 2, 0);
                        contPuntos++;
                        NoDecimales = 1;
                        //Establece la cantidad de enteros para no exceder los decimales
                        cantDigitos = txtRetiro.Text.Length;
                    }
                }
                #endregion

                #region"Condicional para evaluar que el texto contenga el signo de moneda
                if (!txtRetiro.Text.Contains("Q"))
                {
                    MessageBox.Show("Por favor Vuelva a ingresar el valor Correcatamente");
                    var val = txtRetiro.Text;
                    txtRetiro.Text = val + "Q0.00";
                    txtRetiro.Select(txtRetiro.Text.Length - 3, 0);
                }
                #endregion
            }
            else
            {
                #region"Condicional para evaluar que exista el punto en el texto"
                if (!txtRetiro.Text.Contains("."))
                {
                    MessageBox.Show("Por favor Vuelva a ingresar el valor Correcatamente");
                    var val = txtRetiro.Text;
                    txtRetiro.Text = val + "Q0.00";
                    txtRetiro.Select(txtRetiro.Text.Length - 3, 0);
                }
                #endregion

                //Estado por defecto
                else
                {
                    txtRetiro.Text = "Q0.00";
                    txtRetiro.Select(txtRetiro.Text.Length - 3, 0);

                }
            }
            

        }

        /// <summary>
        /// Evento que controla la habilitacion de las teclas para que solo admita
        /// digitos, controles y puntos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRetiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                if (contPuntos ==0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
            else { e.Handled = true;}
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            restaurarRtb();
            
           decimal cntRetirar = decimal.Parse(txtRetiro.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("es-GT"));
            if (cntRetirar < saldo)
            {
                decimal retiro = saldo - cntRetirar;

                NoMovs++;
                RegMov = String.Format("Retiró: Q{0} de \nSaldo Anterior: Q{1}, \nResiduo: Q{2}", 
                    cntRetirar, saldo, retiro);
                saldo = retiro;
                Movimientos.Add(RegMov);

                DialogResult res = MessageBox.Show("Se ha Retirado Con Exito", "Retiro Exitoso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(res == DialogResult.OK)
                {
                    rtbDatos.Visible = true;
                    panelRetirar.Visible = false;
                    txtRetiro.Text = "Q0.00";
                    cantDigitos = 0;
                    contPuntos = 0;
                    NoDecimales = 0;
                }

            }
            else
            {
                DialogResult res = MessageBox.Show("La Cantidad Ingresada Excede El saldo Disponible", "Saldo Insuficiente", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (res == DialogResult.OK)
                {
                    txtRetiro.Text = "Q0.00";
                    contPuntos = 0;
                    NoDecimales = 0;
                }
            }
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            if (panelRetirar.Visible == true)
            {
                panelRetirar.Visible = false;
                rtbDatos.Visible = true;
            }
            rtbDatos.Text = "MOVIMIENTOS";
            centrarTextRtb();
            RegMov = "Consultó Movimientos";
            Movimientos.Add(RegMov);
            NoMovs++;
            for (int i = 0; i< NoMovs; i++)
            {
                
                rtbDatos.AppendText(String.Format("\n{0}. {1}.", (i + 1), Movimientos[i]));
            }
            
        }

        private void btnSaldo_Click(object sender, EventArgs e)
        {
            if (panelRetirar.Visible == true)
            {
                panelRetirar.Visible = false;
                rtbDatos.Visible = true;
            }
            
            rtbDatos.Text = $"Su saldo Actual es Q{saldo}.";
            RegMov = "Consultó Saldo";
            Movimientos.Add(RegMov);
            NoMovs++;
            centrarTextRtb();

        }
    }
}
