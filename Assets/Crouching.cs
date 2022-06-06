CapsuleCollider playerCol;
float originalHeight = 3.8f;
public float reducedHeigh = 1.9f;


void Start()
{
    playerCol = GetComponent<CapsuleCollider>();
    originalHeight = playerCol.height;
}




void Crouch()
{
    playerCol.height = reducedHeight;
}

void GoUp()
{
    playerCol.height = originalHeight;
}

void Update()
{
    if (Input.GetKeyDown(KeyCode.LeftControl))
        Crouch();
    else if (Input.GetKeyUp(KeyCode.LeftControl))
        GoUp();
}
    }
}
