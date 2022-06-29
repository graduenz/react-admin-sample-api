using Bogus;
using ReactAdminSample.Domain.Models;

namespace ReactAdminSample.Domain
{
    public static class DefaultData
    {
        public static (IList<Make>, IList<Model>, IList<Trim>) GetData()
        {
            var trimFaker = new Faker<Trim>()
                .RuleFor(m => m.Name, m => $"{m.Random.Number(1, 4)}.{m.Random.Even(0, 8)}L {m.Random.ArrayElement(new int[] { 8, 12, 16, 20 })}V {m.Vehicle.Fuel()}")
                .RuleFor(m => m.Year, m => m.Random.Number(2000, 2023));

            var modelFaker = new Faker<Model>()
                .RuleFor(m => m.Name, m => m.Vehicle.Model())
                .RuleFor(m => m.Trims, trimFaker.GenerateBetween(10, 40));

            var makeFaker = new Faker<Make>()
                .RuleFor(m => m.Name, m => m.Vehicle.Manufacturer())
                .RuleFor(m => m.Models, modelFaker.GenerateBetween(6, 18));

            var makes = makeFaker.GenerateBetween(12, 16);

            foreach (var make in makes)
            {
                make.Id = Guid.NewGuid();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                foreach (var model in make.Models)
                {
                    model.Id = Guid.NewGuid();
                    model.MakeId = make.Id;

                    foreach (var trim in model.Trims)
                    {
                        trim.Id = Guid.NewGuid();
                        trim.ModelId = model.Id;
                    }
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            var models = makes.SelectMany(m => m.Models).ToList();
            var trims = models.SelectMany(m => m.Trims).ToList();

            makes.ForEach(m => m.Models = null);
            models.ForEach(m => m.Trims = null);

            return (makes, models, trims);
        }
    }
}
