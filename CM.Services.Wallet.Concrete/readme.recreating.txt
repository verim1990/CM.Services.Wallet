1.1) Prerequisites

install-package FluentValidation
install-package MediatR
Install-Package Sieve

1.2) References

CM.Services.Wallet.Contract
CM.Services.Wallet.Infrastracture

2) Recreating microservice

2.1) Run `dotnet new classlib  -o CM.Services.Wallet.Concrete -f netcoreapp2.1`
2.2) Move: 
	- directories:
		- *
	- files:
		- readme.recreating.txt