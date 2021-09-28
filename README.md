# Meetings
ASP.NET Core meetings app

This app uses asp.net core 3.1 and EntitiyFramework. You will need Microsoft Visual Studio 2019 in order to run it.

In Order to run the application, do the following:

### Step 1

clone the project locally :

git clone https://github.com/jared7129/Meetings.git

### Step 2

Change the connection string in the appsettings.json file to your local pc server, or to microsft sql server:

"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=aspnet-Meetings-1DF37F7E-FD8F-459C-8F9E-1EED586B6541;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  
 ### Step 3
 
 Run the migrations :
 
 add-migration -Context ApplicationDbContext
 
 update-database -Context ApplicationDbContext
