using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Test_TakeDamage_OnlyShield();
        Test_TakeDamage_OnlyHealth();
        Test_TakeDamage_Both_HealthAndShield();
        Test_TakeDamage_ReduceToZero();
        Test_TakeDamage_HealthAndShield_ToZero();
        Test_TakeDamage_NegativeInput();
        Test_Heal_NormalHealing();
        Test_Heal_HealingAtMax();
        Test_Heal_NegativeInput();
        Test_RegenerateShield();
        Test_RegenerateShield_AtMax();
        Test_RegenerateShield_NegativeInput();
        Test_Revive();
        Test_HealthStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    void Test_TakeDamage_OnlyShield()
    {
        HealthSystem system = new HealthSystem();
        system.shield = 100;               
        
        system.TakeDamage(10);

        Debug.Assert(90 == system.shield);                           
    }
    
    void Test_TakeDamage_Both_HealthAndShield()
    {
        HealthSystem system = new HealthSystem();
        system.shield = 100;
        system.health = 100;        

        system.TakeDamage(110);

        Debug.Assert(0 == system.shield);
        Debug.Assert(90 == system.health);       
    }

    void Test_TakeDamage_OnlyHealth()
    {
        HealthSystem system = new HealthSystem();      
        system.health = 100;
        system.shield = 0;
        
        system.TakeDamage(10);
                    
        Debug.Assert(90 == system.health);        
    }
    void Test_TakeDamage_ReduceToZero()
    {
        HealthSystem system = new HealthSystem();        
        system.health = 100; 
        system.shield = 0;
        
        system.TakeDamage(100);        
               
        Debug.Assert(0 == system.health);       
    }

    void Test_TakeDamage_HealthAndShield_ToZero()
    {
        HealthSystem system = new HealthSystem();
        system.health = 100;
        system.shield = 100;

        system.TakeDamage(200);

        Debug.Assert(0 == system.health);
        Debug.Assert(0 == system.shield);
    }
    void Test_TakeDamage_NegativeInput()
    {
        HealthSystem system = new HealthSystem();
        system.health = 100;
        system.shield = 100;

        system.TakeDamage(-10);
                
        Debug.Assert(100 == system.health);
        Debug.Assert(100 == system.shield);
    }
    void Test_Heal_NormalHealing()
    {
        HealthSystem system = new HealthSystem();
        system.health = 80;
        system.shield = 0;

        system.Heal(20);

        Debug.Assert(100 == system.health);        
    }
    
    void Test_Heal_HealingAtMax()
    {
        HealthSystem system = new HealthSystem();
        system.health = 100;
        system.shield = 0;

        system.Heal(20);

        Debug.Assert(100 == system.health);
    }
    
    void Test_Heal_NegativeInput()
    {
        HealthSystem system = new HealthSystem();
        system.health = 100;
        system.shield = 0;

        system.Heal(-20);
        
        Debug.Assert(100 == system.health);
        Debug.Assert(0 == system.shield);
    }

    void Test_RegenerateShield()
    {
        HealthSystem system = new HealthSystem();
        system.health = 100;
        system.shield = 80;

        system.RegenerateShield(20);

        Debug.Assert(100 == system.health);
        Debug.Assert(100 == system.shield);
    }
    
    void Test_RegenerateShield_AtMax()
    {
        HealthSystem system = new HealthSystem();
        system.health = 100;
        system.shield = 100;

        system.RegenerateShield(20);

        Debug.Assert(100 == system.health);
        Debug.Assert(100 == system.shield);
    }

    void Test_RegenerateShield_NegativeInput()
    {
        HealthSystem system = new HealthSystem();
        system.health = 100;
        system.shield = 100;

        system.RegenerateShield(-20);

        Debug.Assert(100 == system.health);
        Debug.Assert(100 == system.shield);
    }

    void Test_Revive()
    {
        HealthSystem system = new HealthSystem();
        system.health = 0;
        system.shield = 0;
        system.lives = 3;

        system.Revive();    

        Debug.Assert(100 == system.health);
        Debug.Assert(100 == system.shield);
        Debug.Assert(2 == system.lives);  
    }

    void Test_HealthStatus()
    {
        HealthSystem system = new HealthSystem();
        system.health = 100;
        system.shield = 0;        

        system.TakeDamage(11);
        system.HealthStatus();
        
        Debug.Assert(89 == system.health);
        Debug.Assert("Healthy" == system.healthStatus);        

    }

}
