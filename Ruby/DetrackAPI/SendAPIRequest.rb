class SendAPIRequest
  require 'uri'
  require 'net/http'
  require 'net/https'
  require 'openssl'
  require 'json'
  load 'Models/DeleteDeliveryRequest.rb'
  load 'Models/DeliveryItem.rb'

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
    @date = '2014-02-13'
    @do = 'DO140213001'
    viewAllDeliveries(@date)
    viewAllVehicles
    downloadDeliveryPODSignature(@date, @do)
    addDeliveries
    deleteDeliveries
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

  def deleteDeliveries
    # Request: 'deliveries/delete.json'
    deleteObj = getSampleDeleteDeliveryItems
    reqUrl = '/deliveries/delete.json'
    req = Net::HTTP::Post.new(@uri.path + reqUrl, @header)
    req.set_form_data('json' => '{
                                     "date":"' + deleteObj.date + '",
                                     "do":"' + deleteObj.do + '"
                                  }')
    res = @https.request(req)
    consolePrint(res)
  end

  def addDeliveries
    # Request: 'deliveries/create.json'
    addObj = getSampleDeliveryItems
    reqUrl = '/deliveries/create.json'
    req = Net::HTTP::Post.new(@uri.path + reqUrl, @header)
    req.set_form_data('json' => '[{
                                    "date":"' + addObj.date + '",
                                    "do":"' + addObj.do + '",
                                    "address":"' + addObj.address + '",
                                    "delivery_time":"' + addObj.delivery_time + '",
                                    "deliver_to":"' + addObj.deliver_to + '",
                                    "phone":"' + addObj.phone + '",
                                    "notify_email":"' + addObj.notify_email + '",
                                    "notify_url":"' + addObj.notify_url + '",
                                    "assign_to":"' + addObj.assign_to + '",
                                    "instructions":"' + addObj.instructions + '",
                                    "zone":"' + addObj.zone + '"
                                  }]')
    res = @https.request(req)
    consolePrint(res)
  end

  def getSampleDeleteDeliveryItems
    @deleteDeliverRequest = DeleteDeliveryRequest.new {
          @date = '2016-03-01',
              @do = 'DO140211001' }
    return @deleteDeliverRequest
  end

  def getSampleDeliveryItems
    @deliveryItem =
        DeliveryItem.new {
          @date = '2016-03-01',
              @do = 'DO140211001',
              @delivery_time = '09:00 AM - 12:00 PM',
              @deliver_to = 'John Tan',
              @phone = '+6591234567',
              @notify_email = 'john.tan@example.com',
              @notify_url = 'http://www.example.com/notify.php',
              @assign_to = '1111',
              @instructions = 'Call customer upon arrival.',
              @zone = 'East',
              @address = '63 Ubi Avenue 1 Singapore 408937'
        }
    return @deliveryItem
  end
end