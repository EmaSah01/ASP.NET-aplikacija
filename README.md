M2M Consumer ASP.NET Core Web API
Overview

This project is an ASP.NET Core Web API application that demonstrates a Machine-to-Machine (M2M) consumer architecture using:

REST Controllers

Layered architecture (Controller → Service → External API)

HttpClient for external API communication

OAuth 2.0 Client Credentials flow

Parallel request execution

The application simulates integration with an external RBI API and demonstrates how to securely obtain an access token and call protected endpoints.

Architecture

The project follows a layered architecture pattern:

Client (Browser / Swagger)
        ↓
Controller
        ↓
Service Layer
        ↓
External API Service
        ↓
OAuth Server (Token)
        ↓
RBI API
Layers Explained

Controllers
Handle incoming HTTP requests and return responses.

Service Layer
Contains business logic and orchestrates external API calls.

External API Service
Uses HttpClient to:

Request OAuth access token

Call external RBI API with Bearer token

Token Service
Implements OAuth 2.0 Client Credentials flow.

Features

REST API endpoints

OAuth 2.0 Client Credentials authentication

Secure external API communication

Dependency Injection

Configuration via appsettings.json

Parallel execution of 50 API calls using Task.WhenAll

Project Structure
Controllers/
    AccountController.cs
    RatingController.cs

Services/
    IAccountService.cs
    AccountService.cs
    IExternalApiService.cs
    ExternalApiService.cs
    ITokenService.cs
    TokenService.cs

Configuration/
    OAuthSettings.cs
    ExternalApiSettings.cs

Program.cs
appsettings.json
Endpoints
1. Get Account Data
GET /api/account/{accountId}

Calls the external RBI API using OAuth authentication.

2. Get List of Ratings (Parallel Calls)
GET /api/rating/list-of-ratings

Performs 50 parallel external API calls and aggregates results.

Configuration

Update appsettings.json:

"OAuth": {
  "TokenUrl": "https://auth-server.com/connect/token",
  "ClientId": "your-client-id",
  "ClientSecret": "your-client-secret",
  "Scope": "rbi.api"
},
"ExternalApi": {
  "BaseUrl": "https://rbi-api.com/"
}
Technologies Used

.NET 8

ASP.NET Core Web API

HttpClient

OAuth 2.0 Client Credentials Flow

IdentityModel

Dependency Injection

How to Run

Clone the repository

Update appsettings.json with valid OAuth and API credentials

Run the project:

dotnet run

Open Swagger:

https://localhost:{port}/swagger
