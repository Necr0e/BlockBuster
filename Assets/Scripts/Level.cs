using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //TODO: Remove serialize after debugging is over
    [SerializeField]  int blockCount;

    //Cache
    SceneLoader loadScene;

    private void Start()
    {
        loadScene = FindObjectOfType<SceneLoader>();
    }
    public void CountBreakableBlocks()
    {
        blockCount++;
    }

    public void BlockDestroyed()
    {
        blockCount--;
        if(blockCount <= 0)
        {
            loadScene.LoadNextScene(); 
        }
    }
}
