using System.Web;
using Hdnug.Web.Interfaces;

namespace Hdnug.Web.Inrastructure.Providers
{
    public class ServerMapPathProvider : IProvideServerMapPath
    {
        public string MapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}