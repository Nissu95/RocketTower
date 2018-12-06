public class AirConsoleJoystick : PlayerJoystick
{
    public override bool ListenCustom()
    {
        //Debug.Log("Listening for AirConsole");
        return false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
