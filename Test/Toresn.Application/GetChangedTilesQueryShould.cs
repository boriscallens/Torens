using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Torens.Application.Tiles.Queries;

namespace Toresn.Application
{
    [TestClass]
    public class GetChangedTilesQueryShould
    {
        [TestMethod]
        public void ReturnEmptyCollectionWhenNothingChanged()
        {
            var tileId = Guid.NewGuid();
            var timeSpan = TimeSpan.Zero;

            var qry = new GetChangedTilesQuery(timeSpan, tileId);
            var handler = new GetChangedTilesHandler();

            var result = handler.Handle(qry);
            
            Assert.IsFalse(result.Tiles.Any());
        }
    }
}
