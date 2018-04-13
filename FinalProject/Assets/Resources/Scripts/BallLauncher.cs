using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform ballSpawnLoc;
    [SerializeField] private GameObject target;

    private GameObject ballGO;
    private Rigidbody ball;
    
    private UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter targetChar;

    public float h = 25;
    public float gravity = -18;
    public float projectileSpawnRate = 1.0f;

    public bool debugPath;

    private bool keepLaunchingBall = false;

    void Start()
    {
        Messenger.AddListener(GameEvent.GAME_START, startLaunching);
        Messenger.AddListener(GameEvent.GAME_OVER, stopLaunching);
    }

    void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_START, startLaunching);
        Messenger.AddListener(GameEvent.GAME_OVER, stopLaunching);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_START, startLaunching);
        Messenger.RemoveListener(GameEvent.GAME_OVER, stopLaunching);
    }

    private void stopLaunching()
    {
        keepLaunchingBall = false;
        StopCoroutine(keepLaunching());
    }

    private void startLaunching()
    {
        keepLaunchingBall = true;
        StartCoroutine(keepLaunching());
    }

    void Update()
    {
        // testing
        if (Input.GetKeyDown(KeyCode.R))
        {
            ballGO = Instantiate(ballPrefab) as GameObject;
            ballGO.transform.position = ballSpawnLoc.position;

            ball = ballGO.transform.GetComponent<Rigidbody>();

            Launch();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            keepLaunchingBall = true;
            StartCoroutine(keepLaunching());
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            keepLaunchingBall = false;
        }

        if (debugPath && ball != null)
        {
            DrawPath(); 
        }
    }

    private IEnumerator keepLaunching()
    {
        while (keepLaunchingBall)
        {

            ballGO = Instantiate(ballPrefab) as GameObject;
            ballGO.transform.position = ballSpawnLoc.position;

            ball = ballGO.transform.GetComponent<Rigidbody>();

            Launch();

            yield return new WaitForSeconds(projectileSpawnRate);
        }
    }

    void Launch()
    {
        Physics.gravity = Vector3.up * gravity;
        ball.useGravity = true;
        LaunchData data = CalculateLaunchData();
        if (data.initialVelocity != Vector3.zero)
        {
            ball.velocity = data.initialVelocity;
        }
    }

    public Vector3 landLocation()
    {
        if (ball == null)
        {
            return Vector3.zero;
        }
        float displacementY = target.transform.position.y - ball.position.y;
        float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);
        Vector3 displacementXZ = new Vector3(target.transform.position.x - ball.position.x, 0, target.transform.position.z - ball.position.z)
             + target.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().getMovePos() * time;

        return displacementXZ;
    }

    LaunchData CalculateLaunchData()
    {
        if (ball == null)
        {
            return new LaunchData(Vector3.zero, 0); 
        }
        else
        {
            float displacementY = target.transform.position.y - ball.position.y;
            float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);
            Vector3 displacementXZ = new Vector3(target.transform.position.x - ball.position.x, 0, target.transform.position.z - ball.position.z)
                 + target.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().getMovePos() * time;


            Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
            Vector3 velocityXZ = displacementXZ / time;

            return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
        }
    }

    void DrawPath()
    {
        LaunchData launchData = CalculateLaunchData();
        Vector3 previousDrawPoint = ball.position;

        int resolution = 30;
        for (int i = 1; i <= resolution; i++)
        {
            float simulationTime = i / (float)resolution * launchData.timeToTarget;
            Vector3 displacement = launchData.initialVelocity * simulationTime + Vector3.up * gravity * simulationTime * simulationTime / 2f;
            Vector3 drawPoint = ball.position + displacement;
            Debug.DrawLine(previousDrawPoint, drawPoint, Color.green);
            previousDrawPoint = drawPoint;
        }
    }

    struct LaunchData
    {
        public readonly Vector3 initialVelocity;
        public readonly float timeToTarget;

        public LaunchData(Vector3 initialVelocity, float timeToTarget)
        {
            this.initialVelocity = initialVelocity;
            this.timeToTarget = timeToTarget;
        }

    }
}