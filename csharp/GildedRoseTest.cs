using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void NormalItems_WhenUpdated_Degrade()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 20, Quality = 45 } };
            GildedRose app = new GildedRose(items);

            app.UpdateAllItems();

            Assert.AreEqual(19, items[0].SellIn);
            Assert.AreEqual(44, items[0].Quality);
        }

        [Test]
        public void NormalItemsPastSellBy_WhenUpdated_DegradeDouble()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 45 }};
            GildedRose app = new GildedRose(items);

            app.UpdateAllItems();

            Assert.AreEqual(-2, items[0].SellIn);
            Assert.AreEqual(43, items[0].Quality);
        }

        [Test]
        public void NormalItems_WhenUpdated_QualityNeverBelowZero()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 2, Quality = 0 } , new Item{Name="Foo",SellIn=-1, Quality=1}};
            GildedRose app = new GildedRose(items);

            app.UpdateAllItems();

            Assert.AreEqual(0, items[0].Quality);
            Assert.AreEqual(0, items[1].Quality);
        }

        [Test]
        public void AgedBrie_WhenUpdated_QualityIncreases()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 32 }};
            GildedRose app = new GildedRose(items);

            app.UpdateAllItems();

            Assert.AreEqual(33, items[0].Quality);
        }

        [Test]
        public void IncreasingQualityItems_WhenUpdated_ReachQualityMaxAt50()
        {
            IList<Item> items = new List<Item> {new Item { Name = "Aged Brie", SellIn = 4, Quality = 50 }, new Item{Name= "Backstage passes to a TAFKAL80ETC concert", SellIn=4,Quality=49} };
            GildedRose app = new GildedRose(items);

            app.UpdateAllItems();

            Assert.AreEqual(50, items[0].Quality);
            Assert.AreEqual(50, items[1].Quality);
        }

        [Test]
        public void Sulfuras_WhenUpdated_DoesntChange()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 32 } };
            GildedRose app = new GildedRose(items);

            app.UpdateAllItems();

            Assert.AreEqual(2, items[0].SellIn);
            Assert.AreEqual(32, items[0].Quality);
        }

        [Test]
        public void BackStageItems_WhenUpdated_IncreaseWithAgeDependentOnSellIn()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 24, Quality = 12 }, new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 12 }, new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality =12 } };
            GildedRose app = new GildedRose(items);

            app.UpdateAllItems();

            Assert.AreEqual(13, items[0].Quality);
            Assert.AreEqual(14, items[1].Quality);
            Assert.AreEqual(15, items[2].Quality);
        }

        [Test]
        public void BackStageItems_WhenPastSellBy_SetQualityToZero()
        {
            IList<Item> items = new List<Item>{new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 12}};
            GildedRose app = new GildedRose(items);

            app.UpdateAllItems();

            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void ConjuredItems_WhenUpdated_DegradeDouble()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "Conjured witch", SellIn = 14, Quality = 24},
                new Item {Name = "Conjured Wizard", SellIn = -2 , Quality =16}
            };
            GildedRose app = new GildedRose(items);

            app.UpdateAllItems();

            Assert.AreEqual(22, items[0].Quality);
            Assert.AreEqual(12, items[1].Quality);
        }
    }
}
