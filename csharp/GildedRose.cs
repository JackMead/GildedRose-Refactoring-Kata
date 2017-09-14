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

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }

                ChangeQualityWithTime(item);
                ChangeSellByTime(item);

                if (item.SellIn < 0)
                {
                    ChangeQualityWithTimePastSellBy(item);
                }
            }
        }

        private void ChangeQualityWithTimePastSellBy(Item item)
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.Quality = 0;
            }
            if (item.Name != "Aged Brie")
            {

                if (item.Quality > 0)
                {
                    item.Quality--;
                    if (item.Name.Contains("Conjured"))
                    {
                        item.Quality--;
                    }

                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }

        private void ChangeSellByTime(Item item)
        {
            item.SellIn--;

        }

        private void ChangeQualityWithTime(Item item)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality > 0)
                {
                    item.Quality--;
                    if (item.Name.Contains("Conjured"))
                    {
                        item.Quality--;
                    }

                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality++;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality++;
                            }
                        }
                    }
                }
            }
        }
    }
}
