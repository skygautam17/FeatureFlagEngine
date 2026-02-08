
# Feature Flag Engine

A feature flag management system built using .NET Core, Angular, SQL Server, and Clean Architecture principles.

## Architecture Overview

FeatureFlagEngine.Domain  
FeatureFlagEngine.Application  
FeatureFlagEngine.Infrastructure  
FeatureFlagEngine.Api  
FeatureFlagEngine.Tests  
Angular UI (feature-flag-ui)

## Features Implemented

- Feature CRUD
- User and Group Overrides
- Runtime evaluation with precedence
- EF Core persistence
- Angular UI
- Test project scaffold

## Evaluation Logic

User Override → Group Override → Global Default

Endpoint:
GET /api/evaluate?featureKey=...&userId=...&groupId=...

## How to Run

### Backend
1. Open solution in Visual Studio 2022
2. Configure connection string in appsettings.json
3. Run:
   dotnet ef database update
4. Run the API

### Angular
cd ui/feature-flag-ui
npm install
npm start

## Database Schema

FeatureFlags:
- Id
- Key
- Description
- Enabled

FeatureOverrides:
- Id
- FeatureFlagId
- UserId
- GroupId
- Enabled

## Assumptions
- Feature keys are unique
- Overrides follow strict precedence
- Authentication is out of scope

## Future Improvements
- Percentage rollout
- Region targeting
- Redis caching
- Audit log viewer

## For running Project
- Just Run API and Web Application project together. It will load angular application as well but before that, Please run npm install command to path D:\FeatureFlagEngine\src\FeatureFlagEngine.Web\ClientApp. path might be changed for you
- Docker setup

## Testing
dotnet test
