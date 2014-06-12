/*
 * @author Infusion bootcamp instructors
 * @author Clinton Freeman <clintonfreeman@infusion.com>
 * @date 2014-06-10
 */

using System.Web;
using System.Web.Mvc;

namespace MVC_Lab
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}