using Microsoft.EntityFrameworkCore;
using StatusCheckSystem.BusinessLayer.Interfaces;
using StatusCheckSystem.Data.Data;
using StatusCheckSystem.Data.Entities;
using StatusCheckSystem.Data.Enums;
using System.Diagnostics;

namespace StatusCheckSystem.BusinessLayer.Services
{
    public class VerificationService : IVerificationService
    {
        private readonly string[] URLS =
        {
            "https://github.com/",
            "https://www.google.com/",
            "https://www.microsoft.com/",
            "https://localhost:7241/api/Settings/Current-Settings"
        };

        private readonly StatusCheckSystemDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public VerificationService(StatusCheckSystemDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<VerificationLog>> CheckStatus()
        {
            var tasks = URLS.Select(async url =>
            {
                var client = _httpClientFactory.CreateClient();
                var stopwatch = Stopwatch.StartNew();

                try
                {
                    var response = await client.GetAsync(url);
                    stopwatch.Stop();

                    return new VerificationLog
                    {
                        Url = url,
                        Status = response.IsSuccessStatusCode ? Status.Up : Status.Down,
                        Latency = response.IsSuccessStatusCode ? $"{stopwatch.ElapsedMilliseconds} ms" : "Error"
                    };
                }
                catch
                {
                    stopwatch.Stop();
                    return new VerificationLog { Url = url, Status = Status.Down, Latency = "Error" };
                }
            });

            var results = await Task.WhenAll(tasks);
            var verifications = results.ToList();

            _context.Verifications.AddRange(verifications);
            await _context.SaveChangesAsync();

            return await _context.Verifications
                .GroupBy(v => v.Url)
                .Select(g => g.OrderByDescending(v => v.Id).FirstOrDefault())
                .ToListAsync();
        }
    }
}
