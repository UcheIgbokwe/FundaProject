# FundaProject
This project is designed to manage real estate agent's data under the Funda network


AUTHOR - Uche Igbokwe

Application was built using clean architecture, SOLID principles.

## DEPENDENCIES/PREREQUISITIES

* .NET 6.0
* Aurelia Framework
* NodeJs 
* Http Client Factory
* Polly policies (To handle Http call retries)
* XUnit
* Ensure port 7024, 8080 and 5156 are available

## SETUP

> **Note**: Begin by cloning the project and navigate into the FundaProject folder. Ensure to have .NET 6, NodeJs v10 or above running on your device. 
Run `npm install -g aurelia-cli` on any CLI. [SETUP](https://aurelia.io/docs/tutorials/creating-a-todo-app#setup)

# API:
To startup the API project, follow these steps:

* Navigate to the [API](src/API) project folder
  * `cd src/API`
  * `dotnet build`
* Run the command below and listen on https://localhost:7024/swagger:
  * `dotnet run`

To run the test, follow these steps:

* Navigate to the [Tests](src/Tests) project folder
  * `cd src/Tests`
  * `dotnet build`
  * `dotnet test`

# CLIENT:
To startup the CLIENT project, follow these steps:

* Navigate to the [client](client) project folder
  * `cd client`
* Run the code below to install dependencies.
  * `npm install`  
* Startup the CLIENT project
  * `npm start`  

* To view top ten agents ranked by number of properties.
  * `http://localhost:8080/`
* To view top ten agents with properties that have gardens.
  * `http://localhost:8080/tuin`  




## HOW THE APPLICATION WORKS
The Project is designed to displayed most listed objects for sale by a real estate agent.
Displaying the top 10 ranked by agents and also including garden.

The [HTTP Service](src/Infrastructure/Services/HttpServices.cs)  has three methods:
- GetAllPropertyData : This retrieves all property data under the funda network using the provided URL.

- GetAgentsRankedByMostProperties : This streamlines the data gotten from `GetAllPropertyData` based on the zo query provided to a limit of top 10 agents ranked by number of properties.

- GetAgentsRankedByMostPropertiesAndGarden : This streamlines the data gotten from `GetAllPropertyData` based on the zo query provided to a limit of top 10 agents ranked by number of properties. The difference between this and `GetAgentsRankedByMostProperties` is in the zo query.

- The [Polly service](src/API/Extensions/ApplicationServiceExtensions.cs) handles retry policies for gateway time outs and service unavailable.

- Exception handlers are setup to manage too many requests, unauthorized and generic error responses from the API.


Incase of blockers, kindly contact me via: uchehenryigbokwe@gmail.com.

