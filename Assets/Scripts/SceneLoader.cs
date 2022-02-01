using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : SingletonBase<SceneLoader>
{
    [SerializeField] private int numberScene;
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + numberScene);
    }
}
