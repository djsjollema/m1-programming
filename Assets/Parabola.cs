using UnityEngine;

public class Parabola : MonoBehaviour
{

    [SerializeField] Point point;
    Point[] points;
    int NumberOfPoints = 100;
    Vector2 minScreen,maxScreen;

    [SerializeField] float a = 1;
    [SerializeField] float b = 2;
    [SerializeField] float c = 3;

    QuadraticFunction f;


    void Start()
    {
        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        float dx =  (maxScreen.x - minScreen.x) / NumberOfPoints;

        points = new Point[NumberOfPoints+1];
        for (int i = 0; i <= NumberOfPoints; i++)
        {
            points[i] = Instantiate(point);
            points[i].x = minScreen.x + i * dx;
            points[i].y = 0;
        }

        f = new QuadraticFunction(a, b, c);
    }

    // Update is called once per frame
    void Update()
    {
        f.a = a; f.b = b; f.c = c;

        for (int i = 0; i <= NumberOfPoints; i++)
        {
            points[i].y = f.getY(points[i].x);
        }
        
    }
}
