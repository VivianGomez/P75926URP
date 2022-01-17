using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Threading.Tasks;

public class ObjectController : MonoBehaviour
{
    public Object modelObject;

    public async Task<MethodInfo> MethodAccess(string methodName, string args, int delay=500)
    {
        Debug.Log("PARAMETROS "+ args);
        var modelObjectScript = modelObject.GetType();
        var loadingMethod = modelObjectScript.GetMethod(methodName);

        if(loadingMethod!=null)
        {
            if(args=="")
            {
                loadingMethod.Invoke(modelObject, System.Type.EmptyTypes);
            }
            else
            {
                var splitArgs = args.Split(';');
                //var arguments = new object[] { splitArgs };
                if(methodName=="Play" || methodName=="PlayVoice" || methodName=="Esperar" || methodName=="PlayAnimation")
                {
                    delay = (int) loadingMethod.Invoke(modelObject, splitArgs);
                }
                else
                {
                    loadingMethod.Invoke(modelObject, splitArgs);
                }
                
            }
        }
        else
        {
            Debug.Log("No existe un método llamado "+ methodName + ", en el objeto "+ modelObject);
        }
        
        Debug.Log("Esperando ... "+ delay);

        await Task.Delay(delay);

        return loadingMethod;
    }  
}
