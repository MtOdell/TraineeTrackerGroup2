# Trainee Tracker Group 2 

[![Coverage Status](https://coveralls.io/repos/github/MtOdell/TraineeTrackerGroup2/badge.svg?branch=main)](https://coveralls.io/github/MtOdell/TraineeTrackerGroup2?branch=main)

## Table Of Contents

- [Trainee Tracker Group 2](#trainee-tracker-group-2)
  - [Table Of Contents](#table-of-contents)
- [About the Project](#about-the-project)
  - [Original Sparta Global Trainee Tracker:](#original-sparta-global-trainee-tracker)
- [Built With](#built-with)
- [Getting Started](#getting-started)
- [How to use](#how-to-use)
- [Web API](#web-api)
- [Testing](#testing)
  - [How to Run the Tests:](#how-to-run-the-tests)
- [Contributors](#contributors)

# About the Project
We have created a trainee tracker for trainees to use and for trainers to view. The trainee tracker closely follows the same layout as ones given to us during our training at Sparta Global- they consist of a section where the trainee writes what they would like to start doing, stop doing and continue doing going into the next week. Following this, there is also a selector for consultanat skills and technical skills where the trainee ranks if they are unskilled, low skilled, partially skilled or skilled in each section for the weeks content. The trainee can add a tracker for each week and create profiles for themselves. We have also implemented a feature where the admin can assign the roles of the user. We have an API that the user can use to make direct API requests.

 ## Original Sparta Global Trainee Tracker: 
![Image](./Images/Skills.PNG)

# Built With
 This applications backend is built using .NET 6 and C# with the frontend being developed using HTML, CSS and Javascript.

# Getting Started

1. Ensure your console is open in the directory you wish to store the application.
2. Clone the repo using the command:  
   
   ``` git clone https://github.com/MtOdell/TraineeTrackerGroup2.git ```

3. Open up the solution titled "TraineeTracker" with Visual Studio 2022.
4. Ensure the solution builds by running without debugging.
5. Open the Package Manager Console from your view and use the following commands:
   ``` 
   drop-database
   update-database
   ``` 
6. You can now run the application in debug mode and start using the trainee tracker.

# How to use 
- We recommend having the latest Visual Studio installed as well as C#. 
- You can use Postman to make API requests for the API section of our project. 
- Once the repo has been cloned open the ``` TraineeTracker.sln``` file. 
- Run the code and use the url you get and copy and paste it into Postman. 

![Image](./Images/Home.PNG)

# Web API - Endpoints

```GET api/UserDatas``` - Returns all users

```GET api/UserDatas/2``` - Returns the user with Id 2

```GET api/UserDatas/2/Trackers``` - Returns all weeks from user with Id 2

```GET api/UserDatas/search?name=John``` - Returns all users where first name or last name contains John

```GET api/UserDatas/search?activity=C#``` - Returns all users where activity contains C#

```GET api/UserDatas/search?name=John&activity=C#``` - Returns all users where first name or last name contains John and where activity contains C#

```PUT api/UserDatas/2``` - Updates the user with Id 2

```GET api/api/UserDatas/18/Trackers``` - Returns all the trackers of ID

```PUT api/Trackers/1``` - Updates the week with Id 1

![Image](./Images/PostmanAPI.PNG)

Above is an example of a Postman GET request.

# Testing
Testing was done using both Moq and NUnit.

The tests covered both the web API and API controllers and also the service layers.

Other files in the project were excluded as they either dont require testing or are unable to be tested.

Some simples tests consist of:
- Checking that methods using the database work correctly within a service layer.
- Checking that certain methods and calls are only called a specific amount of times.
- Checking that classes are instantiated in the controllers.
- Checking that specific objects return the expected results and views with test data.

## How to Run the Tests:
1. Within Visual Studio 2022 open up the Test Explorer 
2. Run the tests by pressing the run all tests in view button or using the keyboard shortcut:
```CTRL + R, V```

# Contributors
- Max Odell 
- Ameer Imam Al-Murtaza Gardezi
- Adam Millard 
- Sergiusz Pietrala 
- Lewis James Kellet
- Sahilpreet Singh
- Nathan Bird
- Cesar Mello
- Rahul Patel
