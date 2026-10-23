using S4_Compra;

namespace S4___Compra
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnCalcular_Click(object? sender, EventArgs e)
        {
            // Validar que el precio sea mayor a 0[cite: 5]
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                await DisplayAlertAsync("Error de Validación", "El precio unitario debe ser un número mayor a 0.", "OK");
                return; // No calcula nada[cite: 5]
            }

            int cantidad = (int)nudCantidad.Value;

            // Llamada al método de la clase estática[cite: 5]
            var resultado = CalculadoraCompra.Calcular(precio, cantidad);

            // Mostrar resultados en los labels
            lblSubtotal.Text = $"Subtotal: ${resultado.subtotal:F2}";
            lblDescuento.Text = $"Descuento: ${resultado.descuento:F2}";
            lblIva.Text = $"IVA 15%: ${resultado.iva:F2}";
            lblTotal.Text = $"TOTAL A PAGAR: ${resultado.total:F2}";
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            // Limpiar datos y restablecer valores[cite: 5, 6]
            txtPrecio.Text = string.Empty;
            nudCantidad.Value = 1;

            lblSubtotal.Text = "Subtotal: $0.00";
            lblDescuento.Text = "Descuento: $0.00";
            lblIva.Text = "IVA 15%: $0.00";
            lblTotal.Text = "TOTAL A PAGAR: $0.00";

            txtPrecio.Focus();
        }
    }
}