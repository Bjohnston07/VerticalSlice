# GDIM33 Vertical Slice
## Milestone 1 Devlog

### Prompt 1

The UI visual script graph controls all UI text and a button right now. When queued by scene variables such as health, medicine count, or overheat, the texts on screen will appear
or change. Diving deeper into each individual function the ones for health, medicine count and overheat are pretty much the same. There is a Text Mesh Pro UGUI object on the canvas
to represent each one. Each of these has a variable reference within the UI object variables. The player graph is what manipulates the scene variables referring to how much health 
the player has, how overheat is managed, and how much medicine you have collected. The UI graph takes those and stes their respective UI text elements to those values on update. There
is also a reference to a button in the scene and some text that refers to when the player dies that is off by default. When the currentHealth scene variable hits 0, the UI graph will
unlock the cursor and turn on that text and button the player can click to reload the scene or "restart" the game.

### Prompt 2

<img width="1462" height="1196" alt="33 milestone 1 prompt 2 breakdown" src="https://github.com/user-attachments/assets/af4c1ec2-9d61-489c-8520-7259a6587cd6" />

I added a state machine section that connects to my animator and the enemy. This state machine works by having the exact same pieces as the animations. Those being idle, chase, attack, and die. The idle state is the start state and by being within a certain distance (object variable), it can transition to the chase state where the animation boolean for chase will be set to true and the navmesh target will be set to the player. Once the enemy gets close enough (another object variable) it will transition to the attack state and the attack animation _trigger_ will be set and both the movement and idle animation boolean will be turned off (the idle state can also transition to the attack state if the player somehow gets within attack distance) with an object variable boolean called attacking being turned on and a timer for a few seconds being activated within the attack states pudate section. The attack state cannot be exited until this timer is over and therefore the enemy cannot begin to chase or idle while the enemy is "attacking".

The last section of the state machine is the Die state which can be transitioned to from the idle or chase state if the dead object variable boolean is on. This boolean is managed by the general enemy script graph, not a state machine graph, when the enemy's health reaches 0. Once the Die state is entered, the other booleans will turn off and the Dead animation trigger will be set casuing the death animation to occur.

## Milestone 2 Devlog
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- Cite any external assets used here!
