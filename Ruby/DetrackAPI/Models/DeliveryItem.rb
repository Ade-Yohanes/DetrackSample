class DeliveryItem
  def initialize
    @items = []
  end

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

  def address
    return @address
  end

  def address=(value)
    @address = value
  end

  def delivery_time
    return @delivery_time
  end

  def delivery_time=(value)
    @delivery_time = value
  end

  def deliver_to
    @deliver_to
  end

  def deliver_to=(value)
    @deliver_to = value
  end

  def phone
    return @phone
  end

  def phone=(value)
    @phone = value
  end

  def notify_email
    return @notify_email
  end

  def notify_email=(value)
    @notify_email = value
  end

  def notify_url
    return @notify_url
  end

  def notify_url=(value)
    @notify_url = value
  end

  def assign_to
    return @assign_to
  end

  def assign_to=(value)
    @assign_to = value
  end

  def instructions
    return @instructions
  end

  def instructions=(value)
    @instructions = value
  end

  def zone
    return @zone
  end

  def zone=(value)
    @zone = value
  end

  def items
    return @items
  end

  def items=(value)
    @items = value
  end
end