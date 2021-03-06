﻿using Dotnettency.Container;
using System.Threading.Tasks;

namespace Dotnettency.AspNetCore.Modules.Nancy
{
    public class TenantNancyBootstrapperFactory<TTenant> : ITenantNancyBootstrapperFactory<TTenant>
         where TTenant : class
    {

        private readonly ITenantContainerAccessor<TTenant> _tenantContainerAccessor;

        public TenantNancyBootstrapperFactory(ITenantContainerAccessor<TTenant> tenantContainerAccessor)
        {
            _tenantContainerAccessor = tenantContainerAccessor;
        }

        public async Task<TenantContainerNancyBootstrapper<TTenant>> Get(TTenant currentTenant)
        {
            var tenantContainer = await _tenantContainerAccessor.TenantContainer.Value;
            return new TenantContainerNancyBootstrapper<TTenant>(tenantContainer);
        }
    }
}