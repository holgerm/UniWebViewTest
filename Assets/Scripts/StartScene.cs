using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {

    public string SceneName;

    public void DoIt() {
        SceneManager.LoadScene(SceneName);
    }

}
