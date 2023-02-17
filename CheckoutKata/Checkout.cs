using System;
using System.Collections.Generic;
using System.Linq;

public partial class Checkout
{
    private readonly List<Item> items = new List<Item>();

    public void Scan(Item item)
    {
        items.Add(item);
    }

    public decimal GetTotalPrice()
    {
        decimal totalPrice = 0;

        // Group the items by SKU and count the number of occurrences of each SKU
        var itemGroups = items.GroupBy(i => i.SKU).Select(g => new { SKU = g.Key, Count = g.Count() });

        foreach (var itemGroup in itemGroups)
        {
            var item = GetItem(itemGroup.SKU);

            if (item.Promotion != null)
            {
                // Apply promotions
                int promotionCount = 0;

                if (itemGroup.SKU == "B")
                {
                    // Apply 3 for 40 promotion to multiples of 3
                    promotionCount = itemGroup.Count / 3;
                    totalPrice += promotionCount * 40;

                    // Add remaining items without promotion
                    totalPrice += (itemGroup.Count % 3) * item.UnitPrice;
                }
                else if (itemGroup.SKU == "D")
                {
                    // Apply 25% off promotion to multiples of 2
                    promotionCount = itemGroup.Count / 2;
                    totalPrice += promotionCount * item.UnitPrice * 0.75m;

                    // Add remaining items without promotion
                    totalPrice += (itemGroup.Count % 2) * item.UnitPrice;
                }
            }
            else
            {
                // Add items without promotion
                totalPrice += itemGroup.Count * item.UnitPrice;
            }
        }

        return totalPrice;
    }

    private Item GetItem(string sku)
    {
        switch (sku)
        {
            case "A":
                return new Item("A", 10);
            case "B":
                var itemB = new Item("B", 15);
                itemB.Promotion = "3 for 40";
                return itemB;
            case "C":
                return new Item("C", 40);
            case "D":
                var itemD = new Item("D", 55);
                itemD.Promotion = "25% off for every 2 purchased together";
                return itemD;
            default:
                throw new ArgumentException("Invalid item SKU");
        }
    }
}
