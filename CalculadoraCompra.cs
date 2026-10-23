using System;

namespace S4_Compra
{
    public static class CalculadoraCompra
    {
        public static (decimal subtotal, decimal descuento, decimal iva, decimal total) Calcular(decimal precio, int cantidad)
        {
            // 1. Subtotal: precio * cantidad[cite: 5]
            decimal subtotal = Math.Round(precio * cantidad, 2, MidpointRounding.AwayFromZero);

            // 2. Descuento: 10% si subtotal >= 100, si no 0[cite: 5]
            decimal porcentajeDescuento = (subtotal >= 100m) ? 0.10m : 0.00m;
            decimal descuento = Math.Round(subtotal * porcentajeDescuento, 2, MidpointRounding.AwayFromZero);

            // 3. IVA: 15% sobre (subtotal - descuento)[cite: 5]
            decimal baseImponible = subtotal - descuento;
            decimal iva = Math.Round(baseImponible * 0.15m, 2, MidpointRounding.AwayFromZero);

            // 4. Total: subtotal - descuento + IVA[cite: 5]
            decimal total = Math.Round(subtotal - descuento + iva, 2, MidpointRounding.AwayFromZero);

            return (subtotal, descuento, iva, total);
        }
    }
}