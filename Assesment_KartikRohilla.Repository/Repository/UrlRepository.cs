using Assesment_KartikRohilla.Infrastructure.Entities;
using Assesment_KartikRohilla.Infrastructure.Repository.Interface;

namespace Assesment_KartikRohilla.Infrastructure.Repository
{
    public class UrlRepository : IUrlRepository
    {
        public readonly Neosoft_KartikRohillaContext context;
        public UrlRepository(Neosoft_KartikRohillaContext context)
        {
            this.context = context;
        }

        public async Task<UrlTable> ShortenUrl(string url, string shortUrl)
        {
            var urlTable = new UrlTable
            {
                ShortUrl = shortUrl,
                LongUrl = url
            };
            await context.UrlTables.AddAsync(urlTable);
            await context.SaveChangesAsync();
            return urlTable;
        }

    }
}
