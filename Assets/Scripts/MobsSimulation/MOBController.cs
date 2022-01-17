using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using static MOBObject;
using System.Threading.Tasks;

public class MOBController : MonoBehaviour {

    [SerializeField] public TextAsset twineText;
    MOB currMOB;
    Node curNode;

    public delegate void NodeEnteredHandler( Node node );
    public event NodeEnteredHandler onEnteredNode;

    Action curReminder;
    Action curExpectedUserAction;
    List<Action> curSimulatorActions;

    public static string currentDirectoryAudios = "MOB1";

    bool remember = true;

    public Node GetCurrentNode() {
        return curNode;
    }
    

     void Start()
    {
        onEnteredNode += OnNodeEntered;
        //hay que inicializar cuando estén conectados el supervisor y el alumno
        InitializeDialogue();
    }

    public void InitializeDialogue() {
        currMOB = new MOB( twineText );
        curNode = currMOB.GetStartNode();
        onEnteredNode( curNode );
    }

    public List<Response> GetCurrentResponses() {
        return curNode.responses;
    }

    public void ChooseResponse( int responseIndex ) {
        if(!curNode.tags.Contains("END"))
        {
            string nextNodeID = curNode.responses[responseIndex].destinationNode;
            Node nextNode = currMOB.GetNode(nextNodeID);
            curNode = nextNode;
            onEnteredNode( nextNode );
        }
    }

    public async Task<bool> VerifyUserAction(Action actRecibida, int responseIndex=0)
    {
        print("ENTRA!");
        print(curExpectedUserAction.object2Action+" = "+actRecibida.object2Action);
        print(curExpectedUserAction.actionName+" = "+actRecibida.actionName);
        print(curExpectedUserAction.actionParams+" = "+actRecibida.actionParams);

        if(actRecibida.Equals(curExpectedUserAction))
        {
            remember = false;
            RecordatorioController.OcultarRecordatorio();
            print("igual a esperada");

            print(curSimulatorActions.Count);
            if(curSimulatorActions.Count>0)
            {
                MethodInfo taskObject = await ExecuteSimulatorActions(curSimulatorActions);

                // si tiene etiqueta random ==> se hace un random en el tamaño de responses
                // sino se selecciona la 0
                if (taskObject!=null)
                {
                    if(GetCurrentNode().tags.Contains("random"))
                    {
                        print("con acciones de usuario y es random");
                        curExpectedUserAction = new Action();
                        ChooseResponse(Random.Range(0,GetCurrentNode().responses.Count));
                    }
                    else
                    {
                        if(curNode.responses.Count == 1)
                        {
                            curExpectedUserAction = new Action();
                            ChooseResponse(responseIndex);
                        }  
                    }
                }
            }
            else
            {
                print("Next");
                curExpectedUserAction = new Action();
                ChooseResponse(responseIndex);
            }

            return true;
        }
        else
        {
            print("mostrar mensaje de que esto no es lo que se esperaba");
            return false;
        }
    }

    public async Task<MethodInfo> ExecuteSimulatorActions(List<Action> simulatorActions)
    {
        print("Empieza a ejecutar acciones de simulador actuales...");
        MethodInfo taskObject = null;
        foreach (var action in simulatorActions)
        {
            print("Ejecutando para "+action.object2Action+", la acción "+action.actionName+" - "+action.actionParams);
            GameObject objectF =  GameObject.Find(action.object2Action);
            if(objectF!=null)
            {
                print("El objeto "+objectF+" existe");
                taskObject = await objectF.GetComponent<ObjectController>().MethodAccess(action.actionName, action.actionParams);
            }
            else
            {
                Debug.Log("ERROR: No existe un objeto con el nombre "+action.object2Action);
            }
        }
        print("Terminó acciones de simulador actuales...");

        return taskObject;
    }

    /** Activa el recordatorio buscando el método
    */
    public async void ActivarRecordatorio()
    {
        if(remember)
        {
            await GameObject.Find(curReminder.object2Action).GetComponent<ObjectController>().MethodAccess(curReminder.actionName, curReminder.actionParams);
        }
    }

    public void SkipNode()
    {
        ChooseResponse(0);
    }


    private async void OnNodeEntered(Node newNode)
    {
        Debug.Log("CONTROLLER - Entering node: " + newNode.title);
        curExpectedUserAction = new Action();
        curSimulatorActions = null;
        MethodInfo taskObject = null;

        if(newNode.tags.Contains("END"))
        {
            await ExecuteSimulatorActions(newNode.simulatorActions);
            return;
        }

        if(newNode.userActions.Count == 0)
        {
            print("Sin acciones de usuario");
            taskObject = await ExecuteSimulatorActions(newNode.simulatorActions);
            if(newNode.tags.Contains("random"))
            {
                print("sin acciones de usuario pero si es random");
                ChooseResponse(Random.Range(0,newNode.responses.Count));
            }
            else
            {
                if(newNode.responses.Count == 1 && taskObject!=null && !newNode.tags.Contains("dialogo"))
                {
                    ChooseResponse(0);
                }  
            }       
        }
        else{
            print("Con acciones de usuario = "+newNode.userActions.Count);
            if(newNode.userActions.Count == 2)
            {
                curReminder = newNode.userActions[0];
                // Invocar el recordatorio despues de x tiempo
                remember = true;
                Invoke("ActivarRecordatorio", float. Parse(curReminder.actionParams.Split(';')[1]));

                curExpectedUserAction = newNode.userActions[1];
            }
            else if(newNode.userActions.Count == 1)
            {
                curExpectedUserAction = newNode.userActions[0];
            }
            
            curSimulatorActions = newNode.simulatorActions;
            
        }
    }
}