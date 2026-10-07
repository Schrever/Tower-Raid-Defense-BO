using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetSceneScript : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        ResetScene();
    }

    public void ResetScene()
    {

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }
}
