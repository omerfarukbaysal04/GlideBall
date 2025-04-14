using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TipsButton : MonoBehaviour
{

    public void LoadTraining()
    {
        SceneManager.LoadScene("Training");
    }

    public void LoadTips()
    {
        SceneManager.LoadScene("Tips");
    }

    public void LoadCredit()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadChallange()
    {
        SceneManager.LoadScene("Challange");
    }
}
