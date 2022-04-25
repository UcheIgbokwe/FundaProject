# FundaProject
This project is designed to manage real estate agent's data under the Funda network


AUTHOR - Uche Igbokwe

Application was built using clean architecture, SOLID principles.

## DEPENDENCIES/PREREQUISITIES

* .NET 6.0
* Http Client Factory
* Polly policies (To handle Http call retries)
* Ensure port 7024 and 5156 are available

## SETUP

To startup the API project, follow these steps:

* Navigate to the [src/API](API) project folder
  `cd src/API`
  `dotnet build`
* Run the command below and listen on https://localhost:7024/swagger:
  `dotnet watch run`



## HOW THE APPLICATION WORKS
The Project is designed to displayed most listed objects for sale by a real estate agent.
Displaying the top 10 ranked by agents and also including garden.

The HTTP Service has three methods:
- GetAllPropertyData : This retrieves all property data under the funda network using the provided URL.

- GetAgentsRankedByMostProperties : This streamlines the data gotten from `GetAllPropertyData` based on the zo query provided to a limit of top 10 agents.

- GetAgentsRankedByMostPropertiesAndGarden : This streamlines the data gotten from `GetAllPropertyData` based on the zo query provided to a limit of top 10 agents. The difference between this and `GetAgentsRankedByMostProperties` is in the zo query.






