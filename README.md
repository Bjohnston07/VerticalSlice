# GDIM33 Vertical Slice
## Milestone 1 Devlog

### Question 1

The UI visual script graph controls all UI text and a button right now. When queued by scene variables such as health, medicine count, or overheat, the texts on screen will appear
or change. Diving deeper into each individual function the ones for health, medicine count and overheat are pretty much the same. There is a Text Mesh Pro UGUI object on the canvas
to represent each one. Each of these has a variable reference within the UI object variables. The player graph is what manipulates the scene variables referring to how much health 
the player has, how overheat is managed, and how much medicine you have collected. The UI graph takes those and stes their respective UI text elements to those values on update. There
is also a reference to a button in the scene and some text that refers to when the player dies that is off by default. When the currentHealth scene variable hits 0, the UI graph will
unlock the cursor and turn on that text and button the player can click to reload the scene or "restart" the game.
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
