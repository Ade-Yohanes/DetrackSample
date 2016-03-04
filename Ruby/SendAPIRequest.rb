class SendAPIRequest
  require 'uri'
  require 'net/http'
  require 'net/https'
  require 'openssl'
  require 'json'
  load 'Models/DeleteDeliveryRequest.rb'
  load 'Models/DeliveryItem.rb'
  load 'Models/Item.rb'

  def initialize
    @uri = URI('https://app.detrack.com/api/v1')

    @https = Net::HTTP.new(@uri.host, @uri.port)
    @https.use_ssl = true
    @https.verify_mode = OpenSSL::SSL::VERIFY_NONE

    @header = {
        'Content-Type' => 'application/json',
        'X-API-KEY' => '3a99928772f834765b675efef2d7330be2e2a7a3ba33b8ff'
    }
  end


  def Run
    @date = '2016-03-01'
    @do = 'DO140211001'
    viewAllDeliveries(@date)
    viewAllVehicles

    downloadDeliveryPODSignature(@date, @do)

    deliverItem = getSampleDeliveryItems
    addDeliveries(deliverItem)

    viewAllDeliveries(@date)

    updateItem = Item.new
    updateItem.sku = 'T0201'
    updateItem.desc = 'Test Item #01'
    updateItem.qty = 1
    deliverItem.items = [updateItem]
    deliverItem.delivery_time = '12:00 PM - 03:00 PM'
    editDeliveries(deliverItem)

    viewAllDeliveries(@date)

    deleteDeliveryItem = getSampleDeleteDeliveryItems
    deleteDeliveries(deleteDeliveryItem)
  end

  def consolePrint(res)
    puts "Response #{res.code} #{res.message}: #{res.body}"
  end

  def viewAllDeliveries(deliveryDate)
    # Request: '/deliveries/view/all.json'
    req = Net::HTTP::Post.new(@uri.path + '/deliveries/view/all.json', @header)
    req.set_form_data('json' => '{"date":"' + deliveryDate + '"}')
    res = @https.request(req)
    consolePrint(res)
  end

  def viewAllVehicles
    # Request: '/vehicles/view/all.json'
    req = Net::HTTP::Post.new(@uri.path + '/vehicles/view/all.json', @header)
    res = @https.request(req)
    consolePrint(res)
  end

  def downloadDeliveryPODSignature(signatureDate, signatureDo)
    # Request: 'deliveries/signature.json' download delivery POD signature
    reqUrl = '/deliveries/signature.json'
    req = Net::HTTP::Post.new(@uri.path + reqUrl, @header)
    req.set_form_data('json' => '{
                                     "date":"' + signatureDate + '",
                                     "do":"' + signatureDo + '"
                                  }')
    res = @https.request(req)
    consolePrint(res)
  end

  def deleteDeliveries(deleteDeliveryItem)
    # Request: 'deliveries/delete.json'
    reqUrl = '/deliveries/delete.json'
    req = Net::HTTP::Post.new(@uri.path + reqUrl, @header)
    req.set_form_data('json' => '[' + deleteDeliveryItem.to_json + ']')
    res = @https.request(req)
    consolePrint(res)
  end

  def addDeliveries(deliveryItem)
    # Request: 'deliveries/create.json'
    reqUrl = '/deliveries/create.json'
    req = Net::HTTP::Post.new(@uri.path + reqUrl, @header)
    req.set_form_data('json' => '[' + deliveryItem.to_json + ']')
    res = @https.request(req)
    consolePrint(res)
  end

  def editDeliveries(deliveryItem)
    # Request: 'deliveries/update.json'
    reqUrl = '/deliveries/update.json'
    req = Net::HTTP::Post.new(@uri.path + reqUrl, @header)
    req.set_form_data('json' => '[' + deliveryItem.to_json + ']')
    res = @https.request(req)
    consolePrint(res)
  end

  def getSampleDeleteDeliveryItems
    @deleteDeliverRequest = DeleteDeliveryRequest.new
    @deleteDeliverRequest.date = '2016-03-01'
    @deleteDeliverRequest.do = 'DO140211001'
    return @deleteDeliverRequest
  end

  def getSampleDeliveryItems
    @deliveryItem = DeliveryItem.new
    @deliveryItem.date = '2016-03-01'
    @deliveryItem.do = 'DO140211001'
    @deliveryItem.delivery_time = '09:00 AM - 12:00 PM'
    @deliveryItem.deliver_to = 'John Tan'
    @deliveryItem.phone = '+6591234567'
    @deliveryItem.notify_email = 'john.tan@example.com'
    @deliveryItem.notify_url = 'http://www.example.com/notify.php'
    @deliveryItem.assign_to = '1111'
    @deliveryItem.instructions = 'Call customer upon arrival.'
    @deliveryItem.zone = 'East'
    @deliveryItem.address = '63 Ubi Avenue 1 Singapore 408937'
    @deliveryItem.items[0] = Item.new
    @deliveryItem.items[0].sku = 'T0200'
    @deliveryItem.items[0].desc = 'Test item #00'
    @deliveryItem.items[0].qty = 2
    return @deliveryItem
  end
end