using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PreviousStage : MonoBehaviour
{
    public static string sceneName = null;

	public static bool GoToPreviousStage()
    {
        if(sceneName != null)
        {
			GameManager.SetActive (false);
            SceneManager.LoadScene(sceneName);
            return true;
        }
        return false;
    }

	void Start ()
    {		
        sceneName = SceneManager.GetActiveScene().name;
    }
	
}
