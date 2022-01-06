from gilded_rose import GildedRose, Item


def test_default_item():
    default_item = Item("default", sell_in=10, quality=20)
    items = [default_item]
    shop = GildedRose(items)

    shop.update_quality()

    assert default_item.sell_in == 9
    assert default_item.quality == 19
