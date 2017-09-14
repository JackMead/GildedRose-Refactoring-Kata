using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string BackStage = "Backstage passes to a TAFKAL80ETC concert";
        private const string Brie = "Aged Brie";
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
        private const int BackStagePassFirstValueIncrease = 10;
        private const int BackStagePassSecondValueIncrease = 5;

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
            if (item.Name == Sulfuras)
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
            if (item.Name == BackStage)
            {
                BackStagePassIncreaseQuality(item);
            }

            if (item.Name != Brie && item.Name != BackStage)
            {
                ReduceQuality(item);
            }
            else
            {
                IncreaseQuality(item);
            }
        }

        private void UpdateItemQualityPastSellBy(Item item)
        {
            if (item.Name == BackStage)
            {
                item.Quality = MinQuality;
            }
            else
            {
                UpdateItemQuality(item);
            }
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality >= MaxQuality)
            {
                return;
            }

            item.Quality++;
        }

        private void BackStagePassIncreaseQuality(Item item)
        {
            if (item.SellIn <=BackStagePassFirstValueIncrease)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn <= BackStagePassSecondValueIncrease)
            {
                IncreaseQuality(item);
            }
        }

        private void ReduceQuality(Item item)
        {
            if (item.Quality > MinQuality)
            {
                item.Quality--;
            }
        }
    }
}
