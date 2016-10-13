using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Helper
{
    public class AlertHelper
    {
        private const string SuccessTitle = "Thành Công";
        private const string InformationTitle = "Thông Báo";
        private const string WarningTitle = "Cảnh Báo";
        private const string DangerTitle = "Thất Bại";

        private static Alert BaseAlert(string message, bool isShow = false)
        {
            return new Alert
            {
                Message = message,
                Show = isShow
            };
        }

        public static Alert Success(string message, bool isShow = false)
        {
            var result = BaseAlert(message, isShow);
            result.Title = SuccessTitle;
            result.Style = AlertStyle.Success;
            return result;
        }

        public static Alert Information(string message, bool isShow = false)
        {
            var result = BaseAlert(message, isShow);
            result.Title = InformationTitle;
            result.Style = AlertStyle.Information;
            return result;
        }

        public static Alert Warning(string message, bool isShow = false)
        {
            var result = BaseAlert(message, isShow);
            result.Title = WarningTitle;
            result.Style = AlertStyle.Warning;
            return result;
        }

        public static Alert Danger(string message, bool isShow = false)
        {
            var result = BaseAlert(message, isShow);
            result.Title = DangerTitle;
            result.Style = AlertStyle.Danger;
            return result;
        }

    }

    public class Alert
    {
        public const string TempDataKey = "TempDataAlert";
        public string Style { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool Show { get; set; }
    }

    public static class AlertStyle
    {
        public const string Success = "success";
        public const string Information = "info";
        public const string Warning = "warning";
        public const string Danger = "danger";
    }

}
