using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private IList<Item> Items;
        public GildedRose(IList<Item> items)
        {
            this.Items = items;
        }

        public void UpdateAllItems()
        {
            foreach (Item item in Items)
            {
                UpdateIndividualItem(item);
            }
        }

        private void UpdateIndividualItem(Item item)
        {
            //Sulfuras never changes
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return;
            }

            UpdateItemQuality(item);
            UpdateItemSellIn(item);

            if (item.SellIn < 0)
            {
                UpdateItemQualityPastSellBy(item);
            }
        }

        private void UpdateItemQualityPastSellBy(Item item)
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.Quality = 0;
            }
            else
            {
                UpdateItemQuality(item);
            }
        }

        private void UpdateItemSellIn(Item item)
        {
            item.SellIn--;
        }

        private void UpdateItemQuality(Item item)
        {
            if (item.Name.Contains("Conjured"))
            {
                ReduceQuality(item);
            }
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                BackStagePassIncreaseQuality(item);
            }

            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                ReduceQuality(item);
            }
            else
            {
                IncreaseQuality(item);
            }
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality >= 50)
            {
                return;
            }

            item.Quality++;
        }

        private void BackStagePassIncreaseQuality(Item item)
        {
            if (item.SellIn < 11)
            {
                IncreaseQuality(item);

            }

            if (item.SellIn < 6)
            {
                IncreaseQuality(item);

            }
        }

        private void ReduceQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
        
    }
}
