using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    private float moveSpeed;

    [SerializeField] private int damage = 10;
    private float DistanceToTargetToDestroyProjectile = 1f;

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 moveDirNormalized = (target.position - transform.position).normalized;
        transform.position += moveDirNormalized * moveSpeed * Time.deltaTime;

        // เช็คระยะห่างว่าถึงตัวหรือยัง
        if (Vector3.Distance(transform.position, target.position) < DistanceToTargetToDestroyProjectile)
        {
            PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // *** เพิ่มบรรทัดนี้ ***
                Debug.Log($"ระเบิดชนตัวผู้เล่นแล้ว! กำลังสร้างความเสียหาย {damage} หน่วย");

                playerHealth.TakeDamage(damage);
            }
            else
            {
                Debug.Log("ระเบิดชนเป้าหมาย แต่เป้าหมายไม่มีสคริปต์ PlayerHealth");
            }

            Destroy(gameObject);
        }
    }

    public void InitializeProjectile(Transform target, float moveSpeed)
    {
        this.target = target;
        this.moveSpeed = moveSpeed;
    }

    // *** เพิ่มส่วนนี้ครับ: เช็คการชนพื้น/กำแพง ***
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ถ้าสิ่งที่ชนมี Tag ชื่อ "Ground"
        if (collision.CompareTag("Ground"))
        {
            // (Optional) ใส่ Effect ระเบิดตูมตามตรงนี้ได้
            Destroy(gameObject); // ทำลายระเบิดทิ้งทันที
        }
    }
}