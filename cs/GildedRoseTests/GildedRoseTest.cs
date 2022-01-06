using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using System.IO;
using System.Runtime.CompilerServices;

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

        [Fact]
        public void goldenMaster() {
            IList<Item> items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(items);
            IList<string> actualLog = new List<string>();

            for (var i = 0; i < 31; i++)
            {
                actualLog.Add("-------- day " + i + " --------");
                actualLog.Add("name, sellIn, quality");
                for (var j = 0; j < items.Count; j++)
                {
                    actualLog.Add(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
                }
                app.UpdateQuality();
            }

            string thisPath = GetThisFilePath();
            string thisDirectory = Path.GetDirectoryName(thisPath);


            IList<string> expectedLog = new List<string>();
            string expectedLogPath = thisDirectory + "/../../golden-master/expected-output.txt";
            foreach (string line in File.ReadLines(expectedLogPath)) {
                if(line.Length != 0) {
                    expectedLog.Add(line);
                }
            }

            Assert.Equal(expectedLog, actualLog);

        }

        private static string GetThisFilePath([CallerFilePath] string path = null)
        {
            return path;
        }
    
    }
}

