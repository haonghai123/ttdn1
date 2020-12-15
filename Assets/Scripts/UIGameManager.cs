using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameManager : MonoBehaviour
{
    public GameObject panelPause;
    // Start is called before the first frame update
    //Mỗi scene tạo ra 1 script để quản lý UI riêng cho scene đó
    public void PressButtonPause()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }

    public void PressButtonResume()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }

    public void PressButtonRestart()
    {
        SceneManager.LoadScene(0);
    }
    public void PressButtonQuit()
    {
        Application.Quit();
    }
}
