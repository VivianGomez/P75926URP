using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCtrl : MonoBehaviour
{
    private void Start() {
        StartCoroutine("doExitGame");
    }

    public IEnumerator doExitGame() {
     yield return new WaitForSeconds(6);
     GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeOut();
     yield return new WaitForSeconds(4);
     Application.Quit();
    }
}
