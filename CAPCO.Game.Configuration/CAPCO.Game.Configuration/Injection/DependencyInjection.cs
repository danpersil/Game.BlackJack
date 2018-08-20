using CAPCO.Game.BackJack.Application.App;
using CAPCO.Game.BackJack.Application.Interface;
using CAPCO.Game.BackJack.Infra.Infra;
using CAPCO.Game.BackJack.Infra.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CAPCO.Game.Configuration.Injection
{
    public class DependencyInjection
    {
        public void Injection(IServiceCollection services)
        {
            services.AddScoped<ICacheInfra, CacheInfra>();
            services.AddScoped<IGameApp, GameApp>();
        }
    }
}
