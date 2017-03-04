> Super important note! NBehave is still in pre-release (aka. before version 1.0). This means it is incomplete! There may still be a few bugs to hammer out, and the interfaces may drastically change as features are rolled out or re-engineered
> 
> Feel free to use this on your own project, but keep in mind that there can be any number of breaking changes between versions until 1.0 finally comes around. Still, I would greatly appreciate any feedback or suggestions you may have to make NBehave more useful to everyone!

NBehave
=======

Hey there! **NBehave** is a lightweight testing framework for the Unity game engine. It is meant to help you betterify your code and prevent those pesky bugs from appearing in your game. How? By helping you write snazzy tests, of course!

Why Test?
---------

It is obvious we should test our code before shipping it. We all do it, even if it is by clicking that glorious Unity Play button and seeing if the game does what we want. However, manually testing your game like this can only get you so far.

After all, you can't manually test the *entire* game every time you make a change to your code. Games are too darn big to do that. But if you don't test the whole thing, how do you know whether or not your little change created a bug somewhere else? Every change to code introduces the possibility of a bug arising somewhere you least expect.

What you really want is to be able to write some code, click a button, and *immediately* and *automatically* know that your code is A-OK, without ever needing to actually run the game. It sounds like a myth, but believe it or not, this is actually possible! All you have to do is write code to test your code.

Lucky for you, Unity [provides a way to easily do this](https://unity3d.com/learn/tutorials/topics/production/unity-test-tools), and **NBehave** makes it even easier.


Why NBehave?
------------

Unity allows you to write two kinds of tests: *unit* tests and *integration* tests. Unit tests are meant to test a single class and a single method at a time, whereas integration tests are used to test a collection of classes working together. Unfortunately, Unity's in-built testing tools, while super cool, don't *actually* let you write unit tests and integration tests.

Their unit tests (based on a framework called [NUnit](https://www.nunit.org/)) do not necessarily isolate the one class you are trying to test. If, for example, you have small collection of scripts that interact with one another on an object, it is hard to test exactly one of those scripts without the other scripts becoming involved.

Additionally, the integration tests require creating actual scenes. Although valuable, I would argue these are more like *functional* tests since they actually simulate the game. Ideally, your integration tests can be written entirely with code so that they can be run quickly and automatically.

**NBehave** allows you to write actual unit tests by isolating the class you want to test and "faking" other scripts. Furthermore, you can write integration tests entirely with code, thereby allowing you to click a single button to run all tests.


Basic Usage
-----------

Create a mock of an non-MonoBehaviour interface:
```csharp
ITile mockTile = Mock.Basic<ITile>();
```

Add a mock component to a game object:
```csharp
GameObject gameObject = new GameObject();
IGun mockGun = gameObject.AddMockComponent<IGun>();
```

Verify that a method was called:
```csharp
Verify.That(() => mockGun.Shoot()).IsCalled();
```

Verify that a method was called twice, with specific arguments:
```csharp
Verify.That(() => mockGun.Reload(8)).IsCalled().Twice();
```

Force a method to return a specific value:
```csharp
When.Called(() => mockGun.NumberOfBullets()).Then.Return(4);

int n = mockGun.NumberOfBullets();  // n is now 4
```

Make a return chain!
```csharp
When.Called(() => mockGun.NumberOfBullets())
    .Then.Return(2)
    .Then.Return(1)
    .Then.Return(0);
    
int n = mockGun.NumberOfBullets();  // n is now 2
n = mockGun.NumberOfBullets();  // n is now 1
n = mockGun.NumberOfBullets();  // n is now 0
```

More details will become available in a Github wiki somewhere.
