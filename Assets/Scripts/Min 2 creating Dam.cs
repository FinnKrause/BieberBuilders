using UnityEngine;

public class Min2creatingDam : MonoBehaviour
{
    public GameObject objectPrefab;     // Log for dam
    public int numberOfObjects = 5;     // Number of dam parts

    private GameObject currentObject;
    private int createdObjects = 0;
    private ObjectSpawnerMinigameTwo spawner;
    void Start()
    {
        spawner = FindObjectOfType<ObjectSpawnerMinigameTwo>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (createdObjects < numberOfObjects)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                currentObject = Instantiate(objectPrefab, mousePosition, Quaternion.identity);
                createdObjects++;
            }
            else if (createdObjects == numberOfObjects) 
            {
                spawner.spawnTheWood();
            }
        }
        else if (Input.GetMouseButton(0) && currentObject != null)
        {
            float rotationSpeed = 5f;
            float rotationAmount = Input.GetAxis("Mouse X") * rotationSpeed;

            currentObject.transform.Rotate(Vector3.forward, rotationAmount);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            currentObject = null;
        }
    }
}
