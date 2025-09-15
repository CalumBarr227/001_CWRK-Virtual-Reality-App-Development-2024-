# VR Hotel Reception Hall - Mixed Reality Development Module
This project was developed as part of the **Mixed Reality Development** module at university. It is a fully interactive **VR hotel reception hall** built in **Unity** for the **Meta Quest**.

Users can explore the hall, interact with furniture and decorations, experience the automatic check-in system through the use of VR mechanics.

The project required me to use the **XR Interaction Toolkit** along with custom C# scripts to implement immersive VR interactions, including teleportation-based navigation, object grabbing, throwing, attaching, and rearranging.

## Features
### 1. Environment
- Decorated reception hall with textured floor, walls and ceiling
- Decorative elements include lights, art etc
- Furniture includes reception desk, sofas, tv, tables, hat hooks etc

### 2. VR Interactions
- **Snap Turning**: Rotate in place without physically turning
- **Teleportation** Small circular carpets on the floor you can use to teleport around and anchors with custom reticles
- **Pick Up / Grab Objects**: Pick up objects like hats, tennis ball, tennis racket, luggage, scanner, including objects with handles
- **Throw Objects**: Realistic throwing mechanics for interactive objects
- **Attach Objects**: Snap objects into sockets, for example hang hats or art on hooks
- **Rearrangement** Move objects around and swap positions of wall art

## 3. Custom VR Devices & Interactions
### VR Scanner
- Open/closes screen when picked up and put down
- Activates laser when trigger is pressed
- Displays name and position of targeted objects

### Automatic Check-In System
**VR Number Pad**
- Buttons change colour when touched or hovered over
- Displays entered code sequence on screen next to keypad
- Correct code spawns a keycard, incorrect input resets the keypad

**VR Keycard Reader**
- Swipe keycard through reader to unlock door
- Requires minimum swipe distance for success

**VR Sliding Door**
- Only movable after keycard unlocks door
- Heavy door movement

## Controls & Interaction Guide
- **Teleportation**: Point to circular carpets to teleport to desired area
- **Grab/Pick Up**: Use grab button to interact with objects
- **Throw**: Release object while moving controller
- **Attach/Rearrange**: Place objects in sockets or swap wall art
- **Check-In System**:
  - Enter code on number pad
  - Swipe keycard through reader
  - Slide door to open and close

## Development Notes
- Custom VR interactions implemented via **C# scripts** using XR Interaction Toolkit API
- Environment and furniture built using given prefab from labs and free Unity assets
- Developed as part of the **Mixed Reality Development module** at university
