using System.Runtime;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    // 1. เพิ่มตัวแปรสำหรับเชื่อมต่อ HealthBar
    [SerializeField] private HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;

        // 2. อัปเดตหลอดเลือดตอนเริ่มเกม (ให้เต็มหลอด)
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        Debug.Log($"ผู้เล่นโดนโจมตี! เลือดเหลือ: {currentHealth}/{maxHealth}");

        // 3. อัปเดตหลอดเลือดเมื่อโดนดาเมจ
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // (อย่าลืมอัปเดตครั้งสุดท้ายก่อนตาย เพื่อให้หลอดเป็น 0)
            if (healthBar != null) healthBar.UpdateHealthBar(0, maxHealth);

            Debug.Log("ผู้เล่นตายแล้ว! Game Over");

            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();
            }

            gameObject.SetActive(false);
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        // 4. อัปเดตหลอดเลือดเมื่อฮีล
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
    }
}