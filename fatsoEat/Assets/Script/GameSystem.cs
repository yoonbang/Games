using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSystem : MonoBehaviour {
    public GameObject[] foodRotation = new GameObject[7];
    public GameObject redFood;
    public GameObject blueFood;
    public GameObject yellowFood;
    public GameObject blackFood;
    public Transform[] food = new Transform[7];
    int foodCount=7;
    int randomFood = 0;

    int layerMask;

    public string DishLayer = "Dish";
    public string SkillLayer = "Skill";

    Dish dish;
    Node node;
    Food_Dish food_Dish;

    int dishid;
    int nodeid;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;

    // Use this for initialization
    void Start()
    {
        FoodSating();
    }
    void Awake()
    {
        layerMask = LayerMask.GetMask(DishLayer, SkillLayer);
    }
	
	// Update is called once per frame
	void Update () {
        MouseButtonClick();
    }
    #region FoodSating
    public void FoodSating()
    {
        for(int index=0; index < foodCount; index++)
        {
            randomFood = Random.Range(1, 5);

            if (randomFood == 1)
            {
                foodRotation[index] = Instantiate(redFood) as GameObject;
                foodRotation[index].transform.parent = food[index].transform;
                foodRotation[index].transform.position = food[index].transform.position;
            }
            if (randomFood == 2)
            {
                foodRotation[index] = Instantiate(blueFood) as GameObject;
                foodRotation[index].transform.parent = food[index].transform;
                foodRotation[index].transform.position = food[index].transform.position;
            }
            if (randomFood == 3)
            {
                foodRotation[index] = Instantiate(yellowFood) as GameObject;
                foodRotation[index].transform.parent = food[index].transform;
                foodRotation[index].transform.position = food[index].transform.position;
            }

            if (randomFood == 4)
            {
                foodRotation[index] = Instantiate(blackFood) as GameObject;
                foodRotation[index].transform.parent = food[index].transform;
                foodRotation[index].transform.position = food[index].transform.position;
            }

        }
    }
    #endregion FoodSating

    #region MouseButtonClick
    public void MouseButtonClick()
    {
        if (Input.touchCount > 0)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            foreach (Touch touch in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, 100f, layerMask))
                {
                    int layer = hitInfo.transform.gameObject.layer;

                    GameObject recipient = hitInfo.transform.gameObject;
                    touchList.Add(recipient);

                    dish = hitInfo.collider.transform.GetComponent<Dish>();
                    node = GameObject.FindGameObjectWithTag("Rice").GetComponent<Node>();
                    
                      
                    dishid = dish.id;
                    nodeid = node.id;
                    if (touch.phase==TouchPhase.Began && layer == LayerMask.NameToLayer(DishLayer) && dishid == nodeid)
                    {
                        food_Dish = GameObject.FindGameObjectWithTag("Food_Dish").GetComponent<Food_Dish>();
                        food_Dish.Damage();
                        Destroy(foodRotation[0]);
                        //Debug.Log("click");
                    }
                }
            }
        }
        if(foodRotation[0]==null)
        {
            foodRotation[0] = Instantiate(foodRotation[1]) as GameObject;
            foodRotation[0].transform.parent = food[0].transform;
            foodRotation[0].transform.position = food[0].transform.position;
            nodeid = foodRotation[0].GetComponent<Node>().id;

            Destroy(foodRotation[1]);
            foodRotation[1] = Instantiate(foodRotation[2]) as GameObject;
            foodRotation[1].transform.parent = food[1].transform;
            foodRotation[1].transform.position = food[1].transform.position;

            Destroy(foodRotation[2]);
            foodRotation[2] = Instantiate(foodRotation[3]) as GameObject;
            foodRotation[2].transform.parent = food[2].transform;
            foodRotation[2].transform.position = food[2].transform.position;

            Destroy(foodRotation[3]);
            foodRotation[3] = Instantiate(foodRotation[4]) as GameObject;
            foodRotation[3].transform.parent = food[3].transform;
            foodRotation[3].transform.position = food[3].transform.position;

            Destroy(foodRotation[4]);
            foodRotation[4] = Instantiate(foodRotation[5]) as GameObject;
            foodRotation[4].transform.parent = food[4].transform;
            foodRotation[4].transform.position = food[4].transform.position;

            Destroy(foodRotation[5]);
            foodRotation[5] = Instantiate(foodRotation[6]) as GameObject;
            foodRotation[5].transform.parent = food[5].transform;
            foodRotation[5].transform.position = food[5].transform.position;

            randomFood = Random.Range(1, 5);

            if (randomFood == 1)
            {
                Destroy(foodRotation[6]);
                foodRotation[6] = Instantiate(redFood) as GameObject;
                foodRotation[6].transform.parent = food[6].transform;
                foodRotation[6].transform.position = food[6].transform.position;
            }
            if (randomFood == 2)
            {
                Destroy(foodRotation[6]);
                foodRotation[6] = Instantiate(blueFood) as GameObject;
                foodRotation[6].transform.parent = food[6].transform;
                foodRotation[6].transform.position = food[6].transform.position;
            }
            if (randomFood == 3)
            {
                Destroy(foodRotation[6]);
                foodRotation[6] = Instantiate(yellowFood) as GameObject;
                foodRotation[6].transform.parent = food[6].transform;
                foodRotation[6].transform.position = food[6].transform.position;
            }

            if (randomFood == 4)
            {
                Destroy(foodRotation[6]);
                foodRotation[6] = Instantiate(blackFood) as GameObject;
                foodRotation[6].transform.parent = food[6].transform;
                foodRotation[6].transform.position = food[6].transform.position;
            }
        }
    }
    #endregion MouseButtonClick
}
