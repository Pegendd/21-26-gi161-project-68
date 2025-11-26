using System.Runtime;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{


    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    

    void Start()
    
    {
        currentHealth = maxHealth ;

    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        if(currentHealth <= 0) 
        {

        currentHealth = 0;
        //GameManager.Instance.GameOver();


        }
        



    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount , 0 , maxHealth);
    }





}
