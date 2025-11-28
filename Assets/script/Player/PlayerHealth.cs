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

        // *** เพิ่มบรรทัดนี้ ***
        Debug.Log($"ผู้เล่นโดนโจมตี! เลือดเหลือ: {currentHealth}/{maxHealth}");

        // (เช็คการตาย)
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("ผู้เล่นตายแล้ว! Game Over"); // เพิ่มให้รู้ว่าตายแล้ว

            // 1. เรียก GameManager ให้จบเกม
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();
            }

            // 2. ซ่อนตัวผู้เล่น (ให้เหมือนตายหายไป)
            gameObject.SetActive(false);
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount , 0 , maxHealth);
    }





}
