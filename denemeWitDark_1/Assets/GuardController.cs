using UnityEngine;

public class GuardController : MonoBehaviour
{
    public float moveSpeed = 2f; // Gardiyanın hareket hızı
    public float moveDistance = 10f; // İleri gidilecek mesafe

    private Vector3 startPos; // Gardiyanın başlangıç pozisyonu
    private bool movingForward = true; // Gardiyanın ileri mi geri mi hareket ettiğini kontrol eden flag
    private float currentDistance = 0f; // Gardiyanın ilerlediği toplam mesafe

    void Start()
    {
        startPos = transform.position; // Başlangıç pozisyonunu kaydet
    }

    void Update()
    {
        if (movingForward)
        {
            // İleri hareket
            float moveAmount = Mathf.Min(moveSpeed * Time.deltaTime, moveDistance - currentDistance);
            transform.Translate(Vector2.right * moveAmount);
            currentDistance += moveAmount;

            // Belirli mesafeye ulaşıldığında dur
            if (currentDistance >= moveDistance)
            {
                movingForward = false;
            }
        }
        else
        {
            // Geri hareket
            float moveBackAmount = Mathf.Min(moveSpeed * Time.deltaTime, currentDistance);
            transform.Translate(Vector2.left * moveBackAmount);
            currentDistance -= moveBackAmount;

            // Başlangıç noktasına geri dönüldüğünde tekrar ileri harekete geç
            if (currentDistance <= 0f)
            {
                movingForward = true;
                currentDistance = 0f; // Mesafeyi sıfırla
            }
        }
    }
}
