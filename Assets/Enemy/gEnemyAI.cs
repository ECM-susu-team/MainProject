using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class gEnemyAI : MonoBehaviour
{
    public int stopDistance = 3; 
    // AI'S target
    public Transform target;
    // the rate of update path
    public float updateTime = 2f;
    // store our seeker and _rb
    private Seeker _seeker;
    private Rigidbody2D _rb;
    // the path 
    public Path path;
    //the AI's speed
    public float speed = 300f;
    // the Physics mode
    public ForceMode2D fMode;
    [HideInInspector]
    public bool pathIsDone = false;
    // The max distance from between AI and the next waypoint
    public float nextWaypointDistance = 3;
    // current waypoint
    private int _currentWaypoint = 0;
    private bool _searhcingForP;

	public delegate void MethodAttack();
	public static event MethodAttack OnAttack;
	public delegate void MethodDisAttack();
	public static event MethodDisAttack OnDisableAttack;

    IEnumerator SearchForP()
    {
        GameObject sResult = GameObject.FindGameObjectWithTag("enemytarget");
        if (sResult==null)
        {
            yield return new WaitForSeconds(updateTime);
            StartCoroutine(SearchForP());
        }
        else
        {
            target = sResult.transform;
            _searhcingForP = false;
            StartCoroutine(UpdatePath());
            yield return null;
        }
       
    }
    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            if (!_searhcingForP)
            {
                _searhcingForP = true;
                StartCoroutine(SearchForP());
            }

            yield return null;
        }

        // Start a new path to the target position
        _seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateTime);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path other)
    {
        //Debug.Log("Any errors? " + other.error);
        if (!other.error)
        {
            path = other;
            _currentWaypoint = 0;
        }
    }

    void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            if (!_searhcingForP)
            {
                _searhcingForP = true;
                StartCoroutine(SearchForP());
            }
            
            return;
        }

        // Start a new path to the target position, return the result to the OnPathComplete method
        _seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }


    void FixedUpdate()
    {
        if (target == null)
        {
            if (!_searhcingForP)
            {
                _searhcingForP = true;
                StartCoroutine(SearchForP());
            }
        }

        //TODO: look at the player? Idle

        if (path == null)
            return;

        if (_currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsDone)
                return;

            //Debug.Log("End of path reached.");
            pathIsDone = true;
            return;
        }
        pathIsDone = false;

        //Direction to the next waypoint
        Vector2 direction = (path.vectorPath[_currentWaypoint] - transform.position).normalized;
        
        direction *= speed * Time.fixedDeltaTime;

        //Move the AI
        if (Vector2.Distance(transform.position, target.position) > stopDistance)
        {
            //TODO:incapsulate method
            /*
            Vector2 vectorToTarget = target.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
          */
         

            _rb.bodyType = RigidbodyType2D.Dynamic;
            _rb.AddForce(direction, fMode);
			if (OnDisableAttack != null)
				OnDisableAttack ();
            
        }
        else
        {
           // _rb.bodyType = RigidbodyType2D.Static;
			if (OnAttack != null)
				OnAttack ();
        }

        float dist = Vector2.Distance(transform.position, path.vectorPath[_currentWaypoint]);
        if (dist <= nextWaypointDistance)
        {
            _currentWaypoint++;
            return;
        }
    }
   
}
