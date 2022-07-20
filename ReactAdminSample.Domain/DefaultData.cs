using Bogus;
using ReactAdminSample.Domain.Models;

namespace ReactAdminSample.Domain
{
    public static class DefaultData
    {
        public static (IList<Make>, IList<Model>, IList<Trim>) GetData()
        {
            var makes = new List<Make>();
            var models = new List<Model>();
            var trims = new List<Trim>();

            var makesCount = new Faker().Random.Number(12, 16);
            for (int m = 0; m < makesCount; ++m)
            {
                var makeFaker = new Faker<Make>()
                    .RuleFor(m => m.Id, m => Guid.NewGuid())
                    .RuleFor(m => m.Name, m => m.Vehicle.Manufacturer());

                var make = makeFaker.Generate();
                makes.Add(make);

                var modelsCount = new Faker().Random.Number(6, 18);
                for (int j = 0; j < modelsCount; ++j)
                {
                    var modelFaker = new Faker<Model>()
                        .RuleFor(m => m.MakeId, m => make.Id)
                        .RuleFor(m => m.Id, m => Guid.NewGuid())
                        .RuleFor(m => m.Name, m => m.Vehicle.Model());

                    var model = modelFaker.Generate();
                    models.Add(model);

                    var trimsCount = new Faker().Random.Number(10, 40);
                    for (int t = 0; t < trimsCount; ++t)
                    {
                        var trimFaker = new Faker<Trim>()
                            .RuleFor(m => m.ModelId, m => model.Id)
                            .RuleFor(m => m.Name, m => $"{m.Random.Number(1, 4)}.{m.Random.Even(0, 8)}L {m.Random.ArrayElement(new int[] { 8, 12, 16, 20 })}V {m.Vehicle.Fuel()}")
                            .RuleFor(m => m.Year, m => m.Random.Number(2000, 2023));

                        var trim = trimFaker.Generate();
                        trims.Add(trim);
                    }
                }
            }

            return (makes, models, trims);
        }
    }
}
