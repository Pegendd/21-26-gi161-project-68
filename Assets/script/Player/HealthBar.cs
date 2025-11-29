using UnityEngine;
using UnityEngine.UI; // ต้องมีบรรทัดนี้เพื่อคุม UI

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage; // ลากรูปสีเขียว (Fill) มาใส่
    [SerializeField] private Transform playerTransform; // ลากตัว Player มาใส่

    private void Update()
    {
        // ป้องกันหลอดเลือดกลับด้านตามตัวละคร
        // โดยการบังคับให้ Scale แกน X เป็นบวกเสมอ
        if (transform.parent != null)
        {
            if (transform.parent.localScale.x < 0 || transform.parent.eulerAngles.y != 0)
            {
                // ถ้าตัวแม่หมุน ตัวลูกจะหมุนกลับให้ตรง
                transform.rotation = Quaternion.identity;
            }
        }
    }

    // ฟังก์ชันนี้จะถูกเรียกจาก PlayerHealth
    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        // คำนวณเป็น % (ต้องแปลงเป็น float ก่อนหาร ไม่งั้นจะได้ 0)
        float fillValue = (float)currentHealth / maxHealth;
        fillImage.fillAmount = fillValue;
    }
}