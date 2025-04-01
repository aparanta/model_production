# model_production
Scenario: To handle live updates for change of state of equipments

Sample code for a webhook implementation of pub-sub 

On update to EquipmentState all subscriber callbacks  to be called

Core Application has UPDATE API for equipment state. 
Missing db implementation and trigger to webhook on success

Run : EquipmentMonitoring first
Run : EquipmentMonitoringClient to start subscribing 



Trigger /publish endpoint with topic "equipmentstate.update" should see update console log of client with message. 