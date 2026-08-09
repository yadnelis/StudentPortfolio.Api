# StudentPortfolio

Student portfolio is an application meant for acknowledging student achievements. This repo contains the next.js server for the app.

## Deploying StudentPortfolio

- Open the package manager console and set `StudentPortfolio` as the startup project.
- Run the update-database command:
  - Ensure the connection string for the database in the `appSettings.json` file is correct.
- Right click the StudentPortfolio project in visual studio and publish to a folder. This will create an executable file that runs the API and HTML server.

> Remarks: The API project runs the npm build command -> the compiled React js application ends up in the wwroot folder. It is **not** necessary to build or move the React app manually.

## /StudentPortfolio (Api Project)

Api for the student portfolio app.

### Main Packages

- [Entity Framework Core](https://github.com/dotnet/efcore) - Object Database Mapper: Maps objects and functions to database tables and queries. Removes the need to directly interact with the database. Updates to the database schema can be performed with the `add-migration <name>` command then the `update-database` command, wich creates and applies a migration.

### Running the app locally

- Open the package manager console and set `StudentPortfolio` as the startup project.
- Run the `update-database` command:
  - Ensure the connection string for the database in the `appSettings.json` file is correct.
- Run the app form visual studio. API Requests can be made to https://localhost:56890/api.

## /StudentPortfolio.Client

This is a [React.js](https://React.dev/) project bootstrapped with [`vite`](https://vite.dev/).

### Main Libraries

- [Lucide](https://lucide.dev) - SCG icons library with React integration. (ISC Licensed, free and open-source)
- [Mantine](https://mantine.dev) - React component library. (MIT Licensed)
- [Tailwind](https://tailwindcss.com/) - Free and open source utility-first CSS framework. (MIT Licensed)
- [Typescript](https://www.typescriptlang.org/) - Node.js package that adds static typing to JavaScript. (Apache Licensed, Royalty Free)
- [Axios-http](https://axios-http.com/docs/intro) - Axios is a promise-based HTTP Client for node.js

### Running the app locally

1. Run the development server: `npm run dev`
2. Open http://localhost:5173 in your browser to see the result.
   > **Note**: When running the React app locally, it makes api calls to the VITE_API_URL specified in the .env file
