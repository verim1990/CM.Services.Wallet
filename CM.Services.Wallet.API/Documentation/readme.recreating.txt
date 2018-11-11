1.1) Prerequisites

1.2) References

CM.Services.Wallet.Concrete
CM.Services.Wallet.Infrastracture
CM.Shared.Web

2) Recreating microservice
2.1) Run `dotnet new webapi -o CM.Services.Wallet.API`
2.2) Move: 
	- directories:
		- Controllers
		- Documentation
	- files:
		- AppSettings.cs
2.3) Modify:
	- Startup.cs
	- Program.cs
	- appSettings.json 
		- add Public section
		- add Private section
2.4) Add docker support (linux)
2.5) Alter:
	- docker-compose.yml
		- add dependencies for other container (sql, rabbitmq)
		- add CM.Services.Wallet.Web to CM.Proxy container into dependencies and link list
	- docker-compose.override.yml
		- add network section to container configuration
		- add shared-variables.env file to container configuration	
		- add connection string to environments variables