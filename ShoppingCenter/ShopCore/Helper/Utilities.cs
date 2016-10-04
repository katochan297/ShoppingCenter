using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Helper
{
    public static class Utilities
    {
        public static string FormatAmountToVnd(string amount)
        {
            try
            {
                double d;
                double.TryParse(amount, out d);

                var money = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} ₫", d);

                return money;
            }
            catch (Exception ex)
            {
                //LogError(typeof(CheckoutUtils).Name, MethodBase.GetCurrentMethod().Name, ex);
                return string.Empty;
            }
        }

        public static string FormatAmountToString(string amount)
        {
            var result = amount.Trim().Replace(",", "").Replace(".", "");
            return result;
        }

    }
}
