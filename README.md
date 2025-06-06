# How to play
Ball Mechanics
* Use A and D keys to aim ball direction
* Use W and S keys to charge/decharge ball
* Use Spacebar to hit the ball with the current charge

Camera Mechanics
* Use Left/Right arrow keys to rotate camera
* Drag and hold mouse to free rotate around player
* Use Up/Down Arrow keys to zoom in/out

Get the ball in the hole with fewest number of strokes!

# Group Member Implementations

**Jason Webster : Audio Engineering and UI Implementation**

As the Audio Engineer for Golf Without Friends, I designed and implemented a fully custom audio system without using any third-party or prebuilt asset packs. All sound effects were recorded using everyday household items such as a putter and ball, metal sheets, plastic cups, tinfoil, rubber bands, and wood then processed in Audacity to match the desired tonal and spatial effect. Commentary lines were self-recorded using VoiceMemo on an iPhone, carefully edited for clarity, timing, and emotional delivery. These sounds were then exported into Unity and integrated through a combination of AudioSource, AudioClip, and AudioMixer components.
The audio system includes multiple layers of dynamic feedback:
•	Collision-triggered effects (e.g., wood drops, bell rings, wall bounces) are activated via Unity's OnCollisionEnter and OnTriggerEnter methods, each mapped to context-specific objects like obstacles or goals.
•	Voice commentaries are triggered upon specific game events, such as successful putts, failed attempts, or idle moments. To avoid repetition and enhance player engagement, a randomization loop was implemented using arrays of clips and Random.Range() to select one clip per event category (e.g., misses, near-misses, hole completions).
•	Ambient background loops for each hole were layered using low-volume continuous playback of environmental effects such as wind, birds, or lava bubbling, assigned based on scene-specific tags.
•	Feedback tuning was essential to immersion pitch, gain, reverb, and stereo spread were adjusted in Audacity to distinguish between near/far interactions, indoor/outdoor acoustics, and emotional tone (e.g., sarcastic versus congratulatory lines).
This sound architecture was built around a core goal: to reinforce player actions with memorable and personalized auditory cues, giving each stroke, bounce, and success its own character.
In parallel, I also served as the UI Developer, designing and implementing all major interface elements across the game. This included the Main Menu, in-game Help Canvas, dynamic Scorecard (not implemented), and responsive Pause/Reset Menus. The ESC key triggers the active menu, which adapts to game context appearing automatically in Practice Mode hubs or remaining hidden during gameplay unless summoned. A Game Mode Manager prefab ensures mode persistence across scenes, enabling or disabling UI elements like the Scorecard dynamically. Resetting a hole or game restores ball position, state, and score logic while maintaining fluid player control without requiring manual UI actions.


**Jacob Kolster : Camera Mechanics and Level 2**

All of the functionality for rotating the camera via the mouse and arrow keys, as well as for zooming it in and out with the up/down arrow keys, is implemented as a camera script component called `CameraController.js`, and located in the `Assets/Scripts` directory. Essentially, the camera has a predefined Vector3 attribute called offset, representing it's default offset from the player. Holding and draggin the mouse horizontally and vertically changes the two variables `yaw` and `pitch`. Each frame, the position of the camera is determined by rotating the default offset by the value of yaw and pitch. Rotating using the right and left arrow keys is implemented similarly by changing the `yaw`. Lastly the zoom is implemented by changing the scale of the default offset vector when receiving inputs from the up/down arrows, with minimum and maximum zoom beign easily implemented with conditional incrementing/decreasing of the scale. I then exapnded these camera capabilities by adding a free camera mode. Upon pressing "f", the player activates/deactivates free camera mode where WASD and the arrow keys/mouse are used to move and look around respectively, and Space and Shift can move the camera up and down. This requires deactivating the player's aim/hit script while in this mode.

Additionally, I created and designed level two. For this Western theme, I made three segements: a cactus plinko, TNT lanes, and a bull ring. Entering the cactus plinko is done through a dynamically moving portal controlled by the `Scripts/MovingPortal.cs` script, such that the fall becomes more randomized. Upon designing the plinko board, I created three portal outlets/funnels which teleport the player to lanes with varying levels of TNT. Upon hitting a TNT barrel, it explodes with a particle effect that I created, and disappears for the rest of the duration of the level, to make the game progressively easier. At the end of each lane is a ramp which the player takes to the bull ring, whereby two bulls patrol. One follows an elliptical orbit around the ring, which I programmed in `Scripts/RoamingBull.cs` such that its rotation and position is determined by its increasing angle about an origin. The other charges towards the hole with a simple Unity Animation that I designed. Both are equipped with triggers and colliders that will teleport the player to the last location on contact.

**Nathan Cook : Golf Ball Controller Features and Complex Asset Creation**

In this project, I designed and implemented the full golf ball control system, which serves as the foundation of the core gameplay. I created an intuitive aiming mechanic where players use the A and D keys to rotate their shot direction, and W and S keys to control the shot’s power. This power level is displayed in real time through a custom dynamic power meter UI, offering immediate visual feedback to help players line up their shots with precision.

To ensure the ball responded realistically during play, I developed a physics-based movement system using Unity’s Rigidbody component. I fine-tuned the linear and angular damping to simulate real-world deceleration — making the ball launch quickly, then naturally slow over time. I also introduced subtle collision dampening to allow the ball to bounce slightly off walls while gradually losing momentum, adding to the sense of realism and polish.

For accurate and consistent aiming, I implemented an independent AimPivot system that stays aligned with the ball’s position while always maintaining a flat, horizontal orientation. This guarantees that the aim direction remains level, even after the ball spins or rolls across uneven terrain. Complementing this system, I built a visual Aim Arrow that clearly represents the shot direction. The arrow automatically disappears while the ball is in motion and reappears once it stops, keeping the player focused and the interface clean.

In addition to programming gameplay mechanics, I created and imported a variety of 3D assets used throughout the later levels. All assets were modeled in Tinkercad and exported as .obj files before being imported into Unity. These included themed props such as a portal, multiple cactus variants, fire rings, and the circular moving platforms featured in the lava level. I handled the full asset integration pipeline — adjusting scale, orientation, materials, and positioning in Unity to ensure each object functioned correctly in-game.

I also implemented behavior for several of these assets. For the fire rings, I constructed a trigger system using a ring of box colliders to simulate a torus-shaped hitbox that resets the player if touched, while still allowing clean passage through the ring’s center. For the lava platforms, I developed a timed movement script that causes the platforms to sink below the lava and rise again on a cycle, adding dynamic gameplay timing challenges.


**Nick Johnson : Level & Environment**

In this project, my main focus was on both level design and creation. I was the main designer and creator for Level 1 & Level 2, in addition to being a codesigner and cocreater for the final level. I would conceptualize all of these builds before implementation by drawing them out on the notepad and then began to make all the assets needed for each level at the beginning. I will go into depth on each of the levels and how I made an impact.

Level 1 served as a basic introduction to the gameplay mechanics of the putt putt golf game. This level is relatively simple and clean, meant to clearly demonstrate the core concept. One of the standout features I added is a speed boost on a ramp, which introduces a dynamic element and hints at the more complex mechanics to come.

I also took the lead on Level 2, where I focused on experimenting with theme and atmosphere. This level uses a dark, neon-lit design to explore how visual style can impact gameplay. All assets made here were meant to be aligned with the main theme and make an impact on the gameplay of the player. I also incorporated more interactive elements here, including a teleporter and functioning pinball flippers, which pushed our use of dynamic obstacles further. This was a turning point where the gameplay began to evolve beyond the basics.

As mentioned earlier, the final level was designed by all four members of our team, with the creation mostly done alongside Nathan Cook. This level is where we started integrating Blender to improve both the look and functionality of the environment. My primary contribution was building the volcano and fireball assets, which became central to the level’s visual identity and gameplay hazards. This level represents our most advanced work, both creatively and technically, and showcases the collaboration that brought the project together.
