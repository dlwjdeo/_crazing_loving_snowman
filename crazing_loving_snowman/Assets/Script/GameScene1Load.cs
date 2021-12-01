using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene1Load : MonoBehaviour
{

    public void SceneChange()
    {
        SceneManager.LoadScene("GameScene1");
    }
}
