using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeEnd : MonoBehaviour
{
    public ParticleSystem particleLauncher;
    private void Awake()
    {
        particleLauncher = GetComponent<ParticleSystem>();
        Invoke(nameof(invstopspvn), 0.23f);
    }
    public void invstopspvn()
    {
        ParticleSystem.MainModule psMain = particleLauncher.main;
        psMain.simulationSpeed = 4;
        psMain.maxParticles = 0;
        particleLauncher.Emit(1);
    }
}
