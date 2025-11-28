using UnityEngine;

public class Spike : MonoBehaviour
{
    // ใช้ OnTriggerEnter2D เพื่อให้เดินชนแล้วทำงานทันที
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // เช็คว่าสิ่งที่ชนคือ Player หรือไม่
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                Debug.Log("โดนหนามตำ! ตายทันที");

                // ใส่ดาเมจเยอะๆ (เช่น 9999) เพื่อให้แน่ใจว่าตายทันที
                playerHealth.TakeDamage(9999);
            }
        }
    }
}