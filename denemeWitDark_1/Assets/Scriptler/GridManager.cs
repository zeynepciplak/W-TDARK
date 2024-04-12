using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance; // Singleton instance

    private void Awake()
    {
        // Singleton instance kontrolü
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Birden fazla GridManager instance oluşturuldu. Singleton patern uygulanıyor.");
            Destroy(gameObject);
        }
    }
}

    /*public enum GridType
    {
        Ground,
        Grass,
        Stone
    }

    /* public GridType GetGridType(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.1f); // Konuma yakın collider'ları bul

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("ground"))
            {
                return GridType.Ground;
            }
            else if (collider.CompareTag("cali"))
            {
                return GridType.Grass;
            }
            else if (collider.CompareTag("stone"))
            {
                return GridType.Stone;
            }
        }

        return GridType.Ground; // Varsayılan olarak Ground döndür
    }

     private bool UpdateGridType()
    {
        // Oyuncunun bulunduğu konuma göre grid türünü güncelle
        GridManager.GridType newGridType = gridManager.GetGridType(transform.position);

        if (newGridType != currentGridType)
        {
            currentGridType = newGridType;
            return true; // Grid türü değiştiyse true döndür
        }

        return false; // Grid türü değişmediyse false döndür
    }
}

*/