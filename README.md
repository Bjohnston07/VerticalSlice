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

**Comment based on the milestone 1 feedback, the enemies are supposed to get to you, the player is meant to stand and fight and it is expected to take damage which is why the
enemies can be as fast as they are and as hard to kill as they are. They aren't meant to be easy to kill fodder, but dangerous monsters

Question 1:
Add a feature to display a UI element if an enemy is behind you and within a certain range

Steps:
1. Create the UI element and add and shape a new collider behind the player
2. Create the system in visual scripting for the collision detection for the player in the enemy graph and connect that to a method within the UI graph

Substeps:
1. Create a new text element in the canvas
2. Give is some text like "You feel watched" or something like that
3. Give the player a new empty object called "sixth sense" attached with a new sphere collider behind the player
4. Shape the sphere collider and set it to trigger
1. Give the sixth sense object a unique tag


1. Create a new object variable in the UI script to hold the text object
2. Create a new custom event in the UI script to enable the text object
3. Create another custom event to disable the text object
4. Add a new section to the enemy graph with on trigger enter checking the tag of the game object it collided with
5. if the tag check is successful, call the event to enable the object
6. Add a on trigger exit node checking the tag
7. call the event to disable the object 

Question 2:
The breakdown helped somewhat breaking down my feature I wish to add into smaller steps is something I feel like I naturally do anyway to a certain extent. My main complicating
feature being the flamethrower overheat was already implemented therefore this new feature ended up being a little simpler. Due to this I feel like I could have thought of these
steps while creating the feature anyway however I can definitely see the vision with much more complicated content. To improve my breakdowns I think I need to keep more consistency
with the complexity of my steps. Some steps could have been combined and some steps could have been split up most likely. 

Question 3:
I have a c# script called Restart that contains a method that enables the three objects required when the player dies. This method is called within the UI visual script whenever
the player's current health reaches 0. This keeps the activation of the death screen which is an irreversible action until the player restarts the game outside of the UI graph and
keeps the actual logic from performing that outside of the graph.

<img width="1581" height="687" alt="image" src="https://github.com/user-attachments/assets/1da223e2-10ef-418f-84b8-19458d2e4ba4" />


Question 4:
I created a timeline cutscene within a new start menu scene that has the camera pan down in front of an enemy and play animations. It also includes an activation track to 
turn on the button that loads scene 1, dropping the player into the game.

## Milestone 3 Devlog

Question 1:
My shader graph works by taking the URP sample buffer (the original screen) and multiplying it by a sample texture 2D node inputted with the screen position and a texture2D property defaulted to a red effect. This value and the URP sample buffer are inputted into a LERP node to interpolate between the original image and the red image based on an amount dictated by a float property that changes in a script graph whenever the player takes damage or heals. The graph is intended to have a red tint fall over the screen that gets deeper as the player takes more damage, so at low health the world will become very red.

<img width="2020" height="1266" alt="image" src="https://github.com/user-attachments/assets/cb0e4db4-b659-492e-a1c5-73eadd17591a" />

<img width="1848" height="1094" alt="image" src="https://github.com/user-attachments/assets/8c320b21-3d55-4523-bb24-efe36158bb2a" />
**This is the equation I created to turn the players health into the 0-1 value float input into the LERP node

Question 2: 
Based on week 8's feedback, I changed the sixth sense text to "You feel stalked" which I hope gives a clearer picture of it's intended purpose of showing if an enemy is behind you. I also created an equation that converts the old timer of 1-4 for overheat into 1-100 and display that value on screen instead. There was a light source added to the flamethrower that turns on and off along with the flame particles. I turned the player taking damage from on collision to trigger with an animation event during the attack animation to better match up with when the enemy actually, visibly hits you. I also added a hurt image that turns on and off when you get hit to better allow the player to recognize when they have been hit.

Question 3:
For content, I created a map to give the player a more guided sense of direction for where they must go and give a clearer end point. The player knows the limits on where they can go and the description tells them that they must clear the enemies throughout the map. I also converted the old starting cutscene to incorporate the new map

## Final Devlog

Question 1:
The player will spawn in and search the area for enemies and medicine items. Once the enemies are cleared, the player will interact with the podium at the end to win the game and
"purify" the temple. This vertical slice sets the tone, and core gameplay loop that can be recreated and mixed up through a larger game that leaves plenty of room for more enemy
types, larger maps, and more interesting art/audio assets while clearly presenting the actual features of the game.

Question 2:
As the player's health changes the rendering effect that applies a red tint over the screen getts deeper/lighter. For example as the player takes damage, the equation i created
converts that health into a value from 0-1 that is inputted into the lerp node. This float property is created within the shader graph but is set within my script graphs whenever
the player is hit, on start, as well as whenever the player heals. It works by taking the URP sample buffer (the original screen) and multiplying it by a sample texture 2D node 
inputted with the screen position and a texture2D property defaulted to a red effect. This value and the URP sample buffer are inputted into a LERP node to interpolate between 
the original image and the red image based on an amount dictated by a float property that changes in a script graph whenever the player takes damage or heals. It is the same 
system from milestone 3 as we were told this was allowed. 
<img width="2020" height="1266" alt="image" src="https://github.com/user-attachments/assets/cb0e4db4-b659-492e-a1c5-73eadd17591a" />

Question 3:
My plan for breaking down a large system into smaller pieces more closely aligns with the task step break-downs learned this quarter. The visual/more artistic style never really
helped me however the more list and task focused style did. This system also allows me to have a discrete and refined set of instructions to fulfill when
actually going to make the system that the bubble diagrams don't give. The process goes something like:

1. Identify the major systems required for the core idea (the prompt implies there is already a game idea and that I only need the process for creating my systems)
2. Identify the major components objects required for that specific system (what I already know basically, like if I want to implement audio then I know i need an audio source 
component and clips played in a script)
3. List out each small step to create this task in order to try and identify what I don't know of the process before going into making it and fill in any gaps that might appear
if I were to not do this

If you plan poorly, it may make each system seem easier to make than it actually is since you haven't looked in depth at each task. However planning well will accurately tell 
the difficulty of creating your game which will naturally tell you the scope. It allows you to determine the difficulty of the implementation of each system and identify
potential difficulties before implementation rather than trying to figure it out halfway through with broken code. Knowing this beforehand allows you to plan/change things accordingly
so you can bring yourself back into scope. Thinking through what each system requires components and objects wise also will help identify missing pieces you may not have thought of
initially.

It really helped with the vertical slice project as there were a lot of systems I had never really worked with before so I wasn't aware of what components they would require. Things
like creating animation events and using the cinemachine camera which I had never used I was able to accurately identify through research and planning how long it would take and 
whether or not it was within scope to try and implement as someone who had never touched it and didn't know these things. The research was integral here as using helpful videos and
Unity docs streamlined this process as the process itself would never have been completed on my own trying to figure out unfamiliar components. I found the process unnecessary for
systems I was confident in such as displaying and manipulating UI elements and was able to complete them myself without issue while not using the process. I am confident due to this
fact that it would have added unnecessary time.

## Open-source assets

Audio:
[Flamethrower Effects](https://assetstore.unity.com/packages/audio/sound-fx/weapons/muhguns-148666)
[Zombie Noise](https://assetstore.unity.com/packages/audio/sound-fx/zombie-sound-pack-free-version-124430)

Map:
[Ground Texture](https://assetstore.unity.com/packages/3d/environments/dungeons/cathedral-and-cemetery-kit-29240)
[Building Assets](https://assetstore.unity.com/packages/3d/environments/dungeons/dungeon-modular-pack-295430)

Enemy and Animation:
Mixamo Parasite L Starkie model and various zombie animations: attack, run, idle, death

Items:
[Flamethrower Model](https://www.fab.com/listings/0e0aee5b-6ddf-4e58-b6a1-87b5ad54c750)
[Flamethrower Particle](https://assetstore.unity.com/packages/vfx/particles/free-quick-effects-vol-1-304424)
[Medicine Model](https://assetstore.unity.com/packages/3d/props/first-aid-set-160073)



