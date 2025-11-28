using UnityEngine;

public class KeyItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // เรียกใช้กระเป๋าของผู้เล่น
            PlayerInventory inventory = collision.GetComponent<PlayerInventory>();

            if (inventory != null)
            {
                inventory.CollectKey(); // บอกว่าเก็บได้แล้ว
                Destroy(gameObject);    // ลบกุญแจออกจากฉาก
            }
        }
    }
}