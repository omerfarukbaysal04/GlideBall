using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Vector3 currentCheckpoint;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        currentCheckpoint = new Vector3(-9, 0, -2);
        ResetCheckPoint();
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level1")
        {
            currentCheckpoint = new Vector3(-9, 0, 0);
        }
        else if (scene.name == "Level2")
        {
            currentCheckpoint = new Vector3(-7, 0, 0);
        }
        else if (scene.name == "Level3")
        {
            currentCheckpoint = new Vector3(-9, 0, 0);
        }
        else if (scene.name == "Level4")
        {
            currentCheckpoint = new Vector3(-9, 0, 0);
        }
        else if (scene.name == "Level5")
        {
            currentCheckpoint = new Vector3(-9, 0, 0);
        }
        else if (scene.name == "Level6")
        {
            currentCheckpoint = new Vector3(-9, 0, 0);
        }
        else if (scene.name == "Level7")
        {
            currentCheckpoint = new Vector3(-9, 0, 0);
        }
        else if (scene.name == "Level8")
        {
            currentCheckpoint = new Vector3(-8, 0, 0);
        }
        else if (scene.name == "Level9")
        {
            currentCheckpoint = new Vector3(-9, 0, 0);
        }
        ResetCheckPoint();
    }

    public void SetCheckPoint(Vector3 checkpointPosition)
    {
        currentCheckpoint = checkpointPosition;
    }

    public Vector3 GetCheckpoint()
    {
        return currentCheckpoint;
    }

    public void ResetCheckPoint()
    {
        currentCheckpoint = new Vector3(-9, 0, -2);
    }
}

