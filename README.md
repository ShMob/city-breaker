# City Breaker
## A "Brick Breaker" Game Remix

This game brings brick breaker's game mechanics to a 3D world, and uses trees, walls, graves (and a poor little human) instead of bricks.
It has one extra level (the graveyard) added to the main city level, which can be chosen from the menu.
The main city level consists of 33 destroyable objects: trees, bushes, fences, walls and a roof of a house, and a little block human.
The graveyard level consists of 11 destroyable objects: different kinds of gravestones and tombs and a coffin.
Each kind of object has it's own resistance level (number of hits needed to be destroyed), score and power up drop probability when it is destroyed.

There are two power ups in the game:
- The glowing ball power up: When the player gets this power up, a new ball is added to the game.
- The plus power up: This power up increases the length of the platform player controls for 10 seconds. this power up effect can stack (getting another one of this power up before the 10 second of the previous is up still increases the platform's length)

The features implemented:
- [x] Implement the main mechanics of the game (movement of the platform and the ball)
- [x] Add destroyable objects
- [x] Use scriptable objects for the max hit, score and powerup drop probabilty for each kind of object
- [x] Add a main menu with level selection page
- [x] Fix the ball's speed
- [x] Have at least two levels with different themes
- [x] Add "new ball" power up
- [x] Add "increase platform's length" power up
- [x] Add lose and win screen
- [] Add a colorpicker to change the color of the platform and ball