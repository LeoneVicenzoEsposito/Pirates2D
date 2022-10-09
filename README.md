# Pirates2D
 A simple top-down shooter with a pirate aesthetic.

#### LARGE DESCRIPTION:
This is a simple top-down shooter in which the player controls a physics-based ship and must navigate to dodge the incoming enemy ships and cannonballs while also shooting at those enemies to destroy them and score points while a clock tics down. 

#### CONFIGURATION:
The project is fully configurable, in the editor it's possible to change:
Max and minimum enemy spawn rate
how fast the enemies and players move
how much damage do the enemies or players cause
how many times per second does the ShootingEnemy or player fires
Setting the bullet velocity for each. 
It's also possible to change the effects the ships create when they fire and what effect the bullets cause when they hit something (only 1 is shipped on this project).

The project also features 2 "in-game" configurable settings, Enemy Spawn Timer and Playtime. Which will respectively increase the rate at which enemies spawn and change how long the play session will last.

#### ORGANIZATION: 
- The scripts are all located in the Assets/Scripts/ folder, I chose to do it this way because this is a small project that likely won't be expanded or refactored, but hopefully, it will still showcase my knowledge on the Unity Engine. 
- The Prefab folder is separated into Player, Effects, and Enemy-related prefabs.
- There are only 2 scenes on this project, so all scenes are in just one folder. Assets/Scenes/
- The folders I haven't explicitly commented about are from the assets I imported to make this project.
 
#### IMAGES: 
The visual assets were committed alongside the code because the overall size of the project is very small, if the project size were any bigger id instead use storage for those kinds of assets. 

#### POSSIBLE IMPROVEMENTS:
- More abstraction of the scripts. 
- More enemies derived from the GenericEnemy abstract class
- Upgrades and powerups (faster fire rate, more damage, damage resistance, number of projectiles fired)
- More Types of terrain. (Currently, only 2 terrain types are included: Rocks that block the path but don't destroy projectiles, and terrain that does destroy projectiles)

## HOW TO INSTALL
- Step 1: Download the repository zip
- Step 2: Extract the zip files into a new folder specifically for this project
- Step 3: Install the Unity Hub and Unity Engine(if you dont have it)
- Step 4: Open Unity Hub and click open, then navigate to the folder you created for this project and select it.
