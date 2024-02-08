using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void GoToFirstScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("1-Takeout");
    }
}
