using System;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public abstract class Projectile
    {
        public string Name { get; set;}
        public int Value { get; set;}   

    }

    public class Wrentch : Projectile
    {
        public int Damage { get; set;} 
        // damage = the amount of time the distraction takes
    }
    
    
    
    public class EquipmentManager
    {
        // Current weapon slot
        public Wrentch CurrentWeapon { get; private set;}

        public void Equip(Wrentch newWeapon)
        {
           CurrentWeapon = newWeapon;
            Console.Write($"Equipped: {newWeapon.Name}");
        }
    }
    // im not sure what this is talking about
    // google says that it is an OOP 

}
