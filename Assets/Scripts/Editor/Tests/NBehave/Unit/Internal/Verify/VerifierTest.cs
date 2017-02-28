using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Verify {
    using Internal;

    public class VerifierTest {

        Mock.CallMemory callMemory;
        Mock.StubMemory stubMemory;
        Mock.MockProxy mockProxy;

        Mock.NBehaveMock mock;
        string method;
        Mock.MatcherList matchers;
        Verifier verifier;

        [SetUp] public void Init() {
            callMemory = new Mock.CallMemory();
            stubMemory = new Mock.StubMemory();
            mockProxy = new Mock.MockProxy();

            mock = new Mock.NBehaveMock();
            method = "Method";
            matchers = new Mock.MatcherList();

            mockProxy.CallMemory = callMemory;
            mockProxy.StubMemory = stubMemory;
            mock.NBehave = mockProxy;

            verifier = new Verifier(mock, method, matchers);
        }

        [Test] public void ShouldGatherCorrectMetricsFromCallMemory() {
            Mock.Times times = new Mock.Times();
            times.Returns.Matches.Set(3, true);
            callMemory.Returns.TimesCalled.Enqueue(3);

            verifier.HasInteractions(times);

            Assert.That(callMemory.CalledWith.TimesCalled.First, Is.EqualTo("Method"));
            Assert.That(callMemory.CalledWith.TimesCalled.Second, Is.EqualTo(matchers));
        }

        [Test] public void ShouldSucceedWhenCallMemorySatisfiesTimeCondition() {
            Mock.Times times = new Mock.Times();
            times.Returns.Matches.Set(3, true);
            callMemory.Returns.TimesCalled.Enqueue(3);

            verifier.HasInteractions(times);
        }

        [ExpectedException(typeof(Exceptions.VerificationException))]
        [Test] public void ShouldThrowExceptionWhenCallMemoryDoesNotSatisfyTimeCondition() {
            Mock.Times times = new Mock.Times();
            times.Returns.Matches.Set(3, true);
            callMemory.Returns.TimesCalled.Enqueue(2);

            verifier.HasInteractions(times);
        }

        [Test] public void ShouldReturnVerifierInteractionsWhenCalledOnce() {
            callMemory.Returns.TimesCalled.Enqueue(1);
            VerifierInteractions expected = new VerifierInteractions(verifier);

            Assert.That(verifier.IsCalled(), Is.EqualTo(expected));
        }

        [Test] public void ShouldReturnVerifierInteractionsWhenCalledMoreThanOnce() {
            callMemory.Returns.TimesCalled.Enqueue(2);
            VerifierInteractions expected = new VerifierInteractions(verifier);

            Assert.That(verifier.IsCalled(), Is.EqualTo(expected));
        }

        [ExpectedException(typeof(Exceptions.VerificationException))]
        [Test] public void ShouldThrowExceptionWhenMethodWasNotCalledAtLeastOnce() {
            callMemory.Returns.TimesCalled.Enqueue(0);

            verifier.IsCalled();
        }

        [Test] public void ShouldSucceedWhenNeverCalled() {
            callMemory.Returns.TimesCalled.Enqueue(0);

            verifier.IsNotCalled();
        }

        [ExpectedException(typeof(Exceptions.VerificationException))]
        [Test] public void ShouldThrowExceptionWhenCalledOnce() {
            callMemory.Returns.TimesCalled.Enqueue(1);

            verifier.IsNotCalled();
        }

        [ExpectedException(typeof(Exceptions.VerificationException))]
        [Test] public void ShouldThrowExceptionWhenCalledMoreThanOnce() {
            callMemory.Returns.TimesCalled.Enqueue(2);

            verifier.IsNotCalled();
        }

    }

}