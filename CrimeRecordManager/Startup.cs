using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrimeRecordManager.Startup))]
namespace CrimeRecordManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
