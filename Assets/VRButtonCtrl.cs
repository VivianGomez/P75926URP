using UnityEngine.UI;
using UnityEngine;

public class VRButtonCtrl : MonoBehaviour
{
    BoxCollider boxCollider;
    RectTransform rt;

    public bool hover = false;

    Image im;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        rt = GetComponent<RectTransform>();
        im = GetComponent<Image>();
        im.color = new Color(0,0,0,0.5f);
    }

    void Update()
    {
        Resize();
        if(hover)
        {
            im.color = new Color(0,0,0,1);
        }
        else
        {
            im.color = new Color(0,0,0,0.5f);
        }
    }

    public void Resize()
    {
        boxCollider.size = new Vector3(boxCollider.size.x, rt.rect.height-0.03f, boxCollider.size.z);
    }
}
