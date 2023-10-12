using Bogus;
using HRAnnouncements.Modules.Announcements.Domain.Entities;
using HRAnnouncements.Modules.Announcements.Domain.Filters;
using HRAnnouncements.Modules.Announcements.Domain.Repositories;

namespace HRAnnouncements.Modules.Announcements.Application.Seeders
{
    public class AnnouncementSeeder
    {
        private readonly IAnnouncementRepository _repository;

        public AnnouncementSeeder(IAnnouncementRepository repository)
        {
            _repository = repository;
        }

        public void Seed()
        {
            // If there are any announcement in table, do not seed
            if (_repository.GetAllAsync(new AnnouncementFilter()).Result.totalRecords > 0)
            {
                return;
            }

            var faker = new Faker("tr");

            var announcements = new Faker<Announcement>("tr")
                .CustomInstantiator(f =>
                    Announcement.Create(
                        f.Lorem.Sentence(),
                        f.Lorem.Paragraphs()
                    ))
                .RuleFor(a => a.Id, f => f.Random.Guid())
                .RuleFor(a => a.DatePublished, f => f.Date.Past(1).ToUniversalTime())
                .Generate(100);

            _repository.BulkAdd(announcements);
        }
    }
}
