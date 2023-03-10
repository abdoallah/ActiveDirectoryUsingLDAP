using Abp.Application.Services;
using ActiveDirectoryTest.MultiTenancy.Dto;

namespace ActiveDirectoryTest.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

