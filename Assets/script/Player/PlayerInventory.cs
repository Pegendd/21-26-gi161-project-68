using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false; // ตัวแปรจำว่ามีกุญแจไหม

    public void CollectKey()
    {
        hasKey = true;
        Debug.Log("เก็บกุญแจแล้ว! ไปที่ประตูได้เลย");
    }
}