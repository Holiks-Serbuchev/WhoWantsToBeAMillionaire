# How to work with
## How install project:
Before getting started, you need to download the project.
  With this command:
 ```
 git clone https://github.com/Holiks-Serbuchev/WhoWantsToBeAMillionaire.git
 cd WhoWantsToBeAMillionaire
 dotnet build
 dotnet run
 ```
 ## How to use:
When a new user first logs into the site. He sees the interface of the game who wants to be a millionaire:
* The settings interface includes:
  * Drop-down list where you can select the number of questions;
  * And the "Старт" button which allows you to start the game.
   
   ![alt text](https://media.discordapp.net/attachments/592433653683060761/885481328705962024/unknown.png?width=1320&height=676)
   
When the user presses the "Старт" button, the game will start and new functions will appear.
* New features will include:
    * A new 50/50 function will appear on the page. It allows you to hide two incorrect answers;
    * There will also be a new function to stop the game. It fires when the user clicks on the "Стоп" button;
    * There are also buttons thanks to which you can choose an answer.When you click on it, if this is the correct answer, then points are added to the Score, if it is not correct, the game is reset, where you will then be offered to start the game again.


 ![alt text](https://media.discordapp.net/attachments/592433653683060761/885491655363407912/unknown.png?width=1320&height=676)

Example of using the game "Who Wants to Become a Millionaire":
 ![hippo](https://media.discordapp.net/attachments/592433653683060761/885510011755847700/d55d5f3e3df1db68.gif?width=920&height=458)

# Architecture
The project was developed using __ASP.NET MVC__ technology. Also using the __Service__ and __Repository__ pattern. Using languages such as __C#__, __SQL__ and __JavaScript__.
1. This project used __JavaScript__ to update data in real time. All __JavaScript__ code is stored in __js/site.js__ file.
2. The __QuestionRepo__ repository is used to extract data from data.
3. The service is responsible for the site logic. It has functions:
    1.  __Shuffle__ function lets you shuffle questions;
    2. The __HideAndShow__ function allows you to hide or open pages;
    3. The __LoseOrWin__ function allows you to determine whether a player has lost or not;
    4. The __GetQuestions__ function allows you to get questions;
    5. The __GetRandomName__ function allows you to get random responses;
    6. The __SetQuestionValue__ function allows you to modify the answers;
    7. The __SetRandomName__ function allows you to change random responses.
4. The __HomeController__ has a __ChangeValues__ ​​function that allows you to randomize answers and questions.
5. The __Game__ class allows you to customize the game.
6. The __ConnectionClass__ allows you to connect to a database.
