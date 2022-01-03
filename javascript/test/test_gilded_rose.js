var {expect} = require('chai');
var {Shop, Item} = require('../src/gilded_rose.js');
describe("Gilded Rose", function() {

  it("update quality of a normal item", function() {
    const foo = new Item("foo", 20, 10);

    const shop = new Shop([foo]);
    const items = shop.updateQuality();

    expect(foo.sellIn).to.equal(19);
    expect(foo.quality).to.equal(9);
  });

});
