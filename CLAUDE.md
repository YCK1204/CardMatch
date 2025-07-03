# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

CardMatch is a Unity 2D memory card matching game developed as part of "내일배움캠프 유니티 11기" (Tomorrow Learning Camp Unity 11th). The game features fruit-themed cards with three difficulty levels and a 5-second time limit per turn.

### Development Language Notes
- 프로젝트는 Unity 2D 모바일 게임으로, 카드 매칭 게임 장르에 속함
- 게임 메커니즘은 카드를 뒤집어 짝이 맞는지 확인하는 방식
- 한국어로 개발 및 커뮤니케이션 진행 예정

## Unity Version & Dependencies

- **Unity Version**: 2022.3.17f1
- **Render Pipeline**: Universal Render Pipeline (URP) 14.0.9
- **Key Dependencies**:
  - TextMeshPro 3.0.6
  - Unity UI (uGUI) 1.0.0
  - Rounded Corners UI package (external GitHub dependency)
  - Newtonsoft JSON 2.0.0

## Build Commands

This is a Unity project, so build commands are executed through the Unity Editor:

- **Open Project**: Open Unity Hub → Add → Select `/CardMatch` folder
- **Build Settings**: File → Build Settings → Select target platform
- **Build**: Click "Build" or "Build and Run"
- **Play in Editor**: Press Play button in Unity Editor

No external build scripts or CLI commands are configured.

## Core Architecture

### Game Flow
1. **StartScene**: Main menu with level selection
2. **MainScene**: Game board with card matching gameplay

### Key Singletons
- **GameManager**: Central game controller managing card matching, timer, and win/lose conditions
- **AudioManager**: Persistent audio system with volume controls (BGM/SFX)
- **GameInitManager**: Game initialization and state management

### Card System
- **Board.cs**: Spawns cards in 4-column grid layout based on difficulty
  - Easy: 16 cards, Normal: 20 cards, Hard: 24 cards
- **Card.cs**: Individual card behavior with flip animations and matching logic
- **CardRotate.cs**: Handles card rotation animations using Unity Animator

### Difficulty Levels
- Easy: 4x4 grid (16 cards)
- Normal: 4x5 grid (20 cards) 
- Hard: 4x6 grid (24 cards)

### Asset Organization
- **Sprites**: Fruit-themed card images in `Assets/Resources/Sprites/` (fruit0.gif through fruit11.gif)
- **Prefabs**: Reusable game objects in `Assets/Resources/Prefabs/`
- **Scripts**: Organized by category in `Assets/Scripts/` with UI and Utils subfolders

### Scene Management
- Level selection stored in static `Level.selectLevelindex`
- Scene transitions handled through `SceneManager.LoadScene()`

## Development Notes

### Code Conventions
- Uses Unity C# naming conventions (PascalCase for public members)
- Singleton pattern implemented with null checks and DontDestroyOnLoad
- Coroutines used for timed operations (card matching delays, animations)

### Audio System
- Separate volume controls for BGM and SFX
- AudioManager persists across scenes
- Volume settings maintained throughout gameplay

### UI Architecture  
- UI scripts separated in `Assets/Scripts/UI/` folder
- Popup-based system for game results and level selection
- Uses Unity's built-in UI system with Canvas components

## Common Tasks

### Adding New Card Types
1. Add new fruit sprite to `Assets/Resources/Sprites/`
2. Update sprite loading logic in `Card.cs` if needed
3. Ensure new sprites follow naming convention: `fruit{index}.gif`

### Modifying Difficulty
1. Update card counts in `Board.cs` difficulty logic
2. Adjust card scaling and positioning if needed
3. Test layout with new card counts

### Audio Changes
1. Add audio clips to AudioManager
2. Call appropriate AudioManager methods from game scripts
3. Ensure volume controls affect new audio sources

## Scene Architecture Insights
- 현재 씬은 2개야 StartScene과 MainScene이 있는데 StartScene에서 오디오 설정, 게임 스타트, 게임 나가기가 있어
- MainScene에서는 StartScene에서 게임 난이도를 선택을 하고 들어오는데 난이도에 따라 카드 수가 달라 난이도는 현재 3단계가지 있어