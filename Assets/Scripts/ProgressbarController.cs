using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ProgressbarController : MonoBehaviour
{
    public void ChangeVal(object newVal)
    {
        GetComponent<Slider>().value = float.Parse(""+newVal);
    }
}
