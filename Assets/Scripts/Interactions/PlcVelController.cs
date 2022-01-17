using UnityEngine;

public class PlcVelController : OutlineManager
{
    private float threshold = 5.5f;
    private GameObject lever;

    public float minAngle;
    public float maxAngle;
    public float min;
    public float max;
    public float rotY;

    private void Start() {
        Initialize();
    }

    public void Initialize()
    {
        Outline.enabled = false;
        lever = gameObject;
        Outline = GetComponent<Outline>();
    }

    public virtual void CompleteInteraction(bool success)
	{
		if (success != IsSuccessfullyCompleted)
		{
			IsSuccessfullyCompleted = success;

			if (success)
            {
                ShowSuccessColor();
                Invoke("DisableOutlineLever", 2);
            }
		}
	}

    public void DisableOutlineLever()
    {
        Outline.enabled = false;
    }

    public float GetAngleByValue(float val)
    {
        float ang = Mathf.Lerp(minAngle, maxAngle, Mathf.InverseLerp(min,max,val));
        return ang;
    }

    public float GetValueByAngle(float angle)
    {
        float val = (Mathf.Lerp(min, max, Mathf.InverseLerp(minAngle,maxAngle,angle))-4.77f);
        return val;
    }

    public void MoveToVal(object newVal)
    {
        lever.transform.rotation =  Quaternion.Euler(0f,rotY, GetAngleByValue(float.Parse(newVal.ToString())));
    }

    public float GetCurrentValue()
    {
        return GetValueByAngle(lever.transform.localEulerAngles.z);
    }

    public bool CompareCurrentValWith(float val2compare)
    {
        print(">= "+(val2compare-threshold)+" <= "+(val2compare+threshold));
        print(lever.transform.localEulerAngles.z+" == "+GetCurrentValue());
        return ((GetCurrentValue() >= (val2compare-threshold)) && (GetCurrentValue() <= (val2compare+threshold)));
    }

    public bool IsGreenSection()
    {
        print(">= "+(0)+" <= "+(100));
        print(lever.transform.localEulerAngles.z+" == "+GetCurrentValue());
        return ((GetCurrentValue() >= (0)) && (GetCurrentValue() <= (100)));
    }
}
