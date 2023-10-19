using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{

    private static GameControls _gameControls;


    public static void Init(Player myPlayer)
    {
        _gameControls = new GameControls();

        _gameControls.Permanent.Enable();

        _gameControls.InGame.Movement.performed += jeff => 
        { 
            myPlayer.SetMovementDirection(jeff.ReadValue<Vector3>());
        };

        _gameControls.InGame.Jump.started += hello =>
        {
            myPlayer.Jump();
        };

        _gameControls.InGame.Run.performed += jeff =>
        {
            myPlayer.Run();
        };
    }

    public static void SetGameControls()
    {
        _gameControls.InGame.Enable();
        _gameControls.UI.Disable();
    }

    public static void SetUIControls()
    {
        _gameControls.InGame.Disable();
        _gameControls.UI.Enable();
    }

}
