using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int countRemain;
    [SerializeField] SceneLoader sceneLoader;

    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void AmountOfBlocks()
    {
        countRemain++;
    }
    public void MinusOne()
    {
        countRemain--;
        if(countRemain<=0)
        {
            sceneLoader.NextScene();
        }
    }
}
