using Assesment_KartikRohilla.Infrastructure.Entities;

namespace Assesment_KartikRohilla.Infrastructure.Repository.Interface
{
    public interface IUrlRepository
    {
        public Task<UrlTable> ShortenUrl(string url, string shortUrl);
    }
}
