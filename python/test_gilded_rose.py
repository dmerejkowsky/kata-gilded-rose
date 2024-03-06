from gilded_rose import GildedRose, Item


def test_default_item():
    default_item = Item("default", sell_in=10, quality=20)
    items = [default_item]
    shop = GildedRose(items)

    shop.update_quality()

    assert default_item.sell_in == 9
    assert default_item.quality == 19


def test_gloden_master():
    items = [
        Item(name="+5 Dexterity Vest", sell_in=10, quality=20),
        Item(name="Aged Brie", sell_in=2, quality=0),
        Item(name="Elixir of the Mongoose", sell_in=5, quality=7),
        Item(name="Sulfuras, Hand of Ragnaros", sell_in=0, quality=80),
        Item(name="Sulfuras, Hand of Ragnaros", sell_in=-1, quality=80),
        Item(name="Backstage passes to a TAFKAL80ETC concert", sell_in=15, quality=20),
        Item(name="Backstage passes to a TAFKAL80ETC concert", sell_in=10, quality=49),
        Item(name="Backstage passes to a TAFKAL80ETC concert", sell_in=5, quality=49),
        Item(name="Conjured Mana Cake", sell_in=3, quality=6),
    ]

    gilded_rose = GildedRose(items)
    actual_log = []
    days = 30
    for day in range(days + 1):
        actual_log.append(f"-------- day {day} --------")
        actual_log.append("name, sellIn, quality")
        for item in items:
            actual_log.append(str(item))
        gilded_rose.update_quality()

    with open("../golden-master/expected-output.txt") as f:
        expected_log = f.read().splitlines(keepends=False)

    expected_log = [x for x in expected_log if x]

    assert actual_log == expected_log


if __name__ == "__main__":
    # In case pytest is not easy to install
    test_default_item()
    test_gloden_master()
