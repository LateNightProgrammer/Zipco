## User API Dev Guide

Solution designed with Domain Driven Desing in mind (clean architecture). Organized the code as loosely coupled as possible. 

**Contracts** -- only interfaces
**Domain**   -- Entity & Dto classes
**Persistence** -- All related stuff to store data.
**API** -- Business logic.


**Open API link:**

https://localhost:44350/swagger/index.html

## Building

dotnet build

## Testing

Can test it either with postman or using https://localhost:44350/swagger/index.html

## Deploying

dotnet run

**Note** Please update credentials, SSL and database connection string details for docker yaml file.

## Additional Information





