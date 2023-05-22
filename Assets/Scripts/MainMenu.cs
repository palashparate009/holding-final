using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private PlayerMovement pm;
    public void Start()
    {
      // Cursor.lockState= CursorLockMode.Locked;
       // Cursor.visible= true;
       
    }
    public void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        
    }
    public GameObject panelref;
    // Start is called before the first frame update
    public void Playgame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void back()
    {
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
       if (Input.GetKeyUp(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            optionmenupanel();
        }
    }
    public void optionmenupanel()
    {
        panelref.SetActive(true);
    }
    public void optionback()
    {
        SceneManager.LoadScene(1);
    }
    public void Restartbutton()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void powerup1btn()
    {
    }
 
}
