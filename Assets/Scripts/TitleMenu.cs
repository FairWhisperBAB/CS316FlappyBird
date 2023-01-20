using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{

    public void GoToHands()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToAngels()
    {
        SceneManager.LoadScene(2);
    }
}
