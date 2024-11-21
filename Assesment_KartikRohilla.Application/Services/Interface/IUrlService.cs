using Assesment_KartikRohilla.Infrastructure.Entities;

namespace Assesment_KartikRohilla.Application.Services.Interface
{
    public interface IUrlService
    {
        public Task<UrlTable> ShortenUrl(string url);
    }
}
