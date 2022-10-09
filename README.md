# Pirates2D
 A simple top down shooter with a pirate aesthetic.

---LARGE DESCRIPTION
This is a simple top down shooter in which the player controlls a phisics based ship and must navigate to dodge the incomming enemy ships and cannonballs while also shooting at those enemies to destroy them and score points while a clock tics down. 

--- CONFIGURATION:
The project is fully configurable, in the editor its possible to change:
Max and minimum enemy spawnrate
how fast the enemies and player move
how much damage the enemies or player cause
how many times per second the ShootingEnemy or player fires
Setting the bullet velocity for each. 
Its also possible to change the effects the ships create when they fire and what effect the bullets cause when they hit something (only 1 is shipped on this project).

The project also features 2 "in-game" configurable settings, Enemy Spawn Timer and Play time. Which will respectivelly increase the rate at which enemies spawn and change for how long the play session will last.

--- ORGANIZATION: 
- The scripts are all located in the Assets/Scripts/ folder, i chose doing it this way because this is a small project that likelly wont be expanded or refactored, but hopefully it will still showcase my knowlage on the Unity Engine. 
- The Prefab folder is is separated on Player , Effects and Enemy related prefabs.
- There are only 2 scenes on this project, so all scenes are in just one folder. Assets/Scenes/
- The folders i haven't explicitly commented about are from the assets i imported to make this project.
 
--- IMAGES: 
The visual assets were commited alongside the code because the overall size of the project is very small, if the project size were any bigger id instead use a storage for those kinds of assets. 

--- POSSIBLE IMPROVEMENTS:
More abstraction of the scripts.
More enemies derived from the GenericEnemy abstract class
Upgrades and powerups (faster fire rate, more damage, damage resistance, number of projectiles fire)
More Types of terrain. (Currently only 2 terrain types are included: Rocks that block the path but dont destroy projectiles, and terrain that does destroy projectiles)
