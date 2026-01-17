# 🔫 KILLER — Modular FPS Systems Showcase (Unity)

**KILLER** is a first-person shooter prototype built as a **systems-driven, feature-based Unity project**.  
The focus of this project is not content or visuals, but **clean gameplay architecture, modular systems, and incremental feature development**.

This repository showcases how complex gameplay mechanics can be built step-by-step using **feature branches**, clear Git history, and maintainable C# code.

---

## 🎮 Gameplay Overview

- First-person combat against AI-controlled robotic enemies  
- Multiple weapon types with distinct behaviors  
- Physics-based interactions and visual feedback  
- Modular systems designed for extension and experimentation  

The player fights waves of robots using different weapons, manages ammo and pickups, and survives in a controlled arena-style environment.

---

## 🧠 Design Philosophy

This project was developed with the following principles:

- **System-first design** — gameplay built from independent, reusable systems  
- **Feature-based development** — each major mechanic developed in its own branch  
- **Data-driven configuration** — weapons and behaviors defined using ScriptableObjects  
- **Clear separation of concerns** — logic, visuals, input, and UI decoupled  
- **Incremental complexity** — features added gradually and tested in isolation  

The goal was to simulate **real-world gameplay engineering workflows**, not rapid prototyping.

---

## 🧩 Implemented Systems

### 🔫 Weapon System
- Raycast-based shooting with layer filtering
- Automatic and single-fire weapons
- Weapon recoil using Cinemachine Impulse
- Weapon zoom with smooth FOV transitions
- Muzzle flash, hit VFX, and shooting animations
- Weapon data stored in ScriptableObjects

### 📦 Ammo & Pickup System
- Ammo tracking and enforcement
- Ammo pickups and weapon pickups
- Base pickup inheritance for extensibility
- Weapon equip / unequip and switching logic

### 🤖 Enemy & AI Systems
- Enemies powered by NavMeshAgent for player tracking
- Health and damage system
- Death animations and explosion VFX
- Physics-based explosion damage using `Physics.OverlapSphere`
- Automated turret enemies with independent targeting logic

### 🎯 Combat Feedback & Effects
- Screen shake recoil
- Impact VFX on raycast hits
- Explosion gizmos for debugging and visualization
- Dynamic UI elements for player shield and weapon state

### 🧠 Game Flow & State
- Win condition system
- Enemy spawn gates with timed logic
- Debug tools (God Mode, debug keybindings)
- Event-driven UI handling via Unity Event System

---

## 🧱 Architecture Highlights

- Feature branches used for **every major gameplay system**
- Clean and readable commit history showing real progression
- Systems built to be **replaceable and extensible**
- Debugging and visualization tools added during development
- Focus on maintainability rather than shortcuts

This repository intentionally preserves the full Git history to demonstrate **how the game evolved**, not just the final result.

---

## 🛠️ Technology Stack

- **Engine:** Unity
- **Language:** C#
- **Core Systems:** NavMesh, Physics, Animator, ScriptableObjects
- **Camera:** Cinemachine
- **UI:** TextMeshPro + Unity Event System
- **Version Control:** Git (feature-branch workflow)

---

## 📂 Development Approach

Development followed a clear progression:

1. Core FPS movement and input
2. Shooting and raycast system
3. Weapon data abstraction
4. Enemy AI and health systems
5. Combat feedback and effects
6. Game flow, UI, and polish
7. Debugging and refactoring

Each step was isolated, tested, and merged independently.

---

## 🧪 Intended Purpose

This project is **not a finished game**.

It is a **gameplay systems showcase**, created to demonstrate:
- Gameplay programming skills
- System design thinking
- Clean Git workflows
- Debugging and iteration discipline

---

## 👤 Author

**Behzad Moloudi**  
Gameplay / Systems Programmer  
2025

---

## ⚠️ Note

Assets used are for prototyping and educational purposes only.  
This project is intended as a technical showcase, not a commercial product.
