using System.IO;
using UnityEngine;

public static class SaveLoadManager
{
    private static string saveFilePath = Application.persistentDataPath + "/playerState.json";

    // Oyuncu durumunu JSON formatında kaydeden metot
    public static void SavePlayerState(PlayerState playerState)
    {
        // PlayerState nesnesini JSON formatına dönüştür
        string json = JsonUtility.ToJson(playerState);
        // JSON verisini dosyaya yaz
        File.WriteAllText(saveFilePath, json);
    }

    // Oyuncu durumunu JSON formatında yükleyen metot
    public static PlayerState LoadPlayerState()
    {
        // Dosya mevcutsa JSON verisini oku ve PlayerState nesnesine dönüştür
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            return JsonUtility.FromJson<PlayerState>(json);
        }
        // Dosya mevcut değilse null döndür
        return null;
    }
}