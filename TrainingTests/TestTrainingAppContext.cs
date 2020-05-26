using System.Data.Entity;
using TrainingAPI.Models;

namespace TrainingTests
{
    class TestTrainingAppContext: ITrainingAPIContext
    {
        public TestTrainingAppContext()
        {
            this.Trainings = new TestTrainingDBSet();
        }
        public DbSet<Training> Trainings { get; set; }

        public int SaveChanges()
        {
            return 0;
        }
        public void Dispose() { }
    }
}
