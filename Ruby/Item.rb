class Item
  def sku
    @sku
  end

  def sku=(value)
    @sku = value
  end

  def desc
    @desc
  end

  def desc=(value)
    @desc = value
  end

  def qty
    @qty
  end

  def qty=(value)
    @qty = value
  end

  def to_json
    {'sku' => @sku, 'desc' => @desc, 'qty' => @qty.to_i}.to_json
  end
end