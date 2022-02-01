using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : SingletonBase<SceneLoader>
{
    [SerializeField] private int numberScene;
    [SerializeField] private int numSceneSlotMachine;
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(numberScene );
    }
    public void SelectLoadTape()
    {
        SceneManager.LoadSceneAsync(numberScene );
    }
    public void SelectLoadSlotMachine()
    {
        SceneManager.LoadSceneAsync(numSceneSlotMachine);
    }
}
