using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AIFunctionsContainer))]
public class AIFieldOfViewVisualizerEditor : Editor
{
    private void OnSceneGUI()
    {
        AIFunctionsContainer fov = (AIFunctionsContainer)target;

        //Visualizes the AI's Sight
        Handles.color = UnityEngine.Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewDistance);

        Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.viewAngle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.viewAngle / 2);

        Handles.color = Color.white;
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.viewDistance);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.viewDistance);
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
