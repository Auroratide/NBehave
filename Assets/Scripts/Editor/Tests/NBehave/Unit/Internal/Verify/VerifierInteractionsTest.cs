using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Verify {
    using Internal;

    public class VerifierInteractionsTest {

        Mock.Verifier verifier;
        VerifierInteractions verifierInteractions;

        [SetUp] public void Init() {
            verifier = new Mock.Verifier();
            verifierInteractions = new VerifierInteractions(verifier);
        }

        [Test] public void ShouldVerifyInteractionsWithExactlyOne() {
            Exactly expected = new Exactly(1);

            verifierInteractions.Once();

            Assert.That(verifier.CalledWith.HasInteractions.First, Is.EqualTo(expected));
        }

        [Test] public void ShouldVerifyInteractionsWithExactlyTwo() {
            Exactly expected = new Exactly(2);

            verifierInteractions.Twice();

            Assert.That(verifier.CalledWith.HasInteractions.First, Is.EqualTo(expected));
        }

        [Test] public void ShouldVerifyInteractionsWithExactlyThree() {
            Exactly expected = new Exactly(3);

            verifierInteractions.Thrice();

            Assert.That(verifier.CalledWith.HasInteractions.First, Is.EqualTo(expected));
        }

        [Test] public void ShouldVerifyInteractionsWithExactlyFour() {
            Exactly expected = new Exactly(4);

            verifierInteractions.Exactly(4);

            Assert.That(verifier.CalledWith.HasInteractions.First, Is.EqualTo(expected));
        }

        [Test] public void ShouldVerifyInteractionsWithExactlyFive() {
            Exactly expected = new Exactly(5);

            verifierInteractions.Exactly(5);

            Assert.That(verifier.CalledWith.HasInteractions.First, Is.EqualTo(expected));
        }

        [Test] public void ShouldVerifyInteractionsWithAtMostOne() {
            AtMost expected = new AtMost(1);

            verifierInteractions.AtMost(1);

            Assert.That(verifier.CalledWith.HasInteractions.First, Is.EqualTo(expected));
        }

        [Test] public void ShouldVerifyInteractionsWithAtMostTwo() {
            AtMost expected = new AtMost(2);

            verifierInteractions.AtMost(2);

            Assert.That(verifier.CalledWith.HasInteractions.First, Is.EqualTo(expected));
        }

        [Test] public void ShouldVerifyInteractionsWithAtLeastOne() {
            AtLeast expected = new AtLeast(1);

            verifierInteractions.AtLeast(1);

            Assert.That(verifier.CalledWith.HasInteractions.First, Is.EqualTo(expected));
        }

        [Test] public void ShouldVerifyInteractionsWithAtLeastTwo() {
            AtLeast expected = new AtLeast(2);

            verifierInteractions.AtLeast(2);

            Assert.That(verifier.CalledWith.HasInteractions.First, Is.EqualTo(expected));
        }

    }

}