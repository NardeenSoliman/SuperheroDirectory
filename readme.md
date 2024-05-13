# Superhero Directory

## Prerequisites
Replace `{token}` key in app settings with your access token.

## Project Structure
This solution is broken down into `src` & `test` folder.

## Project Architecture
This project is using `Onion` architecture using `infrastructure`, `application` & ``domain``.

## How to run the application
### Using docker
In solution root directory 

Build
`docker build -t superhero-directory -f src/SuperheroDirectory.API/Dockerfile .`

Run
`docker run --rm -it -p 9000:8080 superhero-directory -e "SuperheroApiConfig:AccessToken=YOUR_ACCESS_TOKEN"`

## How to test the application
Run test cases in `SuperheroDirectory.Tests` and make sure you passed your access token in `appsettings.json` before running.

## List of available APIs
- Register `identity/register`
- Login `identity/login`
- Search `api/v1/search/{superheroName}`
- Store favorite `api/v1/store/favorites`
- Favorites `api/v1/favorites`

## Application Flow
1- Start by `registering` new user using `register` endpoint, then `login` using `email` & `password` only.<br/>
2- `Search` for your favorite hero then `store` followed by getting `favorites` for full flow.

## Enhancements
There are still plenty of enhancement to do in this code such as
- Removing any static text to be in constants.
- Refactoring, such as adding decorator pattern to Superhero repository with system cache service, instead of applying repository and caching logic in service layer.
- Adding retry logic to superhero api client to handle timeout exceptions.
- Add logging.
- Increase test coverage.
- Refactor store favorites function to breakdown responsibilites into smaller functions.

## Important Note
Please note that in memory database and cache are used to run the application. 
Therefore, with every new application instance, you would be required to start the flow from the beginning.
