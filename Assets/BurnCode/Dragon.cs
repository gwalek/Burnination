using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    DragonState state = DragonState.Idle; 
    public Material Idle;
    public Material Walk1;
    public Material Walk2;
    public Material Walk3; 

    Material currentSprite;
    float animationTimeCounter = 0;
    public float AnimationBoost = 6;
    public int maxFrames = 10;


    public GameObject SpritePlane;
    Renderer SpriteR;
    Rigidbody RB;


    // Start is called before the first frame update
    void Start()
    {
        currentSprite = Idle;
        state = DragonState.Idle;
        SpriteR = SpritePlane.GetComponent<Renderer>();
        RB = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DebugAnimationStates();
       

        UpdateSprite();
    }

  

    void DebugAnimationStates()
    {
        if (Input.GetKey(KeyCode.I))
        { state = DragonState.Idle; }
        if (Input.GetKey(KeyCode.O))
        { state = DragonState.Walking; }
      
    }

    void UpdateSprite()
    {
        animationTimeCounter += (Time.fixedDeltaTime * AnimationBoost);
        if (animationTimeCounter > maxFrames)
        { animationTimeCounter -= maxFrames; }
        int frame = (int)animationTimeCounter;

        switch (state)
        {
            case DragonState.Idle:
                currentSprite = Idle;
                break;
            case DragonState.Walking:
                frame = frame % 5;
                if (frame == 0) { currentSprite = Walk1; }
                if (frame == 1) { currentSprite = Walk2; }
                if (frame == 2) { currentSprite = Walk3; }
                if (frame == 3) { currentSprite = Walk2; }
                if (frame == 4) { currentSprite = Walk1; }
                break;
           
        }

        Material[] mats = SpriteR.materials;
        mats[0] = currentSprite;
        SpriteR.materials = mats;
    }
}


