using CAPCO.Game.BackJack.Application.App;
using CAPCO.Game.BackJack.Application.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CAPCO.Game.Configuration.Injection
{
    public class DependencyInjection
    {
        public void Injection(IServiceCollection services)
        {
            services.AddScoped<ICache, CacheApp>();
            services.AddScoped<IGameApp, GameApp>();
        }
    }
}
