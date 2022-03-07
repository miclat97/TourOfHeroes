using APIForHeroes1.Models;

namespace APIForHeroes1.Data
{
    public static class MainListOfHeroes
    {
        public static bool FirstRun = true;
        public static List<Hero>? Heroes = new List<Hero>() { new Hero()
                {
                    Id = 1,
                    Name = "dr hero0",
                    Power = 55
                },
                new Hero()
                {
                    Id = 2,
                    Name = "good hero",
                },
                new Hero()
                {
                    Id = 3,
                    Name = "master",
                    Power = 154
                },
                new Hero()
                {
                    Id = 4,
                    Name = "sss",
                },
                new Hero()
                {
                    Id = 5,
                    Name = "abc1",
                    Power = 41
                },
                new Hero()
                {
                    Id = 6,
                    Name = "her",
                }
                };
    }
}
