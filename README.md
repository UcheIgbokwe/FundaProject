# FundaProject
This project is designed to manage real estate agent's data under the Funda network


AUTHOR - Uche Igbokwe

Application was built using clean architecture, SOLID principles.

## DEPENDENCIES/PREREQUISITIES

* .NET 6.0
* Http Client Factory
* Polly policies (To handle Http call retries)
* XUnit
* Ensure port 7024 and 5156 are available

## SETUP

> **Note**: Begin by cloning the project and navigate into the FundaProject folder. Ensure to have .NET 6 running on your device.

To startup the API project, follow these steps:

* Navigate to the [API](src/API) project folder
  * `cd src/API`
  * `dotnet build`
* Run the command below and listen on https://localhost:7024/swagger:
  * `dotnet watch run`

To run the test, follow these steps:

* Navigate to the [Tests](src/Tests) project folder
  * `cd src/Tests`
  * `dotnet build`
  * `dotnet test`



## HOW THE APPLICATION WORKS
The Project is designed to displayed most listed objects for sale by a real estate agent.
Displaying the top 10 ranked by agents and also including garden.

The [HTTP Service](src/Infrastructure/Services/HttpServices.cs)  has three methods:
- GetAllPropertyData : This retrieves all property data under the funda network using the provided URL.

- GetAgentsRankedByMostProperties : This streamlines the data gotten from `GetAllPropertyData` based on the zo query provided to a limit of top 10 agents.

- GetAgentsRankedByMostPropertiesAndGarden : This streamlines the data gotten from `GetAllPropertyData` based on the zo query provided to a limit of top 10 agents. The difference between this and `GetAgentsRankedByMostProperties` is in the zo query.






