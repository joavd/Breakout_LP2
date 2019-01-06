# Breakout in Console

Project made for LP2 class using .NET Core (*C#*). It replicates _Breakout_ 
from the Atari 2600.

## Who did this project?

* [__Alejandro Urcera__](https://github.com/aurceramartins)
  * a21703818

* [__João Duarte__](https://github.com/JoaoAlexandreDuarte)
  * a21702097

## Git repository

We worked in a private repository that will be available publicly in this
[link](https://github.com/JoaoAlexandreDuarte/Breakout_LP2) after the deadline.

## Task distribution

Both persons contributed to the project equally, sharing tasks and doing pair
programming, but below, there's a summary of eachs contributions:

* __Alejandro Urcera__
  * Code;
  * Program Tests;
  * Diagram and Fluxogram;
  * Report;
  * Commentary and Documentation;

* __João Duarte__
  * Code;
  * Program Tests;
  * Report;
  * Commentary and Documentation;
  * Sandcastle Documentation;

## Our solution

### Architecture

The program was made using the .NET Core framework so it's able to run in 
multiple platforms. It was made by making use of the most recent topics taught 
in LP2, mainly the Design Patterns, (_Game Loop_, _Update Method_, _Observer_), 
_Threads_ and _Lambda Expressions_, as well as all the previous things we
learned so far.

At launch, the program shows a menu that asks what the user wants to do.
The user can play the game, check the controls (that also give a brief
explanation of what the game is), check the developers of the game or quit.

By playing the game, the player must keep the ball above the threshold to try
and hit all the bricks. If it loses returns to the menu screen.

The architectura was based around one of the exercises done in 
[one class](https://github.com/VideojogosLusofona/lp2_2018_aulas/tree/master/Aula12/Exercicio1)
where there's a `Scene` that holds all the gameobjects. 

There is a _Thread_ where the _game loop_ is running, and theres another one
reading the inputs. Each loop of the _game loop_ updates the gameobjects so 
that there's a representation of a game.

### UML Diagram

<p align="center">
  <img src="UML.png" alt="UML Diagram"/>
</p>

### Fluxogram

<p align="center">
  <img src="fluxogram.png" alt="Fluxogram"/>
</p>

## Conclusions

With this project we consolidated the advanced C# concepts that were taught in 
class by using them to make a replica of a popular game. We had some 
difficulties at the begginning, until we decided to adapt the program made
in one of the classes in order to make our game.

## References
  
* Whitaker, R. B. (2016). **The C# Player's Guide**
    (3rd Edition). Starbound Software.
* Albahari, J. (2017). **C# 7.0 in a Nutshell**.
    O’Reilly Media.
* Nystrom, R. (2014). **Game Programming Patterns**.
    Genever Benning. Retrieved from <http://gameprogrammingpatterns.com/>.
* Freeman, E., Robson, E., Bates, B., & Sierra, K.
    (2004). **Head First Design Patterns**. O'Reilly Media.
* Dorsey, T. (2017). **Doing Visual Studio and .NET
    Code Documentation Right**. Visual Studio Magazine. Retrieved from
    <https://visualstudiomagazine.com/articles/2017/02/21/vs-dotnet-code-documentation-tools-roundup.aspx>.
* Fiedler, G. (2004). **Fix your timestep**. Gaffer On Games. Retrieved from
    <https://gafferongames.com/post/fix_your_timestep/>.
* Fachada, N. (2018). **Linguagens de Programação II**. Aula 12. Retrieved from
    <https://github.com/VideojogosLusofona/lp2_2018_aulas/tree/master/Aula12/Exercicio1>