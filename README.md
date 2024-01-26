# ZigZag Unity Game

An endless runner game built in Unity where players navigate a ball along a zigzagging path. Tap to change direction and stay on the platforms as long as possible.

![ZigZag Gameplay](https://github.com/The-Odd-Institute/CSharp_Unity_Game/blob/main/zigzag.gif)

## Gameplay

- Tap/click to switch between X and Z axis movement
- Stay on the platforms - falling ends the game
- Collect pickups scattered throughout the path
- Speed increases as you progress
- Track your score and beat your high score

## Technologies

- **Engine**: Unity
- **Language**: C#
- **Physics**: Unity 3D Rigidbody
- **UI**: TextMeshPro

## Features

### Core Mechanics
- Tap-to-switch direction gameplay
- Progressive difficulty (speed increases over time)
- Gravity-based fall detection

### Procedural Generation
- Dynamic block spawning at 0.2 second intervals
- Random direction alternation
- Pickup items spawn with 30% probability

### Visual Effects
- Trail/ghost effect with opacity fade
- Smooth camera following with lerp interpolation

### Scoring System
- Score based on blocks traversed
- Pickup collection counter
- High score persistence using PlayerPrefs

## Project Structure

```
Assets/
├── Scripts/
│   ├── PlayerController.cs      # Player movement and input
│   ├── BlockSpawner.cs          # Procedural platform generation
│   ├── GameManager.cs           # Game state and scoring
│   ├── CameraFollow.cs          # Smooth camera tracking
│   ├── ObjectCrossingCheck.cs   # Collision and scoring
│   ├── TrailScript.cs           # Ghost trail effect
│   ├── TrailOpacity.cs          # Trail fade animation
│   ├── UI_Script.cs             # Score display
│   └── Modes.cs                 # Game state enum
├── Materials/
├── Prefabs/
├── Physics Materials/
└── Levels/
```

## Game States

- **Paused**: Initial state before first tap
- **Running**: Active gameplay
- **Over**: Player has fallen off the path

## Requirements

- Unity 2019.4 or later
- Visual Studio (for C# development)
