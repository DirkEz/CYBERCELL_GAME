using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelectorSwitch : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("GameSelector");
    }
}