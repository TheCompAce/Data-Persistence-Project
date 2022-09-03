using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public TMP_InputField UserName;
    // Start is called before the first frame update
    void Start()
    {
        if (MenuManager.Instance.lastName.Trim() != "")
        {
            UserName.text = MenuManager.Instance.lastName.Trim();
        }
    }

    public void StartGame()
    {
        MenuManager.Instance.lastName = UserName.text.Trim();
        if (MenuManager.Instance.lastName == "")
        {
            MenuManager.Instance.lastName = "No Name";
        }

        MenuManager.Instance.SaveDataInfo();
        SceneManager.LoadScene(1);
    }
}
