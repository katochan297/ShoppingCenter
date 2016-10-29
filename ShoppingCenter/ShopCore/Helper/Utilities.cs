using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace ShopCore.Helper
{
    public static class Utilities
    {
        public static Logger ShopLogger = LogManager.GetCurrentClassLogger();

        public static string FormatAmountToVnd(dynamic amount)
        {
            try
            {
                double d;
                double.TryParse(amount.ToString(), out d);

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
