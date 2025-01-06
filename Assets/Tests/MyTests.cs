using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;

public class MyTests
{
    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator MyTestsSimplePasses()
    {
        //Arrange
        GameObject perso = new GameObject();
        var health = perso.AddComponent<Health>();

        //on force l'awake pour bien faire l'inscription des évènements
        health.GetType().GetMethod("Awake", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(health, new object[] { });
        yield return null;

        //Act
        Assert.Throws<ArgumentException>( () => health.ReceiveRegen(-12));
    }

   
}
