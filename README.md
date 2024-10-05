# SPAGame

## Intro

This is a single-page application where a user can play a number guessing game as well as:
- Register and login on accounts
- See highscores of all players from today and all-time
- Visit their profile and see their stats

The application handles all logic on the backend and presents the data to the frontend.

## Tech Stack

- ASP.NET
- C#
- JavaScript (React.js)
- SQL Server
- Tailwind CSS

## Approach

- ASP.NET Core Web API
- Authorization with JWT-tokens
- Code first with SQL Server
- Entity Framework Core

## Code

- Controllers: Responsible for all HTTP requests and is arguably the most important part of the application along with the repositories. The controllers call on repository methods and sends the finalized data to the frontend.
- Models: This application utilizes both model classes as well as data transfer objects (DTOs).
- Repositories: This application follows the repository pattern which means that all of the logic is stored inside the repositories; the repository methods are then injected into and called by the controllers. This makes the controllers thinner and the application easier to maintain.

## Database

The database consists of several tables which are Accounts, Games, Highscores and Profiles.

- Accounts: Stores the accounts and their details: Id, name, email and password.
- Games: Stores all started games, active and inactive.
- Highscores: Keeps count of the users' scores which are then displayed on the highscore page.
- Profiles: Stores data related to the stats of the users, such as games played, won etc.