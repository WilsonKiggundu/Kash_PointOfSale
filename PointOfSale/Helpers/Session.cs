using PointOfSale.Models;

namespace PointOfSale.Helpers
{
    internal static class Session
    {
        /// <summary>
        /// Current user details
        /// </summary>
        
        public static int UserId;
        public static string Username;
        public static string FullName;
        public static int TenantId;
        public static Tenant Tenant;
        public static Module Module;

    }

    internal static class Settings
    {
        /// <summary>
        /// API Access details
        /// </summary>
        public static string ApiUrl = "http://erp.eygo.biz/sync";

        public static string ApiUsername = "wkiggundu";
        public static string ApiPassword = "sw33th0m3";

    }
}
