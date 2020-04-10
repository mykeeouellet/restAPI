# Rocket_Elevators_Rest_Api

In order to connect our information system to the equipment in operation throughout the territory served, we develop a REST API using C # and .NET Core. 
It will allow us to know and to manipulate the status of all the relevant entities of the operational database.
This API is deployed on a Server in Azure and is connected with the MySQL transactional database that serves the Ruby on Rails application. 

### Instrucions for testing examples of queries that can be applied to the REST API
 
* 1-  To retrieve the current status of a specific Battery
```
				On Postman choose 	
* Select Method : 	GET   		
* Enter request URL:	https://rocketelevatorsrestapi3.azurewebsites.net/api/Batteries/5
( 5 is an battery ID )
* Click on "Send" button
```
* 2-  To change the status of a specific Battery
```
				On Postman choose 	
* Select Method : 	PUT   		
* Enter request URL:	https://rocketelevatorsrestapi3.azurewebsites.net/api/Batteries/update/status/5
( 5 is an battery ID )
* Set Params: 		Key = status	|	Value = write_new_status
* Click on "Send" button
* To check if the status is changed, test example 1 with the same ID
```
* 3-  To retrieve the current status of a specific Column
```
				On Postman choose 	
* Select Method : 	GET   		
* Enter request URL:	https://rocketelevatorsrestapi3.azurewebsites.net/api/Columns/5
( 5 is an column ID )
* Click on "Send" button
```
* 4-  To change the status of a specific Column
```
    On Postman choose 	
* Select Method : 	PUT   		
* Enter request URL:	https://rocketelevatorsrestapi3.azurewebsites.net/api/Columns/update/status/5	
( 5 is an column ID )
* Set Params: 		Key = status	|	Value = write_new_status
* Click on "Send" button
* To check if the status is changed, test example 3 with the same ID
```
* 5-  To retrieve the current status of a specific Elevator
```
				On Postman choose 	
* Select Method : 	GET   		
* Enter request URL:	https://rocketelevatorsrestapi3.azurewebsites.net/api/Elevators/5
( 5 is an elevator ID )
* Click on "Send" button
```
* 6-  To change the status of a specific Elevator
```
				On Postman choose 	
* Select Method : 	PUT   		
* Enter request URL:	https://rocketelevatorsrestapi3.azurewebsites.net/api/Elevators/update/status/5
( 5 is an elevator ID )
* Set Params: 		Key = status	|	Value = write_new_status
* Click on "Send" button
* To check if the status is changed, test example 5 with the same ID
```
* 7-  To retrieve a list of Elevators that are not in operation at the time of the request
```
				On Postman choose 	
* Select Method : 	GET   		
* Enter request URL:	https://rocketelevatorsrestapi3.azurewebsites.net/api/Elevators
* Click on "Send" button
* The result will be displayed in the reserve section, for a better display choose Json.
```
* 8-  To retrieve a list of Buildings that contain at least one battery, column or elevator requiring intervention
```
  		On Postman choose 	
* Select Method : 	GET   		
* Enter request URL:	https://rocketelevatorsrestapi3.azurewebsites.net/api/Buildings
* Click on "Send" button
* The result will be displayed in the reserve section, for a better display choose Json.
```
* 9-  To retrieve a list of Leads created in the last 30 days who have not yet become customers.
```
				On Postman choose 	
* Select Method : 	GET   		
* Enter request URL:	https://rocketelevatorsrestapi3.azurewebsites.net/api/Leads
* Click on "Send" button
* The result will be displayed in the reserve section, for a better display choose Json.
```
