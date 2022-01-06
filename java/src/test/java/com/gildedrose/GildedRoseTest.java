package com.gildedrose;

import org.junit.jupiter.api.Test;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertTrue;

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

    @Test
    public void goldenMaster() throws IOException {
        Item[] items = new Item[] {
            new Item("+5 Dexterity Vest", 10, 20), //
            new Item("Aged Brie", 2, 0), //
            new Item("Elixir of the Mongoose", 5, 7), //
            new Item("Sulfuras, Hand of Ragnaros", 0, 80), //
            new Item("Sulfuras, Hand of Ragnaros", -1, 80),
            new Item("Backstage passes to a TAFKAL80ETC concert", 15, 20),
            new Item("Backstage passes to a TAFKAL80ETC concert", 10, 49),
            new Item("Backstage passes to a TAFKAL80ETC concert", 5, 49),
            // this conjured item does not work properly yet
            new Item("Conjured Mana Cake", 3, 6) };

        GildedRose app = new GildedRose(items);

        int days = 30;
        List actualLog = new ArrayList<String>();
        for (int i = 0; i <= days; i++) {
            actualLog.add("-------- day " + i + " --------");
            actualLog.add("name, sellIn, quality");
            for (Item item : items) {
                actualLog.add(item.toString());
            }
            app.updateQuality();
        }

        List expectedLog = new ArrayList<String>();
        String workingDir = System.getProperty("user.dir");
        String expectedPath = workingDir + "/../golden-master/expected-output.txt";
        File expectedFile = new File(expectedPath);
        FileReader reader = new FileReader(expectedFile);
        BufferedReader bufferedReader = new BufferedReader(reader);
        StringBuffer stringBuffer = new StringBuffer();
        String line;
        while ((line = bufferedReader.readLine()) != null) {
            if(! line.isEmpty()) {
                expectedLog.add(line);
            }
        }
        assertEquals(expectedLog, actualLog);
    }


}
