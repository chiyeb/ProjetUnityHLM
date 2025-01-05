using UnityEngine;

public class ChildAnimatorController : MonoBehaviour
{
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Animator childAnimator;
    [SerializeField] private float movementThreshold = 0.00f;

    private Vector3 lastParentPosition;
    private bool isMoving;

    private void Start()
    {
        if (parentTransform == null)
        {
            parentTransform = transform.parent;
        }

        if (childAnimator == null)
        {
            childAnimator = GetComponent<Animator>();
        }

        lastParentPosition = parentTransform.position;
    }

    private void Update()
    {
        if (parentTransform != null && childAnimator != null)
        {
            Debug.Log(isMoving);
            float distanceMoved = (parentTransform.position - lastParentPosition).magnitude;
            bool currentlyMoving = distanceMoved > movementThreshold;
            Debug.Log("test "+ currentlyMoving);
            if (currentlyMoving != isMoving)
            {
                isMoving = currentlyMoving;
                childAnimator.SetBool("walk", isMoving);
            }

            lastParentPosition = parentTransform.position;
        }
    }
}
