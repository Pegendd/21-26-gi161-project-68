using UnityEngine;
using UnityEngine.SceneManagement; // ต้องมีบรรทัดนี้เพื่อรีสตาร์ทเกม

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // ตัวแปรนี้จะทำให้ไฟล์อื่นเรียกใช้ได้ทันที

    [SerializeField] private GameObject gameOverUI; // ลาก Panel มาใส่ตรงนี้

    private void Awake()
    {
        // ตั้งค่า Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        Debug.Log("จบเกมแล้ว!");

        // 1. แสดงหน้าจอ Game Over
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        // 2. หยุดเวลาในเกม (ทุกอย่างจะนิ่ง)
        Time.timeScale = 0f;
    }

    // ฟังก์ชันสำหรับปุ่ม Restart (เอาไปใส่ปุ่มทีหลังได้)
    public void RestartGame()
    {
        Time.timeScale = 1f; // คืนเวลาให้เดินต่อ
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // โหลดฉากเดิมใหม่
    }
}