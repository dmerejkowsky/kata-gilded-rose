var {expect} = require('chai');
var {Shop, Item} = require('../src/gilded_rose.js');
describe("Gilded Rose", function() {

  it("update quality of a normal item", function() {
    const gildedRose = new Shop([ new Item("foo", 20, 10) ]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).to.equal(9);
  });

});
