using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthSystem
{
    // Variables
    public int health;
    public string healthStatus;
    public int shield;
    public int lives = 3;


    // Optional XP system variables
    public int xp;
    public int level;

    //Vector3 startingPosition = Vector3.zero;    
    
    public HealthSystem()
    {
        ResetGame();
    }    
    
    public string ShowHUD()
    {
        
        // Implement HUD display      
        return $"Health: {health}\nShield: {shield}\nLives: {lives}\nStatus: {healthStatus}";
    }
   
    public void TakeDamage(int damagePassed)
    {
        int damage = damagePassed;      

        if(damage > 0)
        {
            if (shield > 0)
            {
                // If the damage would take shield below 0, decrement the remaining damage to health, and reduce shield by its current value
                if ((shield - damage) < 0)
                {
                    health -= damage - shield;
                    shield -= shield;
                }
                //otherwise. just decrement by damage
                else
                {
                    shield -= damage;
                }
            }
            //If 
            else if (health > 0)
            {
                //Check if the damage would take players health below 0, if yes: reduce health by its current value
                if (health - damage < 0)
                {
                    health -= health;
                }
                //otherwise. just decrement by damage
                else
                {
                    health -= damage;
                }

            }
        }
        //if shield is active, damage will affect it instead of health
        
        
    }
    public string HealthStatus()
    {
        if(health < 10)
        {
            return healthStatus = "Imminent Danger";
        }
        else if (health < 50)
        {
            return healthStatus = "Hurt";
        }
        else if (health < 75)
        {
            return healthStatus = "Hurt";
        }
        else if (health < 90)
        {
            return healthStatus = "Healthy";
        }
        else
        {
            return healthStatus = "Full HP";
        }
    }

    public void Heal(int hp)
    {                
        //If player is less than 100 health, player gets 20 health from red pickups.
        if (health < 100)
        {
            //if the player would heal above 100, heal instead by the difference between max health and curent health
            if (health + Math.Abs(hp) > 100)
            {
                health += 100 - health;
            }
            //otherwise. just heal by a flat amount
            else
            {
                health += hp;
            }

        }
    }

    public void RegenerateShield(int hp)
    {
        // If health is at 100, shield pickups will increase shield capacity
        if(health == 100)
        {
            //if shield isnt full
            if (shield < 100)
            {
                //if regenerate shield would be above max shield. increase shield by the difference between max shield and current shield
                if (shield + Math.Abs(hp) > 100)
                {
                    shield += 100 - shield;
                }
                //otherwise. just increase shield by flat amount
                else
                {
                    shield += hp;
                }
            }
        }
        // If player has less than 100 health, shield pickups will instead contribute to health.
        else
        {
            //same logic as heal, just applied in the case that shield would be above 100            
            if (health + Math.Abs(hp) > 100)
            {
                health += 100 - health;
            }
            else
            {
                health += hp;
            }            
        }        
    }

    public void Revive()
    {
        if(health == 0 && lives > 0)
        {            
            ResetGame();
            lives -= 1;
        }        
    }

    public void ResetGame()
    {        
        health = 100;
        shield = 100;      
    }

    // Optional XP system methods
    public void IncreaseXP(int exp)
    {
        // Implement XP increase and level-up logic
    }
}