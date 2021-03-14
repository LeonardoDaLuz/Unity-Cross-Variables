using UnityEngine;

public class DeltaTimeDebuger : MonoBehaviour
{
    // Draws a line from "startVertex" var to the curent mouse position.
    public Material mat;
    float gridSize = 0.0025f;
    int pointsNumber = 300;
    public bool enable;

    void Start()
    {

        points = new Vector3[pointsNumber];

        var horizontalCamWorldDistance = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x - Camera.main.ScreenToWorldPoint(new Vector3(0f,0f,0f)).x;
        gridSize = (horizontalCamWorldDistance / pointsNumber)* 0.056f;
    }


    public Vector3[] points;

    void OnPostRender()
    {
        if (!enable)
            return;

        int currentPoint = Time.frameCount % pointsNumber;
     //   print(currentPoint);
        points[currentPoint] = new Vector3(currentPoint* gridSize, Time.deltaTime * 5f, 0f);

        if (!mat)
        {
            Debug.LogError("Please Assign a material on the inspector");
            return;
        }
        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();

        for (int i = 0; i < points.Length-1 && i<currentPoint; i++)
        {
            GL.Begin(GL.LINES);
            GL.Color(Color.red);
            GL.Vertex(points[i]);
            GL.Vertex(points[i+1]);
            GL.End();
        }

        GL.PopMatrix();
    }
}