using Algorithm.Composition;
using NUnit.Framework;


namespace Algorithm.Tests.Composition
{
	[TestFixture]
    public class AggregationTests
    {
        [Test]
        public void SummingAggregation_Produces_Sum()
        {
            var aggregator = new PointsAggregator(_measurements, new EmptyFilter(), new SummingStrategy());

            var result = aggregator.Aggregate();

            Assert.That(result.X, Is.EqualTo(107));
            Assert.That(result.Y, Is.EqualTo(30));
        }

        [Test]
        public void AveragingAggregagtor_Produces_Average()
        {
            var aggregator = new PointsAggregator(_measurements, new EmptyFilter(), new AveragingStrategy());

            var result = aggregator.Aggregate();

			Assert.That(result.X, Is.EqualTo(35));
			Assert.That(result.Y, Is.EqualTo(10));
        }

        [Test]
        public void LowPassAveragingAggregator_Applys_Filter()
        {
            var aggregator = new PointsAggregator(_measurements, new LowPassFilter(), new AveragingStrategy());

            var result = aggregator.Aggregate();

			Assert.That(result.X, Is.EqualTo(3));
			Assert.That(result.Y, Is.EqualTo(12));            
        }

        // Uncomment this test and make it pass reusing as much code as 
        // possible from other classes that are available in the Composition folder
        //[Test]
        //public void HighPassSummingAggregator_Applys_Filter()
        //{                
        //    var aggregator = new PointsAggregator(_measurements, new HighPassFilter(), new SummingStrategy());

        //    var result = aggregator.Aggregate();

		//    Assert.That(result.X, Is.EqualTo(105));
		//    Assert.That(result.Y, Is.EqualTo(15));
        //}

        /// Uncomment this test and make it pass by building a new class to 
        /// hide the "composition" of strategies and filters ...
        //[Test]
        //public void CustomHighPassSummingAggregator_Applys_Filter()
        //{                
        //    var aggregator = new HighPassSummingAggregator(_measurements);

        //    var result = aggregator.Aggregate();

        //    Assert.That(result.X,Is.EqualTo(105));
		//    Assert.That(result.Y,Is.EqualTo(15));
        //}

        Measurement[] _measurements = new[]
        {
            new Measurement { X = 5, Y = 10},
            new Measurement { X = 2, Y = 15},
            new Measurement { X = 100, Y = 5}                  
        };
    }
}