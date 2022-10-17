using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject panel1 = null;
    public GameObject panel2 = null;
    private Transform starting_pos;
    private Transform other_pos;
    void Start()
    {
        Debug.Assert(panel1 != null, "assign an object to this thing");
        Debug.Assert(panel2 != null, "assign an object to this thing");
        starting_pos = panel1.transform;
        other_pos = panel2.transform;
    }
    
    public void OnCredits()
    {
        SceneManager.LoadScene("Credit");
    }

    public void OnSettings()
    {
        panel1.transform.Translate( Vector3.right * 500000000.0f );
        panel2.transform.position = starting_pos.position;
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnPlay()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
