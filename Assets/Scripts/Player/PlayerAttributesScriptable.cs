using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerAttributes", fileName = "PlayerAttribute")]
public class PlayerAttributesScriptable : ScriptableObject
{
   //Ammo attributes
   public int maxAmmo;
   public int currentAmmo;
   public int ammoLevel;
   
   //Damage attributes
   public int rocketDamage;
   public int damageLevel;
   
   //Defensive attributes
   public float maxHealth;
   public float currentHealth;
   public int healthLevel;
   
   //In-Game values
   public int money;
   public int gem;
}
