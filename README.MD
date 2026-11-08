# BRPG
BRPG is meant to be a rpg game written in unity, i plan to add a factory part ot it when i can

![BRPG gameplay](SCR-20261108-pway.png)

# How inventory works

Items are a scriptalbe object in unity

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

So i can jst attach it to a item to add

# Models
I made the models in blender and i did textures in photopea

Models were not too hard but i havent used blender in a while and UV maps made my head hurt

# How to test
The link to test is here: https://play.unity.com/en/games/59c3bed3-c8b6-48f7-8167-cad2e8e62694/build

# Reviewer note
For the terra reviewer, the game is incomplete as i did not have time to polish it up for this seek as i got really busy, i did the most MVP i could