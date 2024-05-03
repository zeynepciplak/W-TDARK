using UnityEngine;
using UnityEngine.SceneManagement;
public class OnExitLevel : MonoBehaviour
{
    public string sceneName;
    public bool isNextScene = true;

    [SerializeField]
    public SceneInfo sceneInfo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneInfo.isNextScene = isNextScene;
        SceneManager.LoadScene(sceneName);
    }

}
