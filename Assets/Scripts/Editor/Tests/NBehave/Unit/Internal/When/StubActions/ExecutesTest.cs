﻿using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.When {
    using Internal;

    public class ExecutesTest {

        [Test] public void ShouldCallDelegateWithArguments() {
            Core.ExecutesDelegate f = (args) => (int)args[0] + (int)args[1];
            Assert.That(new Executes(f, new object[] { 2, 3 }).Return(), Is.EqualTo(5));
            Assert.That(new Executes(f, new object[] { 5, 7 }).Return(), Is.EqualTo(12));
        }

    }

}
