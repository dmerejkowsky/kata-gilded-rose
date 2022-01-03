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
            Item defaultItem = new Item { Name = "default", SellIn = 20, Quality = 10 };
            IList<Item> Items = new List<Item> { defaultItem };
            GildedRose shop = new GildedRose(Items);

            shop.UpdateQuality();
            Assert.Equal(19, defaultItem.SellIn);
            Assert.Equal(9, defaultItem.Quality);
        }
    }
}
