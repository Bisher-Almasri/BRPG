# BRPG
BRPG is meant to be a rpg game written in unity, i plan to add a factory part to it when i can

![BRPG gameplay](SCR-20261108-pway.png)

# Why i made this
I wanted to build an rpg in unity and add a factory part to it later, so i started with the base of it: moving around, a world, and an inventory that new items can be added to easily. I also made all the assets myself, so everything you see (the axe, the tree, the log) is modeled and textured by me.

It was made for terra, so right now it is a small MVP of the idea and not the full game.

# What is in it right now
- First person movement with mouse look and jumping
- A world with a floor, a tree and a log (you can't walk through them, they have colliders)
- An inventory system built on scriptable objects, with stacking support
- A hotbar UI with 9 slots
- An axe that i modeled, textured and made into an item

# Controls
| Key | What it does |
| --- | --- |
| W A S D / arrow keys | Move |
| Mouse | Look around |
| Space | Jump |

Gamepad works for move, look and jump too. Use, interact, sprint and crouch are in the input map already but are not hooked up to anything yet.

# How inventory works

Items are a scriptable object in unity

```cs
// Item.cs
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public bool isStackable = false;
    public int maxStack = 1;
    public GameObject itemPrefab;
}
```

So i can just right click in the project window, go to Create > Inventory > Item and fill it in to add a new item. `Axe.asset` is an example of one.

`InventoryManager` keeps a list of `InventorySlot`s (an item and an amount). When you add something it fills up existing stacks of that item first and then moves on to empty slots, and anything that does not fit gets returned so nothing is lost silently. Items that are not stackable just use one slot each.

The hotbar UI is the part that is not finished. Items get added to the inventory but the hotbar does not show them yet.

# Models
I made the models in blender and i did textures in photopea

Models were not too hard but i havent used blender in a while and UV maps made my head hurt

The tree and the log used to be plain model files with no collision and they were floating a bit above the ground, so you could walk right through them. They are now prefabs (`Tree.prefab` and `Log.prefab`) with convex mesh colliders that match the real shape, and they sit on the floor.

# How to test
The link to test is here: https://play.unity.com/en/games/59c3bed3-c8b6-48f7-8167-cad2e8e62694/build

To run it yourself:
1. Install Unity `6000.6.8f1` (it uses URP and the new Input System)
2. Make sure you have [Git LFS](https://git-lfs.com) installed before cloning, the `.blend` files and images are stored with it
3. Open the project folder in Unity and open `Assets/Scenes/SampleScene`
4. Press play

# Project layout
```
Assets/
  Scenes/SampleScene.unity   the only scene
  Scripts/                   movement, input map and the inventory code
  Axe.*  Tree.*  Log.*       blender models, textures and prefabs
  Materials/                 materials
  Settings/                  URP and build settings
```

# What is next
- Finish the hotbar so it shows what is in the inventory
- Picking up items and using the axe on trees
- Hook up the rest of the inputs (sprint, crouch, interact)
- The factory part

# Reviewer note
For the terra reviewer, the game is incomplete as i did not have time to polish it up for this seek as i got really busy, i did the most MVP i could
