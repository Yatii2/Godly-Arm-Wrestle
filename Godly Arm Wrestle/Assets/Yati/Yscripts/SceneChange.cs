using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Fight()
    {
        SceneManager.LoadScene("FightTest");
    }

    public void Train()
    {
        SceneManager.LoadScene("Arm Wrestling");
    }
}
