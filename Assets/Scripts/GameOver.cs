using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    
    void Update()
    {
        if (MovementScript.isGameOver)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }
}
