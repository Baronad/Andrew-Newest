CapsuleCollider playerCol;

// sätter höjden på objektet i samband med cylinderns höjd i spelet

float originalHeight = 3.8f;
public float reducedHeigh = 1.9f;


// assignar playerCol så att programmet förstår den 

void Start()
{
    playerCol = GetComponent<CapsuleCollider>();
    originalHeight = playerCol.height;
}



// halverar höjden på cylindern 

void Crouch()
{
    playerCol.height = reducedHeight;
}

void GoUp()
{
    playerCol.height = originalHeight;
}

// säger till programmet att när man trycker på leftkontroll så crouchar man 

void Update()
{
    if (Input.GetKeyDown(KeyCode.LeftControl))
        Crouch();
    else if (Input.GetKeyUp(KeyCode.LeftControl))
        GoUp();
}
    }
}
