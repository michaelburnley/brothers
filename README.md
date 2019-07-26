# Introduction

Brothers is a 2D SHMUP (Shoot 'em Up) built in Unity drawing inspiration from some of my favorite arcade games (Raiden, Strikers 1945, etc.) as well as from some later games from a _slightly_ different genre (Enter the Gungeon, Nuclear Throne.)

# Game Loop

1. Choose Upgrade
2. Start Level 
3. Progress through level, destroying enemies
4. Encounter with Boss

# Architecture

The entirety of this project is based around two things:

- Events
- Scriptable Objects

My goal is to build a foundation for development of other games in general to make my life much easier. I'm using the [EventManager Tutorial](https://learn.unity.com/tutorial/create-a-simple-messaging-system-with-events#5cf5960fedbc2a281acd21fa) as a as the basis for my messaging system. So far its been working exactly as planned.

[Scriptable objects](https://docs.unity3d.com/Manual/class-ScriptableObject.html) are an incredibly powerful way of seperating concerns in Unity. My goal is to have no one script controlling its own data (or at the very least not **initializing** its own data.)

## Systems

I've intentionally kept the scope of systems fairly small so that (outside of asset creation) I could "finish" this game within a month of development time.

### Upgrades

Typically in games of this nature, upgrades are gained and lost during the level, incentivizing the player to stay alive in order to keep the upgrades they have.

I'm still following this rule (as I just think that's a good system) but I'm aiming for a game where you lose the player's **last obtained upgrade** upon being hit and once all upgrades have been lost and the player has been hit again, it is a game over. In this way I hope to circumvent creating a difficulty option on anything other than choosing the upgrades you want.

Because of this, I'm adding the upgrade system to start of each level rather than the end. This means a choice upon starting the game:

1. Shield (Easy)
2. Bigger Gun (Normal)
3. Missiles (Hard)

The shield is the only one that behaves differently, allowing for the player to be hit a maximum of 3 times before losing upgrades.
