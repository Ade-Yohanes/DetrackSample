class DeleteDeliveryRequest

  def date
    return @date
  end

  def date=(value)
    @date = value
  end

  def do
    return @do
  end

  def do=(value)
    @do = value
  end

  def to_json
    {'date' => @date, 'do' => @do}.to_json
  end
end