using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingAPI.Models;
using System.Linq;

namespace TrainingTests
{

    class TestTrainingDBSet:TestDbSet<Training>
    {
        public override Training Find(params object[] keyValues)
        {
            return this.SingleOrDefault(training => training.Id == (int)keyValues.Single());
        }
    }
}
