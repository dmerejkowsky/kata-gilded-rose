package com.gildedrose;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

class GildedRoseTest {

    @Test
    public void simpleItem() {
        Item foo = new Item("foo", 20, 10);
        Item[] items = new Item[] { foo  };
        GildedRose gildedRose = new GildedRose(items);

        gildedRose.updateQuality();

        assertEquals(19,foo.sellIn);
        assertEquals(9, foo.quality);
    }

}
