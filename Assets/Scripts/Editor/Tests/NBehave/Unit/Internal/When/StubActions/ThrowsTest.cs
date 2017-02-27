using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.When {
    using Internal;

    public class ThrowsTest {

        [ExpectedException(typeof(System.Exception))]
        [Test] public void ShouldThrowGivenException() {
            new Throws(new System.Exception()).Return();
        }

        [ExpectedException(typeof(CustomException))]
        [Test] public void ShouldThrowCustomException() {
            new Throws(new CustomException()).Return();
        }

        private class CustomException : System.Exception {}

    }

}
