using UnityEngine.UI;
using UnityEngine;

public class TPLaserController : MonoBehaviour
{
    private LineRenderer laser;
    public bool isTPGesture = false;
    public GameObject cursorVisual;
    public GameObject cursorVisualUI;

    public Material correct;
    public Material wrong;

    bool enableTP = false;
    bool enableUISelection = false;
    GameObject curBtnSelected;

    void Start()
    {
        if (cursorVisual) cursorVisual.SetActive(false);
        if (cursorVisualUI) cursorVisualUI.SetActive(false);

        laser = gameObject.GetComponent<LineRenderer>();
        curBtnSelected = null;
    }

    public void DetectingTPGesture(bool value)
    {
        isTPGesture = value;
    }
 

    void Update()
    {
        if(isTPGesture)
        {
            ShowLaser(transform.position, transform.right , 10f);
            laser.enabled = true;
        }
        else
        {
            laser.enabled = false;
            if (cursorVisual) cursorVisual.SetActive(false);
            if (cursorVisualUI) cursorVisualUI.SetActive(false);

        }
        
    }

    void ShowLaser(Vector3 targetPos, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPos, direction);
        Vector3 endPos = targetPos + (direction * length);

        if(Physics.Raycast(ray, out RaycastHit rayHit, length))
        {
            if(rayHit.collider.gameObject.layer == 11 || rayHit.collider.gameObject.name.StartsWith("TPPoint"))
            {
                endPos = rayHit.point;
                //Debug.Log("ES = " + rayHit.collider.gameObject.name);
                laser.material = correct;
                if (cursorVisual)
                {
                    //cursorVisual.transform.position = endPos;
                    cursorVisual.transform.position = rayHit.collider.transform.position;
                    cursorVisual.SetActive(true);
                    enableTP = true;
                }
            }
            else if(rayHit.collider.gameObject.layer == 5)
            {
                endPos = rayHit.point;
                laser.material = correct;
                if (cursorVisualUI)
                {
                    cursorVisualUI.transform.position = endPos;
                    cursorVisualUI.SetActive(true);
                }
                enableUISelection = true;
                curBtnSelected = rayHit.collider.gameObject;
                curBtnSelected.GetComponent<VRButtonCtrl>().hover = true;
            }
            else
            {
                //Debug.Log("No es Ground (11), es "+ rayHit.collider.gameObject.layer);
                laser.material = wrong;
                if (cursorVisual) cursorVisual.SetActive(false);
                if (cursorVisualUI) cursorVisualUI.SetActive(false);

                enableTP = false;
                enableUISelection = false;
                
                if(curBtnSelected!=null)
                {
                    curBtnSelected.GetComponent<VRButtonCtrl>().hover = false;
                    curBtnSelected = null;
                }
                
            }
        }

        laser.SetPosition(0, targetPos);
        laser.SetPosition(1, endPos);
    }


    public void Teleport()
    {
        if(enableTP)
        {
            GameObject.Find("PlayerController").transform.position = new Vector3(cursorVisual.transform.position.x, GameObject.Find("PlayerController").transform.position.y,cursorVisual.transform.position.z);
        }
        else if(enableUISelection)
        {
            if(curBtnSelected!= null)
                curBtnSelected.GetComponent<Button>().onClick.Invoke();
        }
    }
}
