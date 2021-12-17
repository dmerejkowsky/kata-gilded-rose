using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void defaultItem()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "default", SellIn = 20, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].Quality);
        }
    }
}
