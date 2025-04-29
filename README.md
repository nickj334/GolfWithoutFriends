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
