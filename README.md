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

Custom Sound Effects
All sound effects used in this project were custom-recorded. I initially attempted to use an external microphone but ultimately recorded all sounds using the iPhone Voice Memos app for simplicity and consistency. I performed and recorded all voice commentary myself. Recordings were imported into Audacity, where I clipped, normalized, and exported each as a WAV file for compatibility with Unity. All sound effects used in the game were original and created specifically for this project. No third-party audio libraries were used.

Sound Sources:\
Cup sound: Real golf ball dropped into a coffee mug.\
Soft wood impact: Ball rolled into a baseboard.\
Hard wood impact: Ball dropped onto a wood plank.\
Metallic (bell) sound: Ball dropped onto an upside-down cooking pot.\
Glass impact: Ball rolled into a glass bottle.\
Putting stroke: Recorded using a real golf ball and putter.

Audio Integration
All WAV files were imported into Unity and attached to appropriate game objects using AudioSource components. The GolfPuttSound script was written to manage playback. This script includes methods for playing specific clips based on in-game triggers and collisions, such as:
PlayPuttSound()
BallInTheCupSound()
NiceShot()
WallHitSound()
AlmostHadIt()

Sounds are triggered through Unity’s event system, including collision detection and trigger zones. Audio playback is handled independently to allow overlapping clips where needed.

UI Implementation and Shot Counter
I implemented a real-time score panel UI in the top-right corner of the screen using Unity's Canvas system and TextMeshPro.

This panel displays:\
Current hole number\
Par value\
Number of shots taken

The HoleInfoUI script manages the score panel and includes the following functionality:\
IncrementShot() is called each time the player shoots.\
ResetShots() is called when the ball is reset after entering the hole.

The score panel updates dynamically based on player interaction, with all text elements updated via the Unity Inspector and hooked directly into the GolfBallController and HoleTrigger scripts.

**Jacob Kolster : Camera Mechanics**

All of the functionality for rotating the camera via the mouse and arrow keys, as well as for zooming it in and out with the up/down arrow keys, is implemented as a camera script component called `CameraController.js`, and located in the `Assets/Scripts` directory. Essentially, the camera has a predefined Vector3 attribute called offset, representing it's default offset from the player. Holding and draggin the mouse horizontally and vertically changes the two variables `yaw` and `pitch`. Each frame, the position of the camera is determined by rotating the default offset by the value of yaw and pitch. Rotating using the right and left arrow keys is implemented similarly by changing the `yaw`. Lastly the zoom is implemented by changing the scale of the default offset vector when receiving inputs from the up/down arrows, with minimum and maximum zoom beign easily implemented with conditional incrementing/decreasing of the scale.

**Nathan Cook : Golf Ball Controller Features**

In this project, I designed and implemented the full golf ball control system, including aiming, shooting, and movement physics. I developed an intuitive aiming mechanic where the player can rotate the shot direction using the A and D keys, and adjust shot power with the W and S keys, displayed visually through a dynamic power meter UI. I created a realistic ball physics system where the ball launches quickly and slows down naturally due to carefully tuned linear and angular damping, along with collision dampening when hitting walls.

To support clear aiming feedback, I built an independent AimPivot system that follows the ball's position while maintaining a consistent horizontal orientation, ensuring that the aim direction stays parallel to the ground even after the ball spins, bounces, or rolls over uneven terrain. I also designed and implemented a visual Aim Arrow that accurately represents the shot direction, automatically hiding whenever the ball is moving and reappearing when it stops.


**Nick Johnson : Level & Environment**

For the Hub level shown in our Proof of Concept build, I created the level and environment. I started with the ground floor which had a trigger placing the ball back to the start position when they came into contact. Next, I created the Prefabs for both the walls and the floors with textures grabbed from the Unity Asset Store in order for easy duplication. With these, I formed the normal route to the hole with a single jump and a 90 degree turn. For the hole, based on time constraints, I had to create a square hole as you can't make any negatives in the 3D Objects in the game. I plan on making a hole in a 3D Modeling Software to use in the rest of the game. 

Once I created the first path, I added another higher skilled jump with a speed boost attached to it for more variability in the level. The Speed boost is a trigger placed on floor of the path that triples the velocity of the ball when a collision is detected. Lastly, I added another texture to the golf ball to make it more realistic.
