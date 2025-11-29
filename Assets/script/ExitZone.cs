using UnityEngine;

public class ExitZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. เช็คก่อนว่ามีอะไรมาชนไหม
        Debug.Log("มีบางอย่างมาชนประตู! สิ่งนั้นคือ: " + collision.gameObject.name);

        if (collision.CompareTag("Player"))
        {
            Debug.Log(">> คนที่มาชนคือ Player ถูกต้อง");

            PlayerInventory inventory = collision.GetComponent<PlayerInventory>();

            if (inventory != null && inventory.hasKey)
            {
                Debug.Log(">>>> เงื่อนไขครบ! ชนะเกม");
                Destroy(collision.gameObject);
                if (GameManager.Instance != null)
                {
                    Debug.Log(">> เจอ GameManager แล้ว! กำลังสั่งให้หยุดเวลา...");
                    GameManager.Instance.GameWin();
                }
                else
                {
                    Debug.LogError("!!!! หา GameManager ไม่เจอ (Instance เป็น Null) !!!!");
                }
            }
            else
            {
                Debug.Log(">> เป็น Player แต่น่าจะยังไม่มีกุญแจ หรือหา Inventory ไม่เจอ");
            }
        }
        else
        {
            Debug.Log(">> สิ่งที่มาชน ไม่ใช่ Player (Tag ผิด)");
        }
    }
}