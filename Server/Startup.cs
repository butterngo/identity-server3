namespace Server
{
    using IdentityServer3.Core.Configuration;
    using IdentityServer3.Core.Services;
    using Owin;
    using Server.Services;
    using System;
    using System.Security.Cryptography.X509Certificates;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //http://thorium.github.io/Owin.Compression/
            app.Map("/identity", idsrvApp =>
            {
                
                var factory = new IdentityServerServiceFactory();

                factory.UserService = new Registration<IUserService, UserService>();
                factory.ClientStore = new Registration<IClientStore, ClientService>();
                factory.ScopeStore = new Registration<IScopeStore, ScopeService>();
                factory.ViewService = new Registration<IViewService, CustomViewService>();
                
                idsrvApp.UseIdentityServer(
                     new IdentityServerOptions
                     {
                         SiteName = "Standalone Identity Server",
                         SigningCertificate = LoadCertificate(),
                         Factory = factory,
                         RequireSsl = false,
                         AuthenticationOptions = new AuthenticationOptions()
                         {
                             IdentityProviders = ConfigureIdentityProviders
                         }
                     });
            });

            app.UseFileServer("/Content");
        }

        private void ConfigureIdentityProviders(IAppBuilder app, string signInAsType)
        {
            //https://identityserver.github.io/Documentation/docsv2/configuration/identityProviders.html
            // How can I configure to use an external authorization grant ex: facebook, google++?
        }

        private X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
              $"{AppDomain.CurrentDomain.BaseDirectory}\\idsrv3test.pfx", "idsrv3test");
        }
    }
}
