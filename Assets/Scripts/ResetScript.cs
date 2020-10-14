using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true; // show mouse
    }
    public void Restart() {
        SceneManager.LoadScene("Main");
    }
}
//else
//{
//SceneManager.LoadScene("GameOver");
//}