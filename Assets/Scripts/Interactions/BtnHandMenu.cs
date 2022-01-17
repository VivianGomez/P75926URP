using UnityEngine.Events;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BtnHandMenu : MonoBehaviour
{
    public Animator screenMenuAnim;
    public Image imIcon;

    public string iconActive;

    Animator anim;
    public bool pTouched = false;
    public bool activated = false;

    public Animator instructionAnim;
    public UnityEvent tutorialEvent;


    void Start() {
        anim = GetComponent<Animator>();
        pTouched = false;
        activated = false;
        iconActive ="Images/Icons/hablar";
    }

    public void ActiveAnimation()
    {
        activated = !activated;
        anim.SetBool("pressed", activated);

        if (activated)
        {
            screenMenuAnim.SetBool("open", true);
            imIcon.sprite = Resources.Load<Sprite>("Images/Icons/cancel");
        }
        else
        {
            screenMenuAnim.SetBool("close", true);
            imIcon.sprite = Resources.Load<Sprite>(iconActive);
        }
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (!pTouched && other.tag =="IndexFinger")
        {
            pTouched = true;
            ActiveAnimation();
            instructionAnim.SetBool("playHand", false);
            if(tutorialEvent!=null)
            {
                tutorialEvent?.Invoke();
            }
            yield return new WaitForSeconds(0.5f);    
            pTouched = false;    
        }
    }
}
