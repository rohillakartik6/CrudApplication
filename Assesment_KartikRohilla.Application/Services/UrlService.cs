using Assesment_KartikRohilla.Application.Services.Interface;
using Assesment_KartikRohilla.Infrastructure.Entities;
using Assesment_KartikRohilla.Infrastructure.Repository.Interface;

namespace Assesment_KartikRohilla.Application.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository repo;
        public UrlService(IUrlRepository repo)
        {
            this.repo = repo;
        }

        public async Task<UrlTable> ShortenUrl(string url)
        {
            string apiUrl = $"https://ulvis.net/api.php?url={url}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            var data = await response.Content.ReadAsStringAsync();
            var res = await repo.ShortenUrl(url, data);
            return res;
        }
    }
}
