
# Legend of Zelda Inspired Game

## Overview
This project is a top-down perspective game developed in Unity, inspired by the classic "Legend of Zelda." The game features procedural dungeon generation, event handling, combat mechanics, and a health system.

## Table of Contents
- [Installation](#installation)  
- [Gameplay](#gameplay)        
- [Features](#features)      
- [Technical Documentation](#technical-documentation)
- [Demo Video](#demo-video)   
- [Requirements](#requirements)
- [UI Elements](#ui-elements)
- [Audio](#audio)
- [How to Play the Game](#how-to-play-the-game)
- [External Assets](#external-assets)

## Installation
1. **Clone the repository:**
   ```bash
   git clone https://github.com/RustamQodirov/210151-Rustam-Zelda.git
   ```
2. **Open the project in Unity:**
   Ensure you are using Unity version 2021.3.5f1 or higher. 
3. **Import necessary assets:**
   Make sure all required assets are properly imported into the Unity project.

## Gameplay
- Navigate through procedurally generated dungeons filled with diverse rooms and corridors.
- Engage in combat with enemies, including birds that shoot projectiles at the player.
- Collect power-ups to enhance abilities and improve combat effectiveness.

## Features
- **Procedural Dungeon Generation**: Automatically creates dungeons with multiple room types, ensuring a unique experience each time.
- **Event Handling**: Interactions with in-game objects provide dynamic gameplay experiences.
- **Combat Mechanics**: Incorporates basic melee and ranged attack systems, with enemies exhibiting unique behaviors.
- **Health System**: Tracks health for both players and enemies, with appropriate game-over conditions.

## Technical Documentation
### Project Architecture
- **Game Manager**: Oversees the overall game state and flow.
- **Dungeon Generator**: Manages the creation of procedurally generated dungeons.
- **Player Controller**: Handles player input and movement mechanics.
- **Event System**: Facilitates interactions with in-game objects and triggers events.
- **Combat System**: Manages combat interactions, including player attacks and enemy behaviors.

### Key Components
- **Dungeon Generation**:![Screenshot 2024-11-02 222652](https://github.com/user-attachments/assets/4c8ea570-f9fe-4faf-81dc-206892bded1d)

 using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public int dungeonWidth = 50;
    public int dungeonHeight = 50;
    public int roomCount = 10;

    private List<Room> rooms = new List<Room>();

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        for (int i = 0; i < roomCount; i++)
        {
            int roomWidth = Random.Range(4, 10);
            int roomHeight = Random.Range(4, 10);
            Vector2Int roomPosition = new Vector2Int(Random.Range(0, dungeonWidth - roomWidth), Random.Range(0, dungeonHeight - roomHeight));
            
            Room newRoom = new Room(roomPosition, roomPosition + new Vector2Int(roomWidth, roomHeight), null, i);
            rooms.Add(newRoom);
            DrawRoom(newRoom);
        }

        // Optionally, connect rooms with corridors
        ConnectRooms();
    }

    void DrawRoom(Room room)
    {
        for (int x = room.BotLeft.x; x < room.TopRight.x; x++)
        {
            for (int y = room.BotLeft.y; y < room.TopRight.y; y++)
            {
                // This assumes you have a method to set tile or create game objects
                SetTile(x, y, true);
            }
        }
    }

    void ConnectRooms()
    {
        for (int i = 0; i < rooms.Count - 1; i++)
        {
            Vector2Int start = rooms[i].BotLeft + new Vector2Int(rooms[i].Width / 2, rooms[i].Length / 2);
            Vector2Int end = rooms[i + 1].BotLeft + new Vector2Int(rooms[i + 1].Width / 2, rooms[i + 1].Length / 2);

            // Draw a corridor between the two rooms
            DrawCorridor(start, end);
        }
    }

    void DrawCorridor(Vector2Int start, Vector2Int end)
    {
        // Draw horizontal corridor
        for (int x = Mathf.Min(start.x, end.x); x <= Mathf.Max(start.x, end.x); x++)
        {
            SetTile(x, start.y, true);
        }

        // Draw vertical corridor
        for (int y = Mathf.Min(start.y, end.y); y <= Mathf.Max(start.y, end.y); y++)
        {
            SetTile(end.x, y, true);
        }
    }

    void SetTile(int x, int y, bool isRoom)
    {
        // Your tile setting logic goes here (e.g., using tilemaps)
        Debug.Log($"Setting tile at: {x}, {y}, Room: {isRoom}");
    }
}

  - `Room.cs`: Defines the different types of rooms used in the dungeon.
    ```csharp
    using UnityEngine;

    public class Room : Node
    {
        public Room(Vector2Int botLeft, Vector2Int topRight, Node parent, int index) : base(parent)
        {
            this.BotLeft = botLeft;
            this.TopRight = topRight;
            this.BotRight = new Vector2Int(topRight.x, botLeft.y);
            this.TopLeft = new Vector2Int(botLeft.x, topRight.y);
            this.Index = index;
        }

        public int Width
        {
            get => (int)(this.TopRight.x - this.BotLeft.x);
        }

        public int Length
        {
            get => (int)(this.TopRight.y - this.BotLeft.y);
        }
    }
    ```

## Demo Video
https://vioo.cc/v/2faEf <======click the link to watch the game
A demo video is provided to showcase gameplay mechanics, features, and design choices. It includes a walkthrough of the gameplay, highlighting combat scenarios and dungeon exploration.

## Requirements
1. **Dungeon Generation**
   - Implement a procedural dungeon generation system that creates a playable area with rooms and corridors.
   - Include at least three different room types and ensure the dungeon is playable and navigable.
   - Create a visual representation of the dungeon using Unity's tilemap system.
   - Provide evidence of testing the dungeon generation process, including screenshots or a short video.

2. **Event Handling and Interactions**
   - Develop an event system that allows for interactions with various objects in the game.
   - Implement at least three different types of interactive objects (e.g., doors, levers, treasure chests).
   - Provide user feedback upon interaction, such as sound effects, animations, or UI prompts.

3. **Combat Mechanics**
   - Create a combat system that enables the player to engage in battles with enemies.
   - Implement basic attack mechanics (e.g., melee and ranged attacks) and include at least one enemy type with unique behaviors.
   - Develop a health system for both the player and enemies, including health points and damage calculations.
   - Ensure appropriate game-over conditions for the player.

4. **Presentation and Documentation**
   - Prepare a video presentation attached to the README.md file, showcasing gameplay mechanics, features, and design choices. The presentation should be 5-10 minutes long and include a live demo of the game.
   - Add a technical document detailing the architecture of your game, including code snippets and explanations of key components.

## UI Elements 
- Health and ammo UI
- Game menu UI
- Game controller

## Audio 
- Game background music
- Weapons sounds: fire, reload, etc.
- Menu sounds
- Character movement sounds

## How to Play the Game
### Keybindings
The game uses fairly standard mouse and keyboard inputs:
- *WASD* to move the player
- *Space* to jump
- Moving the mouse moves the camera
- *Left mouse button* to shoot
- *R* to reload
- *Shift* to dash

### Player and Camera Controls
The game uses standard mouse and keyboard controls, which are common in shooter games. The decision to implement this control scheme is based on the precision a mouse offers compared to controller thumbsticks. 

For camera collision, the early implementation checks slightly behind the camera for objects. A simple linecast from the camera's position is used to prevent it from moving through obstacles:

```csharp
if (Physics.Linecast(camTransform.position + offset, camTransform.position - offset, out var hit))
{
    transform.position = hit.point;
}
```

## External Assets
- Powerup Assets: [Unity Asset Store](https://assetstore.unity.com/packages/3d/props/low-poly-powerups-212079)
- Menu Sound: [Mixkit](https://mixkit.co/free-sound-effects/game/)
- Power Up Sound: [Mixkit](https://mixkit.co/free-sound-effects/game/)
- Jump / High Jump Sound: [Fesliyan Studios](https://www.fesliyanstudios.com/)
- Chicken Prefab: [Unity Asset Store](https://assetstore.unity.com/packages/3d/characters/animals/meshtint-free-chicken-mega-toon-series-151842)
- Background Music: [Fesliyan Studios](https://www.fesliyanstudios.com/royalty-free-music/download/boss-time/2340)
